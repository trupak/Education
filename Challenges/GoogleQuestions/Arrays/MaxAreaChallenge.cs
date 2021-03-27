using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class MaxAreaChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3048/";
        
        [Theory]
        [InlineData(new [] {1,8,6,2,5,4,8,3,7}, 49)]
        [InlineData(new [] {1,1}, 1)]
        [InlineData(new [] {4,3,2,1,4}, 16)]
        [InlineData(new [] {1,2,1}, 2)]
        [InlineData(new [] {2,3,10,5,7,8,9}, 36)]
        public void MaxAreaTests(int[] height, int expected) {
            Assert.Equal(expected, MaxArea(height));
        }
        
        public int MaxArea(int[] height)
        {
            if (height.Length < 2)
                return 0;
            
            var left = 0;
            var right = height.Length - 1;
            var maxArea = 0;

            while (left != right)
            {
                var area = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, area);
                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return maxArea;
        }
    }
}