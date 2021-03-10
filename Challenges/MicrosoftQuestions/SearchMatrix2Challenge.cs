using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SearchMatrix2Challenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/195/";

        [Fact]
        public void SearchMatrixTests()
        {
            var matrix = new[]
            {
                new[] {1, 4, 7, 11, 15},
                new[] {2, 5, 8, 12, 19},
                new[] {3, 6, 9, 16, 22},
                new[] {10, 13, 14, 17, 24},
                new[] {18, 21, 23, 26, 30},
            };

            var result = SearchMatrix(matrix, 5);
            Assert.True(result);
        }
        
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var x = 0;
            var y = 0;

            var prevY = 0;
            var prevX = 0;
            while (true)
            {
                
                if (matrix[x][y] == target)
                    return true;
                if (matrix[x][y] < target)
                {
                    if (y == matrix[0].Length - 1 || prevY > y)
                    {
                        if (x == matrix.Length - 1)
                            return false;
                        
                        prevY = y;
                        prevX = x;
                        x++;
                    }
                    else
                    {
                        prevY = y;
                        prevX = x;
                        y++;
                    }
                }
                else
                {
                    if (y > 0 && (prevY > y || prevX < x))
                    {
                        prevY = y;
                        prevX = x;
                        y--;
                    }
                    else {
                        if (x == matrix.Length - 1)
                            return false;
                        
                        prevY = y;
                        prevX = x;
                        x++;
                    }
                }
            }
        }
    }
}