using System;
using Xunit;

namespace ChallengesTests
{
    public class MaximalSquareChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3312/";

        [Fact]
        public void MaximalSquareTests()
        {
            //Assert.Equal(4, MaximalSquare(new []{ new []{ '1', '1'}, new []{ '1', '1'}}));
            Assert.Equal(4, MaximalSquare(new []
            {
                new []{ '1', '0', '1', '0', '0'}, 
                new []{ '1', '0', '1', '1', '1'}, 
                new []{ '1', '1', '1', '1', '1'}, 
                new []{ '1', '0', '0', '1', '0'}, 
            }));
        }

        public int MaximalSquare(char[][] matrix)
        {
            var memo = new int[matrix.Length + 1, matrix[0].Length + 1];
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var maxSize = 0;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        memo[i, j] = Math.Min(Math.Min(memo[i, j-1], memo[i - 1, j]), memo[i - 1, j - 1]) + 1;
                        maxSize = Math.Max(maxSize, memo[i, j]);
                    }
                }
            }
            return maxSize * maxSize;
        }
    }
}