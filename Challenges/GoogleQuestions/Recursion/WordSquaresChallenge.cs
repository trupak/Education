using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Recursion
{
    public class WordSquaresChallenge : IChallenge
    {
        public string Link
            => "";

        [Theory]
        [InlineData(new[] {"ball","area","lead","lady","wall"}, "[[ball,area,lead,lady],[wall,area,lead,lady]]")]
        [InlineData(new[] {"abat","baba","atan","atal"}, "[[baba,abat,baba,atan],[baba,abat,baba,atal]]")]
        public void WordSquaresTests(string[] words, string expected)
        {
            var expectedResult = expected.ToStringMatrix();
            var result = WordSquares(words);
            Assert.Equal(expectedResult, result.ToList().Select(x => x.ToArray()));
        }

        Dictionary<string, HashSet<int>>? _map;
        public IList<IList<string>> WordSquares(string[] words) {
            var res = new List<IList<string>>();
            _map = new Dictionary<string, HashSet<int>>();
            BuildMap(_map, words);
            Backtrack(words, new List<int>(), res);
            return res;
        }
    
        private void BuildMap(Dictionary<string, HashSet<int>> map, string[] words){
            for(int j=0;j<words.Length;j++){
                string w = words[j];
                var sb = new StringBuilder();
                for(int i=0;i<words[0].Length-1;i++){
                    sb.Append(w[i]);
                    var s = sb.ToString();
                    if(!map.ContainsKey(s)){
                        map.Add(s, new HashSet<int>());
                    }
                    map[s].Add(j);
                }
            }
        }
        private void Backtrack(string[] words, List<int> selected, List<IList<string>> res){
            if(selected.Count==words[0].Length){
                res.Add(selected.Select(x=>words[x]).ToList());
                return;
            }
        
            if(selected.Count==0){ // when no word
                for(int i=0;i<words.Length;i++){
                    selected.Add(i);
                    Backtrack(words, selected, res);
                    selected.RemoveAt(selected.Count-1);
                }
            }
            else{
                var prefix = new string(selected.Select(x=>words[x][selected.Count]).ToArray()); 
                if(_map!.ContainsKey(prefix)){
                    foreach(var i in _map[prefix]){
                        selected.Add(i);
                        Backtrack(words, selected, res);
                        selected.RemoveAt(selected.Count-1);
                    }
                }   
            }
        }
    }
}