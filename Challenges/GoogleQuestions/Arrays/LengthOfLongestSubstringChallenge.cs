using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class LengthOfLongestSubstringChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3047/";
        
        [Theory]
        [InlineData("", 0)]
        [InlineData("pwwkew", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("abcabcbb", 3)]
        [InlineData("abba", 2)]
        [InlineData("dvdf", 3)]
        [InlineData("uqinntq", 4)]
        [InlineData("ckilbkd", 5)]
        [InlineData("wobgrovw", 6)]
        public void LengthOfLongestSubstringTests(string s, int expected) {
            Assert.Equal(expected, LengthOfLongestSubstring(s));
        }
        
        public int LengthOfLongestSubstring(string s)
        {
            var dic = new SortedList<char, int>();
            var result = 0;
            var current = 0;
            var first = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], i);
                    current++;
                }
                else
                {
                    var counter = dic[s[i]] + 1;
                    while (counter != dic[s[counter]] && counter < i)
                        counter++;
                    first = Math.Max(counter, first);
                    if (s[i - 1] == s[i])
                        first = i;
                    current = i - first + 1;
                    dic[s[i]] = i;
                }
                
                result = Math.Max(result, current);
            }

            return result;
        }
    }
}