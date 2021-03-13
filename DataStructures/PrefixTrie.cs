using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    /// <summary>
    /// Prefix tree
    /// </summary>
    public class PrefixTrie
    {
        class TrieNode
        {
            public string Letter { get; }
            
            public bool EndOfWord { get; set; }

            public List<TrieNode> Childs { get; }
            
            public TrieNode(string letter, bool endOfWord = false)
            {
                Letter = letter;
                Childs = new List<TrieNode>();
                EndOfWord = endOfWord;
            }
        }

        private TrieNode _root;
        
        public PrefixTrie()
        {
            _root = new TrieNode(string.Empty);
        }
        
        public void Insert(string value)
        {
            var curNode = _root;
            for (int i = 0; i < value.Length; i++)
            {
                var existedNode = curNode.Childs.FirstOrDefault(x => x.Letter == value[i].ToString());
                if (existedNode != null)
                {
                    curNode = existedNode;

                    if (i == value.Length - 1)
                        curNode.EndOfWord = true;
                }
                else
                {
                    var newNode = new TrieNode(value[i].ToString(),i == value.Length - 1);
                    curNode.Childs.Add(newNode);
                    curNode = newNode;
                }
            }
        }
        
        public bool Search(string value)
        {
            return Search(value, true);
        }
        
        public bool StartsWith(string value)
        {
            return Search(value, false);
        }

        private bool Search(string value, bool endOfWord)
        {
            var curNode = _root;
            for (int i = 0; i < value.Length; i++)
            {
                var existedNode = curNode.Childs.FirstOrDefault(x => x.Letter == value[i].ToString());
                if (existedNode == null)
                    return false;

                curNode = existedNode;
            }

            return curNode.EndOfWord || !endOfWord;
        }
    }
}