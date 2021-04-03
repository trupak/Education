using System;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class NextPermutationChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3050/";

        [Theory]
        [InlineData(new[] { 1,2,3 }, new[] { 1,3,2 })]
        [InlineData(new[] { 3,2,1 }, new[] { 1,2,3 })]
        [InlineData(new[] { 1,1,5 }, new[] { 1,5,1 })]
        [InlineData(new[] { 1 }, new[] { 1 })]
        [InlineData(new[] { 1,3,2 }, new[] { 2,1,3 })]
        [InlineData(new[] { 2,3,1 }, new[] { 3,1,2 })]
        [InlineData(new[] { 1,5,1 }, new[] { 5,1,1 })]
        public void NextPermutationTests(int[] nums, int[] expected) {
            NextPermutation(nums);
            Assert.Equal(nums, expected);
        }
        
        private void NextPermutation(int[] nums)
        {
            var counter = 0;
            for (int i = nums.Length - 1; i >= 1; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    counter = i;
                    break;
                }
            }
            
            if (counter == 0)
                Array.Reverse(nums);
            else
            {
                var counter2 = counter;
                while (counter2 < nums.Length - 1
                       && nums[counter - 1] < nums[counter2] 
                       && nums[counter - 1] != nums[counter2])
                {
                    if (nums[counter - 1] >= nums[counter2 + 1])
                        break;
                    counter2++;
                }

                var tmp = nums[counter - 1];
                nums[counter - 1] = nums[counter2];
                nums[counter2] = tmp;
                
                Array.Reverse(nums,counter, nums.Length - counter);
            }
        }
    }
}