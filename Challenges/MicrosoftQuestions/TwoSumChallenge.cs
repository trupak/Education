using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class TwoSumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/173/";

        [Theory]
        [InlineData(new [] {2,7,11,5}, 9, new[] {0,1})]
        [InlineData(new [] {0,4,3,0}, 0, new[] {0,3})]
        public void TwoSumTests(int[] nums, int target, int[] expected)
        {
            var result = TwoSum(nums, target);
            var sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += nums[result[i]];
            }
            Assert.Equal(sum, target);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var cache = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var sumToTarget = target - nums[i];
                if (cache.ContainsKey(sumToTarget) && cache[sumToTarget] != i)
                    return new[] {cache[sumToTarget], i};
                
                cache.Add(nums[i], i);
            }
            
            return null;
        }
    }
}