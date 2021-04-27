using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.SortingAndSearching
{
    public class InsertChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/63/sorting-and-searching-4/445/";
        
        [Theory]
        [InlineData("[[1,3],[6,9]]", new [] {2,5},"[[1,5],[6,9]]")]
        [InlineData("[[0,5],[9,12]]", new [] {7,16},"[[0,5],[7,16]]")]
        [InlineData("[[3,5],[12,15]]", new [] {6,6},"[[3,5],[6,6],[12,15]]")]
        [InlineData("[[1,2],[3,5],[6,7],[8,10],[12,16]]", new [] {4,8},"[[1,2],[3,10],[12,16]]")]
        [InlineData("[]", new [] {5,7},"[[5,7]]")]
        [InlineData("[[1,5]]", new [] {2,3}, "[[1,5]]")]
        [InlineData("[[1,5]]", new [] {2,7}, "[[1,7]]")]
        [InlineData("[[1,5]]", new [] {6,8}, "[[1,5],[6,8]")]
        [InlineData("[[6,8]]", new [] {1,5}, "[[1,5],[6,8]")]
        [InlineData("[[1,5]]", new [] {0,3}, "[[0,5]")]
        [InlineData("[[0,5],[8,9]]", new [] {3,4}, "[[0,5],[8,9]]")]
        [InlineData("[[0,10],[14,14],[15,20]]", new [] {11,11}, "[[0,10],[11,11],[14,14],[15,20]]")]
        [InlineData("[[3,6],[9,9],[11,13],[14,14],[16,19],[20,22],[23,25],[30,34],[41,43],[45,49]]", new [] {29,32}, "[[3,6],[9,9],[11,13],[14,14],[16,19],[20,22],[23,25],[29,34],[41,43],[45,49]]")]
        public void InsertTests(string intervals, int[] newInterval, string expected)
        {
            Assert.Equal(expected.ToMatrix(), Insert(intervals.ToMatrix(), newInterval));
        }
        
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
                return new[]
                {
                    newInterval
                };

            var result = new List<int[]>();
            
            if (intervals[intervals.Length - 1][1] < newInterval[0])
            {
                result = intervals.ToList();
                result.Add(newInterval);
                return result.ToArray();
            }
            
            if (intervals[0][0] > newInterval[1])
            {
                result.Add(newInterval);
                result.AddRange(intervals);
                return result.ToArray();
            }
            
            var newStart = newInterval[0];
            var newEnd = Math.Max(intervals[0][1], newInterval[1]);
            var inMerge = newInterval[0] < intervals[0][0];
            var intervalAdded = false;
            for (int i = 0; i < intervals.Length; i++)
            {
                if (!inMerge)
                {
                    if (newInterval[0] >= intervals[i][0] &&
                        newInterval[0] <= intervals[i][1] &&
                        newInterval[1] >  intervals[i][1])
                    {
                        newStart = intervals[i][0];
                        newEnd = newInterval[1];
                        inMerge = true;
                    } else if (newInterval[0] < intervals[i][0] &&
                               newInterval[1] >=  intervals[i][0])
                    {
                        newStart = newInterval[0];
                        newEnd = Math.Max(newInterval[1], intervals[i][1]);
                        inMerge = true;
                    }
                    else
                    {
                        if (newInterval[0] < intervals[i][0] && !intervalAdded)
                        {
                            intervalAdded = true;
                            result.Add(new [] { newInterval[0], newInterval[1]});
                        }
                        
                        result.Add(new [] { intervals[i][0], intervals[i][1]});

                        if (newInterval[0] >= intervals[i][0] &&
                            newInterval[1] <= intervals[i][1])
                        {
                            intervalAdded = true;
                        }
                    }
                }
                else
                {
                    if (newEnd < intervals[i][0])
                    {
                        result.Add(new [] { newStart, newEnd});
                        result.Add(new [] { intervals[i][0], intervals[i][1]});
                        inMerge = false;
                        intervalAdded = true;
                    }
                    else
                    {
                        newEnd = Math.Max(newEnd, intervals[i][1]);
                    }
                }
            }

            if (inMerge && !intervalAdded)
            {
                result.Add(new [] { newStart, newEnd});
            }
            
            return result.ToArray();
        }
    }
}