using System;
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
            int m = nums1.Length;
            int n = nums2.Length;
            if (m > n) { // to ensure m<=n
                int[] temp = nums1; nums1 = nums2; nums2 = temp;
                int tmp = m; m = n; n = tmp;
            }
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax) {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                if (i < iMax && nums2[j-1] > nums1[i]){
                    iMin = i + 1; // i is too small
                }
                else if (i > iMin && nums1[i-1] > nums2[j]) {
                    iMax = i - 1; // i is too big
                }
                else { // i is perfect
                    int maxLeft = 0;
                    if (i == 0) { maxLeft = nums2[j-1]; }
                    else if (j == 0) { maxLeft = nums1[i-1]; }
                    else { maxLeft = Math.Max(nums1[i-1], nums2[j-1]); }
                    if ( (m + n) % 2 == 1 ) { return maxLeft; }

                    int minRight = 0;
                    if (i == m) { minRight = nums2[j]; }
                    else if (j == n) { minRight = nums1[i]; }
                    else { minRight = Math.Min(nums2[j], nums1[i]); }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }
    }
}