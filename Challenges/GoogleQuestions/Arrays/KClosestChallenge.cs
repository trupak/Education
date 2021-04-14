using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class KClosestChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/59/array-and-strings/3062/";


        [Theory]
        [InlineData("[[1,3],[-2,2]]", 1, "[[-2,2]]")]
        [InlineData("[[3,3],[5,-1],[-2,4]]", 2, "[[3,3],[-2,4]]")]
        public void KClosestTests(string pointsMatrix, int k, string expected)
        {
            var points = pointsMatrix.ToMatrix();
            var expectedMatrix = expected.ToMatrix();
            var result = KClosest(points, k);
            Assert.Equal(expectedMatrix, result);
        }

        class Point : IComparable<Point>
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public double ToOrigin => Math.Sqrt(X * X + Y * Y);

            public int CompareTo(Point? other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return ToOrigin.CompareTo(other.ToOrigin);
            }
        }
        
        public int[][] KClosest(int[][] points, int k)
        {
            var heap = new MinHeap<Point>();
            for (int i = 0; i < points.Length; i++)
            {
                heap.Add(new Point(points[i][0], points[i][1]));
            }

            var result = new int[k][];
            for (int i = 1; i <= k; i++)
            {
                var point = heap.ExtractDominating();
                result[i - 1] = new[] {point.X, point.Y};
            }
            
            return result;
        }
    }
}