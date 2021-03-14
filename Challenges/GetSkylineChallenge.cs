using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests
{
    public class GetSkylineChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/157/";

        [Fact]
        public void GetSkylinetests()
        {
            var buildings = new[]
            {
                new[] {2, 9, 10},
                new[] {3, 7, 15},
                new[] {5, 12, 12},
                new[] {15, 20, 10},
                new[] {19, 24, 8}
            };

            var expected = new List<List<int>>()
            {
                new() {2, 10},
                new() {3, 15},
                new() {7, 12},
                new() {12, 0},
                new() {15, 10},
                new() {20, 8},
                new() {24, 0},
            };

            var result = GetSkyline(buildings);
            Assert.Equal(expected.Count, result.Count);
            foreach (var expectedPoint in expected)
            {
                var resultPoint = result
                    .FirstOrDefault(x => x[0] == expectedPoint[0] && x[1] == expectedPoint[1]);
                Assert.NotNull(resultPoint);
            }
        }

        /**
       *  Divide-and-conquer algorithm to solve skyline problem,
       *  which is similar with the merge sort algorithm.
       */
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            int n = buildings.Length;
            var output = new List<IList<int>>();

            // The base cases
            if (n == 0) return output;
            if (n == 1)
            {
                int xStart = buildings[0][0];
                int xEnd = buildings[0][1];
                int y = buildings[0][2];

                output.Add(new List<int>() {xStart, y});
                output.Add(new List<int>() {xEnd, 0});
                // output.add(new int[]{xStart, y});
                // output.add(new int[]{xEnd, 0});
                return output;
            }

            // If there is more than one building,
            // recursively divide the input into two subproblems.
            IList<IList<int>> leftSkyline, rightSkyline;
            var leftData = new int[n / 2][];
            Array.Copy(buildings, 0, leftData, 0, n / 2);
            var rightData = new int[buildings.Length - leftData.Length][];
            Array.Copy(buildings, n / 2, rightData, 0, buildings.Length - leftData.Length);
            leftSkyline = GetSkyline(leftData);
            rightSkyline = GetSkyline(rightData);

            // Merge the results of subproblem together.
            return MergeSkylines(leftSkyline, rightSkyline);
        }

        /**
       *  Merge two skylines together.
       */
        public IList<IList<int>> MergeSkylines(IList<IList<int>> left, IList<IList<int>> right)
        {
            int nL = left.Count, nR = right.Count;
            int pL = 0, pR = 0;
            int currY = 0, leftY = 0, rightY = 0;
            int x, maxY;
            IList<IList<int>> output = new List<IList<int>>();

            // while we're in the region where both skylines are present
            while ((pL < nL) && (pR < nR))
            {
                var pointL = left[pL];
                var pointR = right[pR];
                // pick up the smallest x
                if (pointL[0] < pointR[0])
                {
                    x = pointL[0];
                    leftY = pointL[1];
                    pL++;
                }
                else
                {
                    x = pointR[0];
                    rightY = pointR[1];
                    pR++;
                }

                // max height (i.e. y) between both skylines
                maxY = Math.Max(leftY, rightY);
                // update output if there is a skyline change
                if (currY != maxY)
                {
                    UpdateOutput(output, x, maxY);
                    currY = maxY;
                }
            }

            // there is only left skyline
            AppendSkyline(output, left, pL, nL, currY);

            // there is only right skyline
            AppendSkyline(output, right, pR, nR, currY);

            return output;
        }

        /**
       * Update the final output with the new element.
       */
        internal static void UpdateOutput(IList<IList<int>> output, int x, int y)
        {
            // if skyline change is not vertical -
            // add the new point
            if (output.Count == 0 || output[output.Count - 1][0] != x)
                output.Add(new List<int>() {x, y});
            // if skyline change is vertical -
            // update the last point
            else
            {
                output[output.Count - 1][1] = y;
            }
        }

        /**
        *  Append the rest of the skyline elements with indice (p, n)
        *  to the final output.
        */
        internal static void AppendSkyline(IList<IList<int>> output, IList<IList<int>> skyline,
            int p, int n, int currY)
        {
            while (p < n)
            {
                var point = skyline[p];
                int x = point[0];
                int y = point[1];
                p++;

                // update output
                // if there is a skyline change
                if (currY != y)
                {
                    UpdateOutput(output, x, y);
                    currY = y;
                }
            }
        }
    }
}