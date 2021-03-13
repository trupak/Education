using System;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class MaxSubArrayChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/174/";

        [Theory]
        [InlineData(new[] {-2,1,-3,4,-1,2,1,-5,4}, 6)]
        [InlineData(new[] {1}, 1)]
        [InlineData(new[] {5,4,-1,7,8}, 23)]
        [InlineData(new[] {-2,-3,-1}, -1)]
        public void MaxSubArrayTests(int[] nums, int expected)
        {
            Assert.Equal(expected, MaxSubArray(nums));
        }
        
        
        // public int MaxSubArray(int[] nums) {
        //     int n = nums.Length;
        //     int currSum = nums[0], maxSum = nums[0];
        //
        //     for(int i = 1; i < n; ++i) {
        //         currSum = Math.Max(nums[i], currSum + nums[i]);
        //         maxSum = Math.Max(maxSum, currSum);
        //     }
        //     return maxSum;
        // }
        
        public int MaxSubArray(int[] nums) {
            int n = nums.Length, maxSum = nums[0];
            for(int i = 1; i < n; ++i) {
                if (nums[i - 1] > 0) nums[i] += nums[i - 1];
                maxSum = Math.Max(nums[i], maxSum);
            }
            return maxSum;
        }
        
        // ReSharper disable once UnusedMember.Local
        private int MaxSubArray2(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];

            if (end - start == 1)
                return Math.Max(nums[start] + nums[end], Math.Max(nums[start], nums[end]));

            var mid = (end + start) / 2;
            var leftMax = MaxSubArray2(nums, start, mid);
            var rightMax = MaxSubArray2(nums, mid + 1, end);

            var rightSum = 0;
            var rightMidMax = int.MinValue;
            var leftSum = 0;
            var leftMidMax = int.MinValue;
            for (int i = mid; i <= end; i++)
            {
                rightSum += nums[i];
                if (rightSum > rightMidMax)
                    rightMidMax = rightSum;
            }

            for (int i = mid - 1; i >= start; i--)
            {
                leftSum += nums[i];
                if (leftSum > leftMidMax)
                    leftMidMax = leftSum;
            }

            var midResult = 0;
            if (leftMidMax < 0 && rightMidMax < 0)
            {
                midResult = Math.Max(leftMidMax, rightMidMax);
            }
            else
            {
                if (rightMidMax > 0)
                    midResult += rightMidMax;

                if (leftMidMax > 0)
                    midResult += leftMidMax;    
            }
            
            return Math.Max(midResult, Math.Max(leftMax, rightMax));
        }
    }
}