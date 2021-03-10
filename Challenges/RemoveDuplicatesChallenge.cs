using Xunit;

namespace ChallengesTests
{
    public class RemoveDuplicatesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/257/";
        
        [Theory]
        [InlineData(new[] {1,1,2}, new[] {1,2})]
        [InlineData(new[] {1,1}, new[] {1})]
        [InlineData(new[] {1,2}, new[] {1,2})]
        [InlineData(new[] {0,0,1,1,1,2,2,3,3,4}, new[] {0,1,2,3,4})]
        public void RemoveDuplicatesTests(int[] nums, int[] expected)
        {
            var result = RemoveDuplicates(nums);
            Assert.Equal(expected.Length, result);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], nums[i]);
            }
        }
        
        public int RemoveDuplicates(int[] nums) {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++) {
                if (nums[j] != nums[i]) {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}