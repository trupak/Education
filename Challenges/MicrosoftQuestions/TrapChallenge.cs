using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class TrapChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/211/";

        [Theory]
        [InlineData(new int[]
        {
            0,1,0,2,1,0,1,3,2,1,2,1
        }, 6)]
        [InlineData(new int[]
        {
            4,2,0,3,2,5
        }, 9)]
        public void TrapTests(int[] height, int expected)
        {
            Assert.Equal(expected, Trap(height));
        }

        public int Trap(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int ans = 0;
            int left_max = 0, right_max = 0;
            while (left < right) {
                if (height[left] < height[right]) {
                    if (height[left] >= left_max)
                    {
                        left_max = height[left];
                    }
                    else
                    {
                        ans += left_max - height[left];
                    }
                    ++left;
                }
                else {
                    if (height[right] >= right_max)
                    {
                        right_max = height[right];
                    }
                    else
                    {
                        ans += right_max - height[right];
                    }
                    --right;
                }
            }
            return ans;
        }
        
        public int TrapBruteForce(int[] height)
        {
            var result = 0;
            for (int i = 1; i < height.Length - 1; i++)
            {
                var maxLeft = Max(height, 0, i);
                var maxRight = Max(height, i, height.Length);

                if (maxLeft > height[i] && maxRight > height[i])
                    result += Math.Min(maxLeft, maxRight) - height[i];
            }
            
            return result;
        }

        public int Max(int[] heights, int start, int end)
        {
            var max = 0;
            for (int i = start; i < end; i++)
            {
                if (heights[i] > max)
                    max = heights[i];
            }

            return max;
        }
    }
}