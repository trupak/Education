using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class NumIslandsChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3302/";
        
        [Fact]
        public void NumIslandsTests()
        {
            var land = new[]
            {
                new[] {'1', '1','1','1','0'},
                new[] {'1', '1','0','1','0'},
                new[] {'1', '1','0','0','0'},
                new[] {'0', '0','0','0','0'}
            };
            
            Assert.Equal(1, NumIslands(land));
        }

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public int NumIslands(char[][] grid) {
            var existedIslands = new HashSet<Point>();
            var result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                        continue;
                    
                    if (existedIslands.Contains(new Point { X = i, Y = j }))
                        continue;

                    result++;
                    AddIsland(grid, existedIslands, i, j);
                }
            }

            return result;
        }

        private void AddIsland(char[][] grid, HashSet<Point> existedIslands, int x, int y)
        {
            var point = new Point { X = x, Y = y};
            if (existedIslands.Contains(point))
                return;
            
            if (x > grid.Length - 1 || x < 0 || y > grid[x].Length - 1 || y < 0 || grid[x][y] == '0')
                return;
            
            
            existedIslands.Add(point);
            
            AddIsland(grid, existedIslands, x + 1, y);
            AddIsland(grid, existedIslands, x - 1, y);
            AddIsland(grid, existedIslands, x, y + 1);
            AddIsland(grid, existedIslands, x, y - 1);
        }
    }
}