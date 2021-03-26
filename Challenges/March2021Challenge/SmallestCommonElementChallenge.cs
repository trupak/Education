using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class SmallestCommonElementChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3680/";


        [Theory]
        [InlineData("[[1,2,3,4,5],[2,4,5,8,10],[3,5,7,9,11],[1,3,5,7,9]]", 5)]
        [InlineData("[[1,2,3],[2,3,4],[2,3,5]]", 2)]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", -1)]
        public void SmallestCommonElementTests(string mat, int expected)
        {
            var data = mat.ToMatrix();
            Assert.Equal(SmallestCommonElement(data), expected);
        }
        
        public int SmallestCommonElement(int[][] mat)
        {
            if (mat.Length == 0)
                return -1;

            var cache = new Dictionary<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    var element = mat[i][j];
                    if (!cache.ContainsKey(element))
                        cache.Add(element, 1);
                    else
                        cache[element] = cache[element] + 1;
                }
            }

            foreach (var key in cache.Keys)
            {
                if (cache[key] == mat.Length)
                    return key;
            }

            return -1;
        }
        
        // public int SmallestCommonElement2(int[][] mat)
        // {
        //     if (mat.Length == 0)
        //         return -1;
        //     
        //     var firstRow = mat[0];
        //     for (int i = 0; i < firstRow.Length; i++)
        //     {
        //         var element = firstRow[i];
        //         var searchFailed = false;
        //         for (int j = 1; j < mat.Length; j++)
        //         {
        //             var search = Array.BinarySearch(mat[j], 0, mat[j].Length, element);
        //             if (search < 0)
        //             {
        //                 searchFailed = true;
        //                 break;
        //             }
        //         }
        //
        //         if (!searchFailed)
        //             return element;
        //     }
        //
        //     return -1;
        // }
    }
}