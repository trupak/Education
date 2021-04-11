using System;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class LongestIncreasingPathChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3703/";
        
        [Theory]
        [InlineData(new[]
        {
            "9,9,4",
            "6,6,8",
            "2,1,1"
        }, 4)]
        [InlineData(new[]
        {
            "3,4,5",
            "3,2,6",
            "2,2,1"
        }, 4)]
        [InlineData(new[]
        {
            "1"
        }, 1)]
        public void LongestIncreasingPathTests(string[] matrix, int expected) {
            Assert.Equal(expected, LongestIncreasingPath(matrix.ToMatrix()));
        }

        public int LongestIncreasingPath(int[][] matrix)
        {
            var cache = new int[matrix.Length][];
            for (int i = 0; i < cache.Length; i++)
                cache[i] = new int[matrix[0].Length];
            
            var ans = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    ans = Math.Max(ans, LongestIncreasingPath(matrix, i, j, cache));
                }
            }

            return ans;
        }

        private int LongestIncreasingPath(int[][] matrix, int i, int j, int[][] cache)
        {
            if (cache[i][j] > 0)
                return cache[i][j];

            var dirs = new (int x, int y)[]
            {
                (1, 0),
                (0, 1),
                (-1, 0),
                (0, -1)
            };
            
            for (int k = 0; k < dirs.Length; k++)
            {
                var x = i + dirs[k].x;
                var y = j + dirs[k].y;
                if (x >= 0 && x < matrix.Length && y >= 0 && y < matrix[0].Length &&
                    matrix[x][y] > matrix[i][j])
                {
                    cache[i][j] = Math.Max(cache[i][j], LongestIncreasingPath(matrix, x, y, cache));
                }
            }

            return ++cache[i][j];
        }
    }
}