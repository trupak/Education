using System;
using Xunit;

namespace ChallengesTests
{
    public class MinPathSumChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3303/";
        
        [Fact]
        public void MinPathSumTests()
        {
            var grid = new[]
            {
                new[] {1, 3, 1},
                new[] {1, 5, 1},
                new[] {4, 2, 1},
            };
            Assert.Equal(7, MinPathSum(grid));
        }
        
        public int MinPathSum(int[][] grid)
        {
            var cache = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                cache[i] = new int[grid[i].Length];

            for (int i = grid.Length - 1; i >= 0; i--)
            {
                for (int j = grid[i].Length - 1; j >= 0; j--)
                {
                    if (i == grid.Length - 1 && j == grid[i].Length - 1)
                        cache[i][j] = grid[i][j];
                    else if (i == grid.Length - 1)
                        cache[i][j] = grid[i][j] + cache[i][j + 1];
                    else if (j == grid[i].Length - 1)
                        cache[i][j] = grid[i][j] + cache[i + 1][j];
                    else 
                        cache[i][j] = grid[i][j] + Math.Min(cache[i + 1][j], cache[i][j + 1]);
                }
            }

            return cache[0][0];
        }
        
        // public int MinPathSum(int[][] grid)
        // {
        //     var cache = new int[grid.Length][];
        //     for (int i = 0; i < grid.Length; i++)
        //     {
        //         cache[i] = new int[grid[i].Length];
        //     }
        //     return MinPath(grid, 0, 0, cache);
        // }
        //
        // private int MinPath(int[][] grid, int x, int y, int[][] cache)
        // {
        //     if (x > grid.Length - 1 || y > grid[x].Length - 1)
        //         return int.MaxValue;
        //
        //     if (cache[x][y] != 0)
        //         return cache[x][y];
        //
        //     if (x == grid.Length - 1 && y == grid[x].Length - 1)
        //     {
        //         cache[x][y] = grid[x][y];
        //         return grid[x][y];
        //     }
        //     
        //     return grid[x][y] + Math.Min(MinPath(grid, x + 1, y, cache), MinPath(grid, x, y + 1, cache));
        // }
    }
}