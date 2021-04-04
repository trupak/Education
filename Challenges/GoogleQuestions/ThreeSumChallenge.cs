using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions
{
    public class ThreeSumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3049/";

        [Fact]
        public void ThreeSumTests()
        {
            var nums = new[]
            {
                -1, 0, 1, 2, -1, -4
            };
            var expectedResult = new List<List<int>>
            {
                new()
                {
                    -1,-1,2
                },
                new()
                {
                    -1,0,1
                }
            };
            var result = ThreeSum(nums);
            Assert.Equal(expectedResult.Count, result.Count);
            foreach (var e1 in expectedResult)
            {
                // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
                Assert.Contains(result, x =>
                {
                    // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
                    return x.All(y => e1.Contains(y));
                });
            }
            
        }
        
        public IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums);
            var res = new List<IList<int>>();
            for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
                if (i == 0 || nums[i - 1] != nums[i]) {
                    twoSumII(nums, i, res);
                }
            return res;
        }
        void twoSumII(int[] nums, int i, List<IList<int>> res) {
            int lo = i + 1, hi = nums.Length - 1;
            while (lo < hi) {
                int sum = nums[i] + nums[lo] + nums[hi];
                if (sum < 0) {
                    ++lo;
                } else if (sum > 0) {
                    --hi;
                } else {
                    res.Add(new List<int>{ nums[i], nums[lo++], nums[hi--]});
                    while (lo < hi && nums[lo] == nums[lo - 1])
                        ++lo;
                }
            }
        }
    }
}