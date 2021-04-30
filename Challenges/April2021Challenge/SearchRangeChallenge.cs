using System;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class SearchRangeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/597/week-5-april-29th-april-30th/3725/";

        [Theory]
        [InlineData(new[] {2, 2}, 2, new [] { 0, 1 })]
        public void SearchRangeTests(int[] nums, int target, int[] expected)
        {
            Assert.Equal(expected, SearchRange(nums, target));
        }
        
        public int[] SearchRange(int[] nums, int target) {
            var found = Array.BinarySearch(nums, target);
            if (found < 0)
                return new[] { -1, -1 };
        
            var mid = found;
            var start = found;
            var end = found;
            while(found >= 0) {
                found = Array.BinarySearch(nums, 0, found, target);
                if (found > 0)
                    start = found;
            }
        
            found = mid;
            while(found >= 0) {
                found = Array.BinarySearch(nums, found + 1, nums.Length - (found + 1), target);
                if (found > 0)
                    end = found;
            }
        
            return new [] { start, end };
        }
    }
}