using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class PacificAtlanticChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3684/";

        
        [Theory]
        [InlineData("[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]","[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]")]
        public void PacificAtlanticTests(string mat, string expected)
        {
            var matrix = mat.ToMatrix();
            var expectedResult = expected.ToMatrix();
            var result = PacificAtlantic(matrix);

            Assert.Equal(expectedResult.Length, result.Count);
            
            for (int i = 0; i < expectedResult.Length; i++)
            {
                // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
                Assert.Contains(result, x =>
                {
                    if (x == null) throw new ArgumentNullException(nameof(x));
                    for (int j = 0; j < expectedResult[i].Length; j++)
                    {
                        if (x[j] != expectedResult[i][j])
                            return false;
                    }

                    return true;
                });
            }
        }

        
        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            var result = new List<IList<int>>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (CanFlow(matrix, i, j, ToPacific) && CanFlow(matrix, i,j, ToAtlantic))
                        result.Add(new List<int>{ i, j});
                }
            }
            
            return result;
        }

        public bool ToPacific(int[][] matrix, int x, int y)
        {
            return x == 0 || y == 0;
        }
        
        public bool ToAtlantic(int[][] matrix, int x, int y)
        {
            return x == matrix.Length - 1 || y == matrix[0].Length - 1;
        }

        public bool CanFlow(int[][] matrix, int x2, int y2, Func<int[][],int,int,bool> border)
        {
            if (border(matrix, x2, y2))
                return true;
            
            var fillMatrix = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                fillMatrix[i] = new int[matrix[i].Length];

            var cache = new List<IList<int>> {new List<int> {x2, y2}};

            while (cache.Count > 0)
            {
                var newCache = new List<IList<int>>();
                foreach (var point in cache)
                {
                    var x = point[0];
                    var y = point[1];
                    
                    if (border(matrix, x, y))
                        return true;
                    
                    //down
                    if (x < matrix.Length - 1 && fillMatrix[x + 1][y] == 0 && matrix[x][y] >= matrix[x + 1][y])
                    {
                        fillMatrix[x + 1][y]++;
                        newCache.Add(new List<int>{ x+1, y});
                    }
                    
                    //up
                    if (x > 0 && fillMatrix[x - 1][y] == 0 && matrix[x][y] >= matrix[x - 1][y])
                    {
                        fillMatrix[x - 1][y]++;
                        newCache.Add(new List<int>{ x-1, y});
                    }
                    
                    //right
                    if (y < matrix[x].Length - 1 && fillMatrix[x][y + 1] == 0 && matrix[x][y] >= matrix[x][y+1])
                    {
                        fillMatrix[x][y+1]++;
                        newCache.Add(new List<int>{ x, y+1});
                    }
                    
                    //left
                    if (y > 0 && fillMatrix[x][y-1] == 0 && matrix[x][y] >= matrix[x][y-1])
                    {
                        fillMatrix[x][y-1]++;
                        newCache.Add(new List<int>{ x, y-1});
                    }
                }
                cache.Clear();
                cache.AddRange(newCache);
            }
            
            return false;
        }
    }
}