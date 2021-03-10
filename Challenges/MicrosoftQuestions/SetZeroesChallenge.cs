using System.Linq;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SetZeroesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/203/";
        
        [Fact]
        public void SetZeroesTests()
        {
            var matrix = new[]
            {
                new[] {1, 1, 1},
                new[] {1, 0, 1},
                new[] {1, 1, 1},
            };
            SetZeroes(matrix);
            var emptyRows = new[] { 1 };
            var emptyCols = new[] { 1 };
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (emptyCols.Contains(i) || emptyRows.Contains(j))
                    {
                        Assert.Equal(0, matrix[i][j]);
                    }
                }
                
            }
        }
        
        private void SetZeroes(int[][] matrix)
        {
            var emptyRows = new int[matrix.Length];
            var emptyCols = new int[matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        emptyRows[i] = 1;
                        emptyCols[j] = 1;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != 0 &&
                        (emptyRows[i] == 1 ||
                        emptyCols[j] == 1))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
}