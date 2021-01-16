using System.Runtime.InteropServices;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class FindMedianSortedArraysChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/890/";

        [Theory]
        [InlineData(new int[] {1,3,5,7,9}, new int[] {2,4,6,8}, 5)]
        [InlineData(new int[] {1,2,3,8,9}, new int[] {4,5,6,7}, 5)]
        [InlineData(new int[] {1,3}, new int[] {2}, 2)]
        [InlineData(new int[] {1,2}, new int[] {3,4}, 2.5)]
        [InlineData(new int[] {0,0}, new int[] {0,0}, 0)]
        [InlineData(new int[] {1}, new int[] {}, 1)]
        [InlineData(new int[] {}, new int[] {2}, 2)]
        public void FindMedianSortedArraysTests(int[] nums1, int[] nums2, double expected)
        {
            Assert.Equal(expected, FindMedianSortedArrays(nums1, nums2));
        }
        
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            return 0;
        }
    }
}