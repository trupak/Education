using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class RomanToIntChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/198/";
        
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToIntTests(string s, int expected) {
            Assert.Equal(expected,RomanToInt(s));
        }
        
        public int RomanToInt(string s)
        {
            var convert = new Dictionary<string, int>
            {
                {"I", 1},
                {"II", 2},
                {"III", 3},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000},
            };
            var current = string.Empty;
            var result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                current += s[i];
                if (i != s.Length - 1 && !convert.ContainsKey(current + s[i + 1]))
                {
                    result += convert[current];
                    current = string.Empty;
                }
                else if (i == s.Length - 1)
                {
                    result += convert[current];
                }
            }
            
            return result;
        }
    }
}