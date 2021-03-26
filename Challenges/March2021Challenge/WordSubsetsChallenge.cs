using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class WordSubsetsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3685/";
        
        [Theory]
        [InlineData(new [] {"amazon","apple","facebook","google","leetcode"}, new[] {"e","o"}, new[] {"facebook","google","leetcode"})]
        [InlineData(new [] {"amazon","apple","facebook","google","leetcode"}, new[] {"l","e"}, new[] {"apple","google","leetcode"})]
        [InlineData(new [] {"amazon","apple","facebook","google","leetcode"}, new[] {"e","oo"}, new[] {"facebook","google"})]
        [InlineData(new [] {"amazon","apple","facebook","google","leetcode"}, new[] {"lo","eo"}, new[] {"google","leetcode"})]
        [InlineData(new [] {"amazon","apple","facebook","google","leetcode"}, new[] {"ec","oc","ceo"}, new[] {"facebook","leetcode"})]
        public void WordSubsetsTests(string[] a, string[] b, string[] expected)
        {
            var result = WordSubsets(a, b);
            Assert.Equal(expected.Length, result.Count);
            foreach (var word in result)
                Assert.Contains(word, expected);
        }

        public IList<string> WordSubsets(string[] a, string[] b)
        {
            var result = new List<string>();
            var cache = new Dictionary<char, int>();
            for (int i = 'a'; i <= 'z'; i++)
            {
                cache.Add((char)i, 0);
            }
            
            foreach (var wordB in b)
            {
                var wordCache = new Dictionary<char, int>();
                foreach (var letterB in wordB)
                {
                    if (!wordCache.ContainsKey(letterB))
                        wordCache.Add(letterB, 1);
                    else
                        wordCache[letterB]++;
                }

                foreach (var letter in wordCache.Keys)
                {
                    if (wordCache[letter] > cache[letter])
                        cache[letter] = wordCache[letter];
                }
            }
            
            foreach (var wordA in a)
            {
                if (IsSubset(wordA, cache))
                    result.Add(wordA);
            }
            
            return result;
        }

        private bool IsSubset(string word, Dictionary<char, int> cache)
        {
            var wordCache = new Dictionary<char, int>();
            foreach (var letter in word)
            {
                if (!cache.ContainsKey(letter))
                    return false;
                
                if (!wordCache.ContainsKey(letter))
                    wordCache.Add(letter, 1);
                else
                    wordCache[letter]++;
            }

            foreach (var letter in cache.Keys)
            {
                if (cache[letter] == 0)
                    continue;
                
                if (!wordCache.ContainsKey(letter) || wordCache[letter] < cache[letter])
                    return false;
            }

            return true;
        }
    }
}