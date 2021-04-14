using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class FindReplaceStringChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/59/array-and-strings/3057/";
        
        [Theory]
        [InlineData("abcd", new[] {0,2}, new[] {"a","cd"},new[] {"eee","ffff"},"eeebffff")]
        [InlineData("abcd", new[] {0,2}, new[] {"ab","ec"},new[] {"eee","ffff"},"eeecd")]
        public void FindReplaceStringTests(string s, int[] indexes, string[] sources, string[] targets, string expected) {
            Assert.Equal(expected,FindReplaceString(s,indexes,sources,targets));
        }
        
        private class Replacement
        {
            public int Length { get; set; }
            public string? Word { get; set; }
        }
        
        public string FindReplaceString(string s, int[] indexes, string[] sources, string[] targets)
        {
            var result = new StringBuilder();
            var replacements = new Dictionary<int, Replacement>();
            for (int i = 0; i < indexes.Length; i++)
            {
                var isValid = true;
                for (int j = indexes[i]; j < sources[i].Length + indexes[i]; j++)
                {
                    if (s[j] != sources[i][j - indexes[i]])
                    {
                        isValid = false;
                        break;
                    }
                }
                
                if (isValid)
                    replacements.Add(indexes[i], new Replacement
                    {
                        Length = sources[i].Length - 1,
                        Word = targets[i]
                    });
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (replacements.ContainsKey(i))
                {
                    result.Append(replacements[i].Word);
                    i += replacements[i].Length;
                }
                else
                {
                    result.Append(s[i]);
                }
            }
            
            return result.ToString();
        }
    }
}