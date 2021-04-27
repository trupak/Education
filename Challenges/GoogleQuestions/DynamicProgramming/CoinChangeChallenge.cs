using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.DynamicProgramming
{
    public class CoinChangeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/64/dynamic-programming-4/3088/";

        [Theory]
        [InlineData(new[] {1,2,5}, 11, 3)]
        [InlineData(new[] {2}, 3, -1)]
        [InlineData(new[] {1}, 0, 0)]
        [InlineData(new[] {1}, 1, 1)]
        [InlineData(new[] {1}, 2, 2)]
        public void CoinChangeTests(int[] coins, int amount, int expected)
        {
            Assert.Equal(expected, CoinChange(coins, amount));
        }
        
        private Dictionary<int,int> _cache = new Dictionary<int,int>();

        public int CoinChange(int[] coins, int amount) {
            if (amount < 0)
                return -1;
        
            if (amount == 0)
                return 0;
            
            if (_cache.ContainsKey(amount))
                return _cache[amount];
        
            var result = int.MaxValue;
            for(var i = 0; i < coins.Length; i++)
            {
                var partial = CoinChange(coins, amount - coins[i]);
                if (partial >= 0 && partial < result)
                    result = partial + 1;
            }
        
            _cache.Add(amount, result == int.MaxValue ? - 1 : result);

            
            
            return _cache[amount];
        }
    }
}