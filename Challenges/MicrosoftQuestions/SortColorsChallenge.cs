using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class SortColorsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/193/";

        [Theory]
        [InlineData(new[] { 0 }, new[] {0})]
        [InlineData(new[] { 1 }, new[] {1})]
        [InlineData(new[] { 2,0,1 }, new[] {0,1,2})]
        [InlineData(new[] { 2,0,2,1,1,0 }, new[] {0,0,1,1,2,2})]
        public void SortColorsTests(int[] nums, int[] expected)
        {
            SortColors(nums);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], nums[i]);
            }
        }
        
        private void SortColors(int[] nums)
        {
            var count0 = 0;
            var count1 = 0;
            var count2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count0++;
                else if (nums[i] == 1)
                    count1++;
                else
                    count2++;
            }

            for (int i = 0; i < count0; i++)
            {
                nums[i] = 0;
            }

            for (int i = 0; i < count1; i++)
            {
                nums[count0 + i] = 1;
            }

            for (int i = 0; i < count2; i++)
            {
                nums[count0 + count1 + i] = 2;
            }
        }
    }
}