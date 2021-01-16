using System;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SearchChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/191/";

        [Theory]
        [InlineData(new int[]{4,5,6,7,0,1,2},0,4)]
        [InlineData(new int[]{4,5,6,7,0,1,2},3,-1)]
        [InlineData(new int[]{1},0,-1)]
        [InlineData(new int[]{5,1,3},5,0)]
        [InlineData(new int[]{4,5,6,7,8,1,2,3},8,4)]
        [InlineData(new int[]{1,3,5},2,-1)]
        [InlineData(new int[]{1,3,5},5,2)]
        [InlineData(new int[]{4,5,6,7,0,1,2},2,6)]
        public void SearchTests(int[] nums, int target, int expected)
        {
            var result = Search(nums, target);
            Assert.Equal(expected, result);
        }
        
        public int Search(int[] nums, int target) {
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;;

            
            return Search(nums, target, 0, nums.Length - 1);
        }
        
        public int Search(int[] nums, int target, int start, int end)
        {
            if (start == end)
                return nums[start] == target ? start : -1;
            if (start == end - 1)
                return nums[start] == target ? start : nums[end] == target ? end : -1;

            int mid = (start + end) / 2;

            if (nums[start] == target)
                return start;

            if (nums[end] == target)
                return end;
            if (nums[mid] == target)
                return mid;
            
            if (target > nums[start] && target < nums[mid])
            {
                return Search(nums, target, start, mid);
            } else if (target > nums[start] && target > nums[mid])
            {
                if (nums[start] < nums[mid])
                    return Search(nums, target, mid, end);
                else
                    return Search(nums, target, start, mid);
            }
            else if (target < nums[start] && target < nums[mid])
            {
                if (nums[mid] < nums[end])
                    return Search(nums, target, start, mid);
                else
                    return Search(nums, target, mid, end);
            }
            else
                return Search(nums, target, mid, end);
        }
    }
}