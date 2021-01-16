using System;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class FindMinChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/206/";

        [Theory]
        [InlineData(new int[] {3,4,5,1,2}, 1)]
        [InlineData(new int[] {4,5,6,7,0,1,2}, 0)]
        [InlineData(new int[] {11,13,15,17}, 11)]
        [InlineData(new int[] {10,1,10,10,10}, 1)]
        [InlineData(new int[] {0,0,1,1,2,0},0)]
        public void FindMinTests(int[] nums, int expected)
        {
            var result = FindMin(nums);
            Assert.Equal(expected, result);
        }
        
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            
            if (nums.Length > 1 && nums[0] < nums[nums.Length - 1])
                return nums[0];

            var duplicateCount = 0;
            while (nums.Length - 1 - duplicateCount > 0)
            {
                if (nums[nums.Length - 1 - duplicateCount] == nums[0])
                {
                    duplicateCount++;
                    continue;
                }
                
                break;
            }
            
            if (nums.Length - 1 - duplicateCount > 1 && nums[0] < nums[nums.Length - 1 - duplicateCount])
                return nums[0];
            
            return FindMin(nums, 0, nums.Length - 1 - duplicateCount);
        }

        public int FindMin(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];
            if (start == end - 1)
                return Math.Min(nums[start], nums[end]);
            int mid = (start + end) / 2;
            if (nums[mid] < nums[start])
                return FindMin(nums, start, mid);
            else
                return FindMin(nums, mid, end);
        }
    }
}