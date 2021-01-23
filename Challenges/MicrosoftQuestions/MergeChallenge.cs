using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    
    public class MergeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/258/";

        [Theory]
        [InlineData(new int[] { 0}, 0, new int[] {1}, 1, new int[] {1})]
        [InlineData(new int[] { 1,2,3,0,0,0}, 3, new int[] {2,5,6}, 3, new int[] {1,2,2,3,5,6})]
        public void MergeTests(int[] nums1, int m, int[] nums2, int n, int[] expected)
        {
            Merge(nums1, m, nums2, n);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], nums1[i]);
            }
        }
        
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var index = nums1.Length - 1;
            m--;
            n--;
            while (m >= 0 || n >= 0)
            {
                if (m < 0)
                {
                    nums1[index] = nums2[n];
                    n--;
                } else if (n < 0)
                {
                    nums1[index] = nums1[m];
                    m--;
                }
                else if (nums1[m] > nums2[n])
                {
                    nums1[index] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[index] = nums2[n];
                    n--;
                }

                index--;
            }
        }
    }
}