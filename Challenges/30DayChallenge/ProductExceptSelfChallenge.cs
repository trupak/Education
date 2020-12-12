using Xunit;

namespace ChallengesTests
{
    public class ProductExceptSelfChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3300/";

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
        public void ProductExceptSelfTests(int[] nums, int[] expectedResult)
        {
            var result = ProductExceptSelf(nums);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }
        
        // public int[] ProductExceptSelf(int[] nums)
        // {
        //     var left = new Dictionary<int, int>
        //     {
        //         { 0,1 }
        //     };
        //     var right = new Dictionary<int, int>
        //     {
        //         { nums.Length - 1,1 }
        //     };
        //
        //     for (int i = 1; i < nums.Length; i++)
        //     {
        //         left.Add(i, left[i-1] * nums[i-1]);
        //         right.Add(nums.Length - 1 - i, right[nums.Length - i] * nums[nums.Length - i]);
        //     }
        //
        //     var result = new int[nums.Length];
        //     for (int i = 0; i < result.Length; i++)
        //     {
        //         result[i] = left[i] * right[i];
        //     }
        //
        //     return result;
        // }
        
        public int[] ProductExceptSelf(int[] nums)
        {
            var length = nums.Length;
            var answer = new int[length];
            answer[0] = 1;

            for (var i = 1; i < length; i++)
                answer[i] = answer[i - 1] * nums[i - 1];

            var r = 1;
            for (var i = length - 1; i >= 0; i--) {

                answer[i] = answer[i] * r;
                r *= nums[i];
            }

            return answer;
        }
    }
}