using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class MinWindowChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/345/";

        [Theory]
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("a", "a", "a")]
        [InlineData("bba", "ab", "ba")]
        [InlineData("cabwefgewcwaefgcf", "cae", "cwae")]
        public void MinWindowTests(string s, string t, string expected)
        {
            Assert.Equal(expected, MinWindow(s,t));
        }
        
        public string MinWindow(string s, string t)
        {
            var cache = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (!cache.ContainsKey(t[i]))
                    cache.Add(t[i], 1);
                else
                    cache[t[i]]++;
            }

            var left = 0;
            var right = 0;
            var foundLength = 0;
            var resultLeft = 0;
            var resultRight = s.Length + 2;
            while (left < s.Length && !cache.ContainsKey(s[left]))
            {
                left++;
                right++;
            }
            while (left < s.Length && right < s.Length)
            {
                if (cache.ContainsKey(s[right]))
                {
                    cache[s[right]]--;
                    if (cache[s[right]] >= 0)
                        foundLength++;
                    
                    if (foundLength == t.Length)
                    {
                        while (left < s.Length && foundLength == t.Length)
                        {
                            if (cache.ContainsKey(s[left]))
                            {
                                if (cache[s[left]] < 0)
                                {
                                    cache[s[left]]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            left++;
                        }
                        
                        if (resultRight - resultLeft > right - left)
                        {
                            resultLeft = left;
                            resultRight = right;
                        }

                        cache[s[left]]++;
                        left++;
                        foundLength--;
                        while (left < s.Length && !cache.ContainsKey(s[left]))
                        {
                            left++;
                        }
                    }

                    right++;
                }
                else
                {
                    right++;
                }
            }

            if (resultRight == s.Length + 2)
                return "";

            return s.Substring(resultLeft, resultRight - resultLeft + 1);
        }
    }
}