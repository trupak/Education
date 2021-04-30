using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class AutocompleteSystem {

        class TreeNode {
            public char Letter {get;set;}
            public int Times {get;set;}
            public List<TreeNode> Childs {get;set;}
            public string Word { get; set; }

            public TreeNode()
            {
                Childs = new List<TreeNode>();
            }
        }
    
        private TreeNode _root;
        private string _cache;
        private Dictionary<string, int> _search;
        private int _maxResults = 3;
    
        public AutocompleteSystem(string[] sentences, int[] times) {
            _root = new TreeNode();
        
            for(var i = 0; i < sentences.Length; i++){
                Add(_root, sentences[i], times[i], 0);
            }

            _search = new Dictionary<string, int>();
        }
    
        private void Add(TreeNode node, string word, int times, int index){
            if (index >= word.Length)
                return;
        
            var existed = node.Childs.FirstOrDefault(x => x.Letter == word[index]);
            if (existed != null) {
                if (index == word.Length - 1)
                {
                    existed.Times += times;
                    existed.Word = word;
                    return;
                }
                
                Add(existed, word, times, index + 1);
            } else {
                var newNode = new TreeNode {Letter = word[index]};
                if (index == word.Length - 1)
                {
                    newNode.Times = times;
                    newNode.Word = word;
                }
                    
                node.Childs.Add(newNode);
                Add(newNode, word, times, index + 1);
            }
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                Add(_root, _cache, 1, 0);
                _cache = string.Empty;
                return new List<string>();
            }

            _cache += c;
            var s = Search(_root, _cache, 0);
            if (s == null)
                return new List<string>();
            
            _search.Clear();
            AddWords(s);
            return _search.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .Take(_maxResults)
                .ToList();
        }

        private void AddWords(TreeNode node)
        {
            if (node == null)
                return;
            
            if (node.Times > 0)
                _search.Add(node.Word, node.Times);

            foreach (var child in node.Childs)
                AddWords(child);
        }

        private TreeNode Search(TreeNode node, string word, int index)
        {
            var letter = word[index];
            var existed = node.Childs.FirstOrDefault(x => x.Letter == letter);
            if (existed == null)
                return null;

            if (index == word.Length - 1)
                return existed;

            return Search(existed, word, index + 1);
        }
    }
}