using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SpiralOrderChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/178/";

        [Fact]
        public void SpiralOrderTests()
        {
            var matrix = new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            };
            var result = SpiralOrder(matrix);
            var expected = new List<int> {1, 2, 3, 6, 9, 8, 7, 4, 5};
            Assert.Equal(expected.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }

            matrix = new int[][]
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12}
            };
            result = SpiralOrder(matrix);
            expected = new List<int> {1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7};
            Assert.Equal(expected.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
        
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var counter = 0;
            var result = new List<int>();
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            while (counter <= matrix.Length / 2 && counter <= matrix[0].Length / 2)
            {
                if (result.Count == rows*cols)
                    break;
                
                for (int i = counter; i < cols - counter; i++)
                    result.Add(matrix[counter][i]);

                if (result.Count == rows*cols)
                    break;
                
                for (int i = counter + 1; i < rows - counter; i++)
                    result.Add(matrix[i][cols - counter - 1]);
                
                if (result.Count == rows*cols)
                    break;
                
                for (int i = cols - counter - 2; i >= counter; i--)
                    result.Add(matrix[rows - counter - 1][i]);
                
                if (result.Count == rows*cols)
                    break;
                
                for (int i = rows - counter - 2; i > counter; i--)
                    result.Add(matrix[i][counter]);

                counter++;
            }
            
            return result;
        }
    }
}