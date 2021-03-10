using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests
{
    public class GroupAnagramsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/200/";

        [Fact]
        public void GroupAnargamsTests()
        {
            GroupAnargamsTests2(new[]
            {
                "eat", "tea", "tan", "ate", "nat", "bat"
            }, new List<List<string>>()
            {
                new List<string>
                {
                    "nat", "tan"
                },
                new List<string>
                {
                    "ate", "eat", "tea"
                },
                new List<string>
                {
                    "bat"
                }
            });
        }

        private void GroupAnargamsTests2(string[] strs, List<List<string>> expected)
        {
            var result = GroupAnagrams(strs);
            Assert.Equal(expected.Count, result.Count);
            foreach (var extectedAnagram in expected)
            {
                var actualAnagram = result.FirstOrDefault(
                    x => 
                        x.Count == extectedAnagram.Count &&
                        x.All(y => extectedAnagram.Contains(y)));
                
                Assert.NotNull(actualAnagram);
            }
        }
        
        private IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var cache = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var charArray = str.ToCharArray();
                Array.Sort(charArray);

                var str2 = new String(charArray);
                if (!cache.ContainsKey(str2))
                {
                    cache.Add(str2, new List<string>
                    {
                        str
                    });
                }
                else
                {
                    cache[str2].Add(str);
                }
            }
            
            return cache.Values.ToList();
        }
    }
}