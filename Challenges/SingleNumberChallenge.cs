using Xunit;

namespace ChallengesTests
{
    public class SingleNumberChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/208/";

        [Theory]
        [InlineData(new[] {2,2,1}, 1)]
        [InlineData(new[] {4,1,2,1,2}, 4)]
        [InlineData(new[] {1}, 1)]
        public void SingleNumberTests(int[] nums, int expected)
        {
            Assert.Equal(expected, SingleNumber(nums));
        }
        
        public int SingleNumber(int[] nums)
        {
            var result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }
    }
}