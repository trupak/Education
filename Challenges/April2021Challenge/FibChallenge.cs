using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class FibChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3709/";
        
        [Theory]
        [InlineData(2,1)]
        [InlineData(3,2)]
        [InlineData(4,3)]
        [InlineData(5,5)]
        public void FibTests(int n, int expected) {
            Assert.Equal(expected, Fib(n));
        }
        
        public int Fib(int n)
        {
            if (n == 0)
                return 0;
            
            if (n == 1)
                return 1;

            var sum0= 0;
            var sum1= 1;
            var sum = 1;
            for (int i = 2; i <= n; i++)
            {
                sum = sum1 + sum0;
                sum0 = sum1;
                sum1 = sum;
            }
            
            return sum;
        }
    }
}