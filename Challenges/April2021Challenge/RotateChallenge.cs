using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class RotateChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3720/";
        
        [Fact]
        public void RotateTests()
        {
            var image = new[]
            {
                new[] {5, 1, 9, 11},
                new[] {2, 4, 8, 10},
                new[] {13, 3, 6, 7},
                new[] {15, 14, 12, 16}
            };
            
            Rotate(image);
            
            var expectedResult = new[]
            {
                new[] {15,13,2,5},
                new[] {14,3,4,1},
                new[] {12,6,8,9},
                new[] {16,7,10,11}
            };

            for (int i = 0; i < image.Length; i++)
            {
                for (int j = 0; j < image[i].Length; j++)
                {
                    Assert.Equal(expectedResult[i][j], image[i][j]);
                }
            }
        }

        private void Rotate(int[][] matrix)
        {
            double max = ((double)matrix.Length) / 2;
            for(var i = 0; i < max; i++){
                for(var j = i; j < matrix.Length - 1 - i; j++){
                    Swap(matrix, i, j);
                }
            }
        }

        private void Swap(int[][] matrix, int row, int col){
        
            var tmp = matrix[row][col];
            matrix[row][col] = matrix[matrix.Length - 1 - col][row];
            matrix[matrix.Length - 1 - col][row] = matrix[matrix.Length - 1 - row][matrix.Length - 1 - col];
            matrix[matrix.Length - 1 - row][matrix.Length - 1 - col] = matrix[col][matrix.Length - 1 - row];
            matrix[col][matrix.Length - 1 - row] = tmp;
        }
    }
}