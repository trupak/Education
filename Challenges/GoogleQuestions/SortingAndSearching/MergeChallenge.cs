using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.SortingAndSearching
{
    public class MergeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/63/sorting-and-searching-4/450/";

        [Theory]
        [InlineData("[[1,3],[2,6],[8,10],[15,18]]", "[[1,6],[8,10],[15,18]]")]
        [InlineData("[[1,4],[0,4]]", "[[0,4]]")]
        public void MergeTests(string interlas, string expected)
        {
            Assert.Equal(expected.ToMatrix(), Merge(interlas.ToMatrix()));
        }
        
        public int[][] Merge(int[][] intervals)
        {
           var result = new List<int[]>();

           intervals = intervals.ToList().OrderBy(x => x[0]).ToArray();
           
            var end = intervals[0][1];
            var start = intervals[0][0];
            for (var i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] > end)
                {
                    result.Add(new [] { start, end });
                    start = intervals[i][0];
                    end = intervals[i][1];
                }
                else
                {
                    end = Math.Max(end, intervals[i][1]);
                }
            }
            
            result.Add(new [] {start, end });
            
            return result.ToArray();
        }
    }
}