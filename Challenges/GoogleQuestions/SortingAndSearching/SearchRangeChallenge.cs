using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.SortingAndSearching
{
    public class SearchRangeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/63/sorting-and-searching-4/3081/";

        [Theory]
        [InlineData(new[] {5,7,7,8,8,10}, 8,new []{3,4})]
        [InlineData(new[] {1,4}, 4,new []{1,1})]
        [InlineData(new[] {1}, 1,new []{0,0})]
        [InlineData(new[] {5,7,7,8,8,10}, 6,new []{-1,-1})]
        public void SearchRangeTests(int[] nums, int target, int[] expected)
        {
            Assert.Equal(expected, SearchRange(nums, target));
        }
        
        public int[] SearchRange(int[] nums, int target) {
            var search = Array.BinarySearch(nums, 0, nums.Length, target);
            if (search < 0)
                return new[] {-1,-1};

            var start = search;
            while(start >= 0 && nums[start] == target){
                start--;
            }

            var end = search;
            while(end <= nums.Length - 1 && nums[end] == target)
                end++;
                
            return new[] { start + 1, end - 1};
        }
    }
}