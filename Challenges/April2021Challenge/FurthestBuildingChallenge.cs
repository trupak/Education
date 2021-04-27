using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class FurthestBuildingChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3721/";

        [Theory]
        [InlineData(new[] {4,12,2,7,3,18,20,3,19}, 10, 2, 7)]
        [InlineData(new[] {14,3,19,3}, 17, 0, 3)]
        public void FurthestBuildingTests(int[] heights, int bricks, int ladders, int expected)
        {
            Assert.Equal(expected, FurthestBuilding(heights, bricks, ladders));
        }
        
        public int FurthestBuilding(int[] heights, int bricks, int ladders) {
            var heap = new MaxHeap<int>();
            var result = 0;
            for(var i = 1; i < heights.Length; i++) {  
                var h = heights[i] - heights[i-1];
                if (h <= 0)
                {
                    result++;
                    continue;
                }
            
                if (bricks >= h) {
                    bricks -= h;
                    heap.Add(h);
                    result++;
                    continue;
                }
            
                if (ladders <= 0 && h > bricks)
                    break;
            
                heap.Add(h);
                bricks -= h;
                while(bricks < 0 && heap.Count > 0) {
                    var maxHeight = heap.ExtractDominating();
                    bricks += maxHeight;
                    ladders--;
                }
            
                if (bricks >= 0)
                    result++;
            }
            
            return result;
        }    
    }
}