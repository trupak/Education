using System.Net.NetworkInformation;
using Xunit;

namespace ChallengesTests
{
    public class CanJumpChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3310/";
        
        [Theory]
        [InlineData(new[] {2,3,1,1,4}, true)]
        [InlineData(new[] {3,2,1,0,4}, false)]
        [InlineData(new[] {2,0,0}, true)]
        [InlineData(new[] {1,2,3}, true)]
        [InlineData(new[] {1,1,2,2,0,1,1}, true)]
        public void CanJumpTests(int[] nums, bool expected) {
            Assert.Equal(expected, CanJump(nums));
        }
        
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1)
                return true;
            
            var maxJump = nums[0];
            var jumpStart = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (i > maxJump + jumpStart)
                    return false;

                if (jumpStart + maxJump >= nums.Length - 1)
                    return true;
                
                if (nums[i] + i < maxJump + jumpStart)
                    continue;

                maxJump = nums[i];
                jumpStart = i;
            }
            
            if (jumpStart + maxJump >= nums.Length - 1)
                return true;

            return false;
        }
    }
}