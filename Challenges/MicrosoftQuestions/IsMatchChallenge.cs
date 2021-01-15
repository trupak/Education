using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class IsMatchChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/46/backtracking/155/";

        [Theory]
        [InlineData("a", "aa", false)]
        [InlineData("aa", "*", true)]
        [InlineData("cb", "?a", false)]
        [InlineData("adceb", "*a*b", true)]
        [InlineData("acdcb", "a*c?b", false)]
        public void IsMatchTests(string s, string p, bool expected)
        {
            Assert.Equal(expected,IsMatch(s, p));
        }

        Dictionary<string, bool> map = new Dictionary<string, bool>();
        public bool IsMatch3(string text, string pattern) {
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(text);
            string key = text + " | " + pattern;
            if (map.ContainsKey(key)) return map[key];

            var first_match = (!string.IsNullOrEmpty(text) &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));
    
            if (pattern.Length >= 2 && pattern[1] == '*'){
                var val = (IsMatch3(text, pattern.Substring(2)) ||
                           (first_match && IsMatch3(text.Substring(1), pattern)));
                map.Add(key, val);
                return val;
            } else {
                var val = first_match && IsMatch3(text.Substring(1), pattern.Substring(1));
                map.Add(key, val);
                return val;
            }
        }
        
        public bool IsMatch2(string text, string pattern) {
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(text);
            var first_match = (!string.IsNullOrEmpty(text) &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));

            if (pattern.Length >= 2 && pattern[1] == '*'){
                return (IsMatch2(text, pattern.Substring(2)) ||
                        (first_match && IsMatch2(text.Substring(1), pattern)));
            } else {
                return first_match && IsMatch2(text.Substring(1), pattern.Substring(1));
            }
        }
        
        public bool IsMatch(string s, string p) {
            int sLen = s.Length, pLen = p.Length;
            int sIdx = 0, pIdx = 0;
            int starIdx = -1, sTmpIdx = -1;

            while (sIdx < sLen) {
                // If the pattern caracter = string character
                // or pattern character = '?'
                if (pIdx < pLen && (p[pIdx] == '?' || p[pIdx] == s[sIdx])){
                    ++sIdx;
                    ++pIdx;
                }
                // If pattern character = '*'
                else if (pIdx < pLen && p[pIdx] == '*') {
                    // Check the situation
                    // when '*' matches no characters
                    starIdx = pIdx;
                    sTmpIdx = sIdx;
                    ++pIdx;
                }
                // If pattern character != string character
                // or pattern is used up
                // and there was no '*' character in pattern 
                else if (starIdx == -1) {
                    return false;
                }
                // If pattern character != string character
                // or pattern is used up
                // and there was '*' character in pattern before
                else {
                    // Backtrack: check the situation
                    // when '*' matches one more character
                    pIdx = starIdx + 1;
                    sIdx = sTmpIdx + 1;
                    sTmpIdx = sIdx;
                }
            }

            // The remaining characters in the pattern should all be '*' characters
            for(int i = pIdx; i < pLen; i++)
                if (p[i] != '*') return false;
            return true;
        }
    }
}