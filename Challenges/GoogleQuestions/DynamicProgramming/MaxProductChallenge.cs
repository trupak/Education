using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.DynamicProgramming
{
    public class MaxProductChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/64/dynamic-programming-4/3087/";

        [Theory]
        [InlineData(new[] { 2,3,-2,4 }, 6)]
        [InlineData(new[] { -2,0,-1 }, 0)]
        public void MaxProductTests(int[] nums, int expected)
        {
            Assert.Equal(expected, MaxProduct(nums));
        }
        
        public int MaxProduct(int[] nums) {
            if (nums.Length == 1)
                return nums[0];
        
            var fullSum = 1;
            var result = 0;
            var start = 0;
            var end = 0;
            var isPrevZero = false;
            for(var j = 0; j < nums.Length; j++) {
                if (nums[j] == 0){
                    result = Math.Max(result, 0);
                    result = Math.Max(result, FindMaxInPart(nums, start, end, fullSum));
                    fullSum = 1;                
                    isPrevZero = true;
                } else {
                    if (isPrevZero) {
                        start = j;
                        isPrevZero = false;
                    }
                
                    end = j;
                    fullSum = fullSum * nums[j];
                }                        
            }
        
            result = Math.Max(result, FindMaxInPart(nums, start, end, fullSum));
        
            return result;
        }
    
        private int FindMaxInPart(int[] nums, int start, int end, int fullSum){
            if (start == end)
                return nums[start];
        
            if (fullSum > 0) 
                return fullSum;
        
            var i = end;
            var divider = nums[i];
        
            while(divider > start && i > 0) {
                i--;
                divider *= nums[i];
            }
        
            var result = fullSum / divider;
            i = start;
            divider = nums[i];
            while(divider > 0 && i < end) {
                i++;
                divider *= nums[i];
            }
        
            result = Math.Max(result, fullSum / divider);
        
            return result;
        }
    }
}