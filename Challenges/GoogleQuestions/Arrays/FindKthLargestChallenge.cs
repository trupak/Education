using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class FindKthLargestChallenge : IChallenge
    {
        public string Link
            => "";
        
        [Theory]
        [InlineData(new [] {3,2,1,5,6,4}, 2, 5)]
        [InlineData(new [] {3,2,3,1,2,4,5,5,6}, 4, 4)]
        public void FindKthLargestTests(int[] nums, int k, int expected) {
            Assert.Equal(expected, FindKthLargest(nums, k));
        }
        
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[^k];
        }
    }
}