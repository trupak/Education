using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class NumSubmatrixSumTargetChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3711/";
        
        [Theory]
        [InlineData("[[0,1,0],[1,1,1],[0,1,0]]", 0, 4)]
        [InlineData("[[1,-1],[-1,1]]", 0, 5)]
        public void NumSubmatrixSumTargetTests(string matrix, int target, int expected) {
            Assert.Equal(expected, NumSubmatrixSumTarget(matrix.ToMatrix(), target));
        }
        
        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            var result = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    result += Calc(matrix, i, j, target);
                }
            }

            return result;
        }

        private int Calc(int[][] matrix, int x, int y, int target)
        {
            var result = 0;
            var sums = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                sums[i] = new int[matrix[i].Length];

            for (int i = x; i < matrix.Length; i++)
            {
                var rowSum = 0;
                for (int j = y; j < matrix[i].Length; j++)
                {
                    rowSum += matrix[i][j];
                    sums[i][j] = rowSum;
                    
                    if (i > 0)
                        sums[i][j] += sums[i - 1][j];
                    
                    if (sums[i][j] == target)
                        result++;
                }
            }

            return result;
        }
    }
}