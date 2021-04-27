using Xunit;

namespace ChallengesTests.GoogleQuestions.SortingAndSearching
{
    public class PeakIndexInMountainArrayChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/63/sorting-and-searching-4/3084/";

        [Theory]
        [InlineData(new[] { 0,1,0 }, 1)]
        [InlineData(new[] { 0,2,1,0 }, 1)]
        [InlineData(new[] { 0,10,5,2 }, 1)]
        [InlineData(new[] { 3,4,5,1 }, 2)]
        [InlineData(new[] { 24,69,100,99,79,78,67,36,26,19 }, 2)]
        public void PeakIndexInMountainArrayTests(int[] arr, int expected)
        {
            Assert.Equal(expected, PeakIndexInMountainArray(arr));
        }
        
        public int PeakIndexInMountainArray(int[] arr) {
            var start = 0;
            var end = arr.Length;
            while (start < end) {
                var mid = (start + end) / 2;
                if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1])
                    return mid;
            
                if (arr[mid] > arr[mid - 1]){
                    start = mid;
                }
            
                if (arr[mid] < arr[mid - 1]){
                    end = mid;
                }        
            }
        
            return -1;
        }
    }
}