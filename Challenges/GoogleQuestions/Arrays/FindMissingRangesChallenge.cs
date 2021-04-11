using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class FindMissingRangesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3055/";

        [Theory]
        [InlineData(new [] {0,1,3,50,75},0,99, new [] { "2","4->49","51->74","76->99" })]
        [InlineData(new int[0],1,1, new [] { "1" })]
        [InlineData(new []{-1},-1,-1, new string[0])]
        [InlineData(new []{-1},-2,-1, new []{"-2"})]
        [InlineData(new int[0],-3,-1, new [] { "-3->-1" })]
        public void FindMissingRangesTests(int[] nums, int lower, int upper, string[] expected)
        {
            var result = FindMissingRanges(nums, lower, upper);
            Assert.Equal(expected, result.ToArray());
        }
        
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            var result = new List<string>();
            if (nums.Length == 0)
            {
                if (lower == upper)
                    result.Add(lower.ToString());
                else
                    result.Add($"{lower}->{upper}");

                return result;
            }

            var currentPointer = lower;
            var numsPointer = 0;
            while (currentPointer <= upper)
            {
                while (numsPointer < nums.Length - 1 && nums[numsPointer] < currentPointer)
                    numsPointer++;

                if (nums[numsPointer] == currentPointer)
                {
                    currentPointer++;
                    continue;
                }
                
                if (nums[numsPointer] < currentPointer)
                {
                    if (currentPointer == upper)
                        result.Add(currentPointer.ToString());
                    else
                        result.Add($"{currentPointer}->{upper}");
                    
                    break;
                }

                if (currentPointer == nums[numsPointer] - 1)
                {
                    result.Add(currentPointer.ToString());
                    currentPointer = nums[numsPointer] + 1;
                }
                else
                {
                    result.Add($"{currentPointer}->{nums[numsPointer] - 1}");
                    currentPointer = nums[numsPointer] + 1;
                }
            }
            return result;
        }
    }
}