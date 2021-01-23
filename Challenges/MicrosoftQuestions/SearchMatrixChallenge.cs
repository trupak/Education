using System;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SearchMatrixChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/154/";

        [Fact]
        public void SearchMatrixTests()
        {
            var matrix = new int[][]
            {
                new int[] {1},
                new int[] {3}
            };
            
            Assert.False(SearchMatrix(matrix, 2));
            
            matrix = new int[][]
            {
                new int[] {1, 3, 5, 7},
                new int[] {10, 11, 16, 20},
                new int[] {123, 30, 34, 60},
            };

            Assert.False(SearchMatrix(matrix, 13));
            Assert.True(SearchMatrix(matrix, 3));
            
            
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (target < matrix[0][0])
                return false;
            if (target > matrix[matrix.Length - 1][matrix[matrix.Length - 1].Length - 1])
                return false;
            var targetRow = -1;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] <= target && target <= matrix[i][matrix[i].Length - 1])
                {
                    targetRow = i;
                    break;
                }
            }

            return targetRow == -1 ? false : Array.BinarySearch(matrix[targetRow], target) >= 0;
        }
    }
}