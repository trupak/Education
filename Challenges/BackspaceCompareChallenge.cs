using System;
using Xunit;

namespace ChallengesTests
{
    public class BackspaceCompareChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3291/";
        
        [Theory]
        [InlineData("ab##", "c#d#", true)]
        public void BackspaceCompareTest(string a, string b, bool expected)
        {
            Assert.Equal(expected,BackspaceCompare(a, b));
        }

        public bool BackspaceCompare(string s, string t)
        {
            var sIndex = s.Length - 1;
            var tIndex = t.Length - 1;
            while(sIndex >= 0)
            {
                if (NextChar(s, ref sIndex) !=  NextChar(t, ref tIndex))
                    return false;
            }
        
            return true;
        }
        
        private char NextChar(string T, ref int index) {
            var skipCount = 0;
            while(true){
                if (index < 0)
                    return Char.MinValue;

                if (T[index] == '#'){
                    skipCount++;
                    index--;
                }
                else if (skipCount > 0)
                {
                    index--;
                    skipCount--;
                }  
                else {
                    return T[index--];    
                }                
            }
        }
    }
}