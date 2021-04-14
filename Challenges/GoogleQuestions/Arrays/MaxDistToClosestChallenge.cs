using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class MaxDistToClosestChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/59/array-and-strings/3058/";
        
        [Theory]
        [InlineData(new[] {1,0,0,0,1,0,1}, 2)]
        [InlineData(new[] {1,0,0,0,0,1,0,1}, 2)]
        [InlineData(new[] {1,0,0,0,0,0,1,0,1}, 3)]
        [InlineData(new[] {1,0,0,0}, 3)]
        [InlineData(new[] {1,0}, 1)]
        public void MaxDistToClosestTests(int[] seats, int expected) {
            Assert.Equal(expected, MaxDistToClosest(seats));
        }
        
        public int MaxDistToClosest(int[] seats)
        {
            var result = 0;
            var left = -1;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    if (left == -1)
                    {
                        result = i;
                    }
                    else
                    {
                        result = Math.Max(result, (i - left) / 2);
                    }

                    left = i;
                }
                else
                {
                    if (i == seats.Length - 1)
                    {
                        result = Math.Max(result, seats.Length - left - 1);
                    }
                }
            }
            
            return result;
        }
    }
}