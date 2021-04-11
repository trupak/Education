using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class LengthOfLongestSubstringTwoDistinctChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3054/";

        [Theory]
        [InlineData("eceba", 3)]
        [InlineData("ccaabbb", 5)]
        public void LengthOfLongestSubstringTwoDistinctTests(string s, int expected)
        {
            Assert.Equal(expected, LengthOfLongestSubstringTwoDistinct(s));
        }
        
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            var result = 1;
            var left = 0;
            var right = 0;

            var currentLetters = new Dictionary<char, int>();
            var maxDistinctCount = 2;
            while (left < s.Length && right < s.Length)
            {
                if (currentLetters.Count < maxDistinctCount)
                {
                    if (currentLetters.ContainsKey(s[right]))
                    {
                        currentLetters[s[right]]++;
                    }
                    else
                    {
                        currentLetters.Add(s[right], 1);
                    }
                    right++;
                    result = Math.Max(result, right - left);
                }
                else if (currentLetters.Count == maxDistinctCount &&
                         currentLetters.ContainsKey(s[right]))
                {
                    currentLetters[s[right]]++;
                    right++;
                    result = Math.Max(result, right - left);
                }
                else
                {
                    result = Math.Max(result, right - left);

                    while (left < s.Length && currentLetters.Count >= maxDistinctCount)
                    {
                        if (currentLetters.ContainsKey(s[left]))
                        {
                            currentLetters[s[left]]--;
                            if (currentLetters[s[left]] == 0)
                                currentLetters.Remove(s[left]);
                        }

                        left++;
                    }
                }
            }
            
            return result;
        }
    }
}