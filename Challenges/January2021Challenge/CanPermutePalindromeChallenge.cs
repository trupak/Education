using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.January2021Challenge
{
    public class CanPermutePalindromeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/january-leetcoding-challenge-2021/579/week-1-january-1st-january-7th/3588/";

        [Theory]
        [InlineData("code", false)]
        [InlineData("aab", true)]
        [InlineData("carerac", true)]
        public void CanPermutePalindromeTests(string s, bool expected)
        {
            Assert.Equal(expected, CanPermutePalindrome(s));
        }
        
        public bool CanPermutePalindrome(string s)
        {
            var dictionary = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary.Contains(s[i]))
                    dictionary.Remove(s[i]);
                else
                    dictionary.Add(s[i]);
            }

            return dictionary.Count < 2;
        }
    }
}