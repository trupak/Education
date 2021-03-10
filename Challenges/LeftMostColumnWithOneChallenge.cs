using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class LeftMostColumnWithOneChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3306/";

        [Fact]
        public void LeftMostColumnWithOneTests()
        {
            var matrix = new[,]
            {
                {0, 0},
                {0, 0}
            };
            var binaryMatrix = new BinaryMatrix(matrix);
            Assert.Equal(-1, LeftMostColumnWithOne(binaryMatrix));
            
            matrix = new[,]
            {
                {0, 0},
                {1, 1}
            };
            binaryMatrix = new BinaryMatrix(matrix);
            Assert.Equal(0, LeftMostColumnWithOne(binaryMatrix));
            
            matrix = new[,]
            {
                {0, 0},
                {0, 1}
            };
            binaryMatrix = new BinaryMatrix(matrix);
            Assert.Equal(1, LeftMostColumnWithOne(binaryMatrix));
            
            matrix = new[,]
            {
                {0, 0, 0, 1},
                {0, 0, 1, 1},
                {0, 1, 1, 1}
            };
            binaryMatrix = new BinaryMatrix(matrix);
            Assert.Equal(1, LeftMostColumnWithOne(binaryMatrix));
        }
        
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            var dimensions = binaryMatrix.Dimensions();
            var result = -1;
            var x = 0;
            var y = dimensions[1] - 1;
            while (x < dimensions[0] && y >= 0)
            {
                if (binaryMatrix.Get(x, y) == 0)
                {
                    x++;
                }
                else
                {
                    result = y--;
                }
            }
            return result;
        }
        
        // public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        // {
        //     var dimensions = binaryMatrix.Dimensions();
        //     var result = -1;
        //     var endPosition = dimensions[1] - 1;
        //     for (int i = 0; i < dimensions[0]; i++)
        //     {
        //         var searchResult = BinarySearch(binaryMatrix, i, 1, 0, endPosition);
        //         if (searchResult == -1)
        //             continue;
        //         if (searchResult == 0)
        //             return 0;
        //
        //         result = searchResult;
        //         endPosition = searchResult - 1;
        //     }
        //     return result;
        // }
        //
        // public int BinarySearch(BinaryMatrix matrix, 
        //     int row, int value, int startIndex, int endIndex)
        // {
        //     while (startIndex != endIndex)
        //     {
        //         var middle = (startIndex + endIndex) / 2;
        //         var middleValue = matrix.Get(row, middle);
        //         if (middleValue < value)
        //             startIndex = startIndex == middle ? middle + 1: middle;
        //         else
        //             endIndex = middle;
        //     }
        //
        //     return matrix.Get(row, startIndex) != value ? - 1: startIndex;
        // }
    }
}