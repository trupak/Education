using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class FindMaxLengthChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3298/";

        [Theory]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1, 0 }, 2)]
        public void FindMaxLengthTests(int[] nums, int result)
        {
            Assert.Equal(result, FindMaxLength(nums));
        }
        
        // public int FindMaxLength(int[] nums)
        // {
        //     var globalMaxLength = 0;
        //     for (int i = 0; i < nums.Length - 1; i++)
        //     {
        //         var sum = nums[i] == 0 ? -1 : 1;
        //         var maxLength = 0;
        //         var length = 1;
        //         for (int j = i + 1; j < nums.Length; j++)
        //         {
        //             sum += nums[j] == 0 ? -1 : 1;
        //             length++;
        //             if (sum == 0)
        //                 maxLength = length;
        //         }
        //
        //         globalMaxLength = Math.Max(globalMaxLength, maxLength);
        //     }
        //
        //     return globalMaxLength;
        // }
        
        public int FindMaxLength(int[] nums)
        {
            var dict = new Dictionary<int, int>
            {
                {0, -1}
            };
            var count = 0;
            var maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count += nums[i] == 0 ? -1 : 1;
                if (!dict.ContainsKey(count))
                {
                    dict.Add(count, i);
                }
                else
                {
                    maxLength = Math.Max(maxLength, i - dict[count]);
                }
            }

            return maxLength;
        }
    }
}