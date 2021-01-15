using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class FindWordsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/46/backtracking/256/";


        [Fact]
        public void FindWordsTests()
        {
            var board = new char[][]
            {
                new char[] {'o','a','a','n'},
                new char[] {'e','t','a','e'},
                new char[] {'i','h','k','r'},
                new char[] {'i','f','l','v'},
            };
            var words = new string[] {"oath", "pea", "eat", "rain"};
            var expected = new string[] {"eat", "oath"};

            FindWordsTestsInner(board, words, expected);
        }
        
        [Fact]
        public void FindWordsTests2()
        {
            var board = new char[][]
            {
                new char[] {'a','b'},
            };
            var words = new string[] {"ba" };
            var expected = new string[] {"ba" };

            FindWordsTestsInner(board, words, expected);
        }
        
        [Fact]
        public void FindWordsTests3()
        {
            var board = new char[][]
            {
                new char[] {'a','a'},
            };
            var words = new string[] {"aaa" };
            var expected = new string[] { };

            FindWordsTestsInner(board, words, expected);
        }
        
        public void FindWordsTestsInner(char[][] board, string[] words, string[] expected)
        {
            var result = FindWords(board, words);
            
            Assert.Equal(expected.Length, result.Count);
            foreach (var r in result)
            {
                Assert.Contains(r, expected);
            }
        }

        
        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (board == null || board.Length == 0)
                return new List<string>();
            
            var cache = new Dictionary<char,List<(int x, int y)>>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (!cache.ContainsKey(board[i][j]))
                    {
                        cache.Add(board[i][j], new List<(int x, int y)>{(x:i,y:j)});
                    }
                    else
                    {
                        cache[board[i][j]].Add((x:i,y:j));
                    }
                }
            }

            var result = new List<string>();
            foreach (var word in words)
            {
                if (FindWord(board, word, cache))
                    result.Add(word);
            }
            
            return result;
        }
        
        public bool FindWord(char[][] board, string word, Dictionary<char,List<(int x, int y)>> cache)
        {
            if (board == null)
                return false;

            if (string.IsNullOrEmpty(word))
                return true;

            if (!cache.ContainsKey(word[0]))
                return false;

            var positions = cache[word[0]];

            foreach (var position in positions)
            {
                if (FindWord(board, word.Substring(1), position.x, position.y, cache))
                    return true;
            }
            
            return false;
        }
        
        public bool FindWord(char[][] board, string word,
            int x, int y,
            Dictionary<char, List<(int x, int y)>> cache)
        {
            if (board == null)
                return false;

            if (string.IsNullOrEmpty(word))
                return true;

            var tmp = board[x][y]; 
            board[x][y] = '#';
            var result1 = false;
            if (x + 1 < board.Length && board[x + 1][y] == word[0])
                result1 = FindWord(board, word.Substring(1), x + 1, y, cache);
            
            var result2 = false;
            if (x - 1 >= 0 && board[x - 1][y] == word[0])
                result2 = FindWord(board, word.Substring(1), x - 1, y, cache);
            
            var result3 = false;
            if (y - 1 >= 0 && board[x][y-1] == word[0])
                result3 = FindWord(board, word.Substring(1), x, y-1, cache);
            
            var result4 = false;
            if (y + 1 < board[0].Length && board[x][y+1] == word[0])
                result4 = FindWord(board, word.Substring(1), x, y+1, cache);

            board[x][y] = tmp;
            
            return result1 || result2 || result3 || result4;
        }
    }
}