using Xunit;

namespace ChallengesTests
{
    public class RangeBitwiseAndChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3308/";
        
        [Theory]
        [InlineData(10,11,10)]
        [InlineData(0,0,0)]
        [InlineData(1,1,1)]
        [InlineData(1,2,0)]
        [InlineData(5,7,4)]
        [InlineData(0,1,0)]
        [InlineData(8,15,8)]
        [InlineData(14,15,14)]
        public void RangeBitwiseAndTests(int m, int n, int expected) {
            Assert.Equal(expected,RangeBitwiseAnd(m,n));
        }
        
        public int RangeBitwiseAnd(int m, int n)
        {
            var shift = 0;
            while (m < n)
            {
                n = n >> 1;
                m = m >> 1;
                shift++;
            }
                
            return n << shift;
        }
        
        // public int RangeBitwiseAnd(int m, int n) {
        //     while (m < n)
        //         n = n & (n - 1);
        //     return n;
        // }
    }
}