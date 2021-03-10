using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class LastStoneWeightChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3297/";
        
        [Theory]
        [InlineData(new[] { 2,7,4,1,8,1 }, 1)]
        [InlineData(new[] { 1, 3 }, 2)]
        [InlineData(new[] { 3,7,8 }, 2)]
        [InlineData(new[] { 9,3,2,10 }, 0)]
        public void LastStoneWeightTest(int[] data, int expected) {
            Assert.Equal(expected, LastStoneWeight(data));
        }

        // public int LastStoneWeight(int[] stones)
        // {
        //     var sortedList = stones.ToList();
        //     sortedList.Sort();
        //
        //     while (sortedList.Count > 1)
        //     {
        //         var newStone = Math.Abs(sortedList[^1] - sortedList[^2]);
        //         sortedList.RemoveAt(sortedList.Count - 1);
        //         sortedList.RemoveAt(sortedList.Count - 1);
        //         if (newStone != 0)
        //             sortedList.InsertIntoSortedList(newStone);    
        //     }
        //
        //     return sortedList.Count switch
        //     {
        //         0 => 0,
        //         1 => sortedList[0],
        //         _ => 0
        //     };
        // }

        public int LastStoneWeight(int[] stones)
        {
            // Insert all the stones into a Max-Heap.
            MaxHeap<int> heap = new MaxHeap<int>();
            foreach (var stone in stones)
            {
                heap.Add(stone);
            }

            // While there is more than one stone left, we need to remove the two largest
            // and smash them together. If there is a resulting stone, we need to put into
            // the heap.
            while (heap.Count > 1) {
                var stone1 = heap.ExtractDominating();
                var stone2 = heap.ExtractDominating();
                if (stone1 != stone2) {
                    heap.Add(stone1 - stone2);
                }
            }

            // Check whether or not there is a stone left to return.
            return heap.Count == 0 ? 0 : heap.ExtractDominating();
        }
    }
}