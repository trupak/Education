using System;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class LongestPalindromeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/180/";

        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        [InlineData("a", "a")]
        [InlineData("ac", "a")]
        public void LongestPalindromeTests(string s, string expected)
        {
            Assert.Equal(expected, LongestPalindrome(s));
        }

        public string LongestPalindrome(string s) {
            if (s == null || s.Length < 1) return "";
            int start = 0, size = 0;
            for (int i = 0; i < s.Length; i++) {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > size) {
                    start = i - (len - 1) / 2;
                    size = len;
                }
            }
            return s.Substring(start, size);
        }

        private int expandAroundCenter(string s, int left, int right) {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R]) {
                L--;
                R++;
            }
            return R - L - 1;
        }
    }
}