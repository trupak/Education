using System;
using System.Linq;

namespace ChallengesTests
{
    public static class ChallengeExtensions
    {
        public static int[][] ToMatrix(this string[] arr)
        {
            var matrix = new int[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                matrix[i] = arr[i].Split(',')
                    .Select(x => Convert.ToInt32(x)).ToArray();
            }

            return matrix;
        }
    }
}