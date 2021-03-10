using System;
using Xunit;

namespace ChallengesTests
{
    public class CheckValidStringChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3301/";
        
        [Theory]
        [InlineData("()", true)]
        [InlineData("(*)", true)]
        [InlineData("(*))", true)]
        [InlineData("(*)((*", false)]
        [InlineData("(())((())()()(*)(*()(())())())()()((()())((()))(*", false)]
        public void CheckValidStringTest(string s, bool expected) {
            Assert.Equal(expected, CheckValidString(s));
        }
        
        public bool CheckValidString(String s) {
            int lo = 0, hi = 0;
            foreach (var c in s) {
                lo += c == '(' ? 1 : -1;
                hi += c != ')' ? 1 : -1;
                if (hi < 0) return false;
                lo = Math.Max(lo, 0);
            }
            return lo == 0;
        }
    }
}