using Xunit;

namespace ChallengesTests
{
    public class RotateImageChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/202/";

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
            var counter = 0;
            while (counter < matrix.Length / 2)
            {
                for (int i = counter; i < matrix.Length - counter - 1; i++)
                {
                    var tmp = matrix[counter][i];
                    matrix[counter][i] = matrix[matrix.Length - 1 - i][counter];
                    matrix[matrix.Length - 1 - i][counter] =
                        matrix[matrix.Length - 1 - counter][matrix.Length - 1 - i];

                    matrix[matrix.Length - 1 - counter][matrix.Length - 1 - i] =
                        matrix[i][matrix.Length - 1 - counter];

                    matrix[i][matrix.Length - 1 - counter] = tmp;
                }
                
                counter++;
            }
        }
    }
}