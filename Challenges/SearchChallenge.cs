using Xunit;

namespace ChallengesTests
{
    public class SearchChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3304/";
        
        [Theory]
        [InlineData(new[] {4,5,6,7,0,1,2}, 0, 4)]
        public void SearchTests(int[] nums, int target, int expected) {
            Assert.Equal(expected, Search(nums, target));
        }
        
        // public int Search(int[] nums, int target)
        // {
        //     var isBreak = false;
        //     for (int i = 0; i < nums.Length; i++)
        //     {
        //         if (nums[i] == target)
        //             return i;
        //         if (nums[i] < target)
        //             continue;
        //         if (isBreak)
        //             return -1;
        //     }
        //
        //     return -1;
        // }
        
        public int Search(int[] nums, int target) {
            int start = 0, end = nums.Length - 1;
            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] >= nums[start]) {
                    if (target >= nums[start] && target < nums[mid]) end = mid - 1;
                    else start = mid + 1;
                }
                else {
                    if (target <= nums[end] && target > nums[mid]) start = mid + 1;
                    else end = mid - 1;
                }
            }
            return -1;
        }
    }
}