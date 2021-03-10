using System;
using Xunit;

namespace ChallengesTests
{
    public class IsPalindromeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/162/";
        
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData("0P", false)]
        public void IsPalindromeTests(string s, bool expected) {
            Assert.Equal(expected, IsPalindrome(s));
        }
        
        public bool IsPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;

            while (start < end)
            {
                while (start < end && !Char.IsLetter(s[start]) && !Char.IsDigit(s[start]))
                    start++;
                
                while (start < end && !Char.IsLetter(s[end])&& !Char.IsDigit(s[end]))
                    end--;
                
                if (start == end)
                    return true;

                if (!string.Equals(s[start].ToString(), s[end].ToString(), StringComparison.OrdinalIgnoreCase))
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}