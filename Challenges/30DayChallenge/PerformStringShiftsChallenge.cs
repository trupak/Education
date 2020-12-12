using System;
using Xunit;

namespace ChallengesTests
{
    public class PerformStringShiftsChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3299/";

        [Fact]
        public void StringShiftTests() {
            Assert.Equal("cab", StringShift("abc", new[]
            {
                new[] { 0, 1 },
                new[] { 1, 2 }    
            }));
            
            Assert.Equal("efgabcd", StringShift("abcdefg", new[]
            {
                new[] { 1, 1 },
                new[] { 1, 1 },    
                new[] { 0, 2 },    
                new[] { 1, 3 },    
            }));
            
            Assert.Equal("hcjwpdh", StringShift("wpdhhcj", new[]
            {
                new[] { 0, 7 },
                new[] { 1, 7 },    
                new[] { 1, 0 },    
                new[] { 1, 3 },    
                new[] { 0, 3 },    
                new[] { 0, 6 },    
                new[] { 1, 2 }    
            }));
        }
        
        public string StringShift(string s, int[][] shift)
        {
            var totalShift = 0;
            foreach (var sh in shift)
            {
                if (sh[0] == 0)
                {
                    totalShift -= sh[1];
                }
                else
                {
                    totalShift += sh[1];
                }
            }

            totalShift = totalShift % s.Length;
            
            if (totalShift > 0)
                return s.Substring(s.Length -totalShift, totalShift) + s.Substring(0, s.Length - totalShift);

            if (totalShift < 0)
                return s.Substring(Math.Abs(totalShift)) + s.Substring(0, Math.Abs(totalShift));

            return s;
        }
    }
}