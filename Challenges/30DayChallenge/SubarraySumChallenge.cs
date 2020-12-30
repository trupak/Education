using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class SubarraySumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3307/";

        [Theory]
        [InlineData(new int[] { 1, 1, 1 }, 2, 2)]
        [InlineData(new int[] { 1, 2, 3 }, 3, 2)]
        [InlineData(new int[] { 1 }, 0, 0)]
        [InlineData(new int[] { 0,0 }, 0, 3)]
        public void SubarraySumTests(int[] nums, int k, int expected)
        {
            Assert.Equal(expected, SubarraySum(nums, k));
        }
        
        public int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            var cache = new Dictionary<int,int>
            {
                {0, 1}
            };
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (cache.ContainsKey(sum - k))
                    count += cache[sum - k];

                if (cache.ContainsKey(sum))
                    cache[sum] = cache[sum] + 1;
                else
                    cache.Add(sum, 1);
            }
            
            return count;
        }
        
        // public int SubarraySum(int[] nums, int k)
        // {
        //     var result = 0;
        //     for (int i = 0; i < nums.Length; i++)
        //     {
        //         if (nums[i] == k)
        //             result++;
        //         
        //         var sumRight = nums[i];
        //         var rightIndex = i;
        //         while (rightIndex < nums.Length-1)
        //         {
        //             rightIndex++;
        //             sumRight += nums[rightIndex];
        //             if (sumRight == k)
        //                 result++;
        //         }
        //     }
        //     
        //     return result;
        // }
    }
}