using System;
using Xunit;

namespace ChallengesTests
{
    public class LengthOfLisChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/156/";

        [Theory]
        [InlineData(new[] {10,9,2,5,3,7,101,18}, 4)]
        [InlineData(new[] {0,1,0,3,2,3}, 4)]
        [InlineData(new[] {7,7,7,7,7,7,7}, 1)]
        public void LengthOfLisTests(int[] nums, int expected)
        {
            Assert.Equal(expected,LengthOfLIS(nums));
        }
        
        // ReSharper disable once InconsistentNaming
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            int len = 0;
            for (int i2 = 0; i2 < nums.Length; i2++)
            {
                var num = nums[i2];
                int i = Array.BinarySearch(dp, 0, len, num);
                if (i < 0) {
                    i = -(i + 1);
                }
                dp[i] = num;
                if (i == len) {
                    len++;
                }
            }
            return len;
        }
    }
}