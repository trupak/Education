using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class CanJumpChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3053/";

        [Theory]
        [InlineData(new [] { 2,3,1,1,4 }, true)]
        [InlineData(new [] { 3,2,1,0,4 }, false)]
        public void CanJumpTests(int[] nums, bool expected)
        {
            Assert.Equal(expected, CanJump(nums));
        }
        
        public bool CanJump(int[] nums)
        {
            var maxJump = 0;
            var counter = 0;
            while (counter <= maxJump && maxJump < nums.Length)
            {
                maxJump = Math.Max(maxJump, counter + nums[counter]);
                counter++;
            }
            return maxJump >= nums.Length - 1;
        }
    }
}