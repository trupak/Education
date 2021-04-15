using System;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class MinSwapsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3708/";
        
        [Theory]
        [InlineData(new[] {1,0,1,0,1}, 1)]
        [InlineData(new[] {0,0,0,1,0}, 0)]
        [InlineData(new[] {1,0,1,0,1,0,0,1,1,0,1}, 3)]
        [InlineData(new[] {1,0,1,0,1,0,1,1,1,0,1,0,0,1,1,1,0,0,1,1,1,0,1,0,1,1,0,0,0,1,1,1,1,0,0,1}, 8)]
        public void MinSwapsTests(int[] data,int expected) {
            Assert.Equal(expected, MinSwaps(data));
        }
        
        public int MinSwaps(int[] data)
        {
            var count = 0;
            for (int i = 0; i < data.Length; i++)
                count += data[i];

            if (count == data.Length || count == 1)
                return 0;

            var curCount = 0;
            var left = 0;
            var right = 0;
            for (int i = 0; i < count; i++)
            {
                curCount += data[i] == 0 ? 1 : 0;
                right = i;
            }

            var result = curCount;
            right++;
            while (right < data.Length)
            {
                curCount += data[right] == 0 ? 1 : 0;
                curCount -= data[left] == 0 ? 1 : 0;
                result = Math.Min(result, curCount);
                right++;
                left++;
            }
            
            return result;
        }
    }
}