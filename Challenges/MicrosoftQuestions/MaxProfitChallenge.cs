using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class MaxProfitChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/186/";

        [Theory]
        [InlineData(new int[] {7,1,5,3,6,4}, 5)]
        [InlineData(new int[] {7,6,4,3,1}, 0)]
        public void MaxProfitTests(int[] prices, int expected)
        {
            Assert.Equal(expected, MaxProfit(prices));
        }2
        
        public int MaxProfit(int[] prices)
        {
            // O(n)
            if (prices == null || prices.Length < 2)
                return 0;
            var currentMax = prices[prices.Length - 1];
            var result = 0;
            for (int i = prices.Length - 2; i >= 0; i--)
            {
                if (prices[i] >= currentMax)
                {
                    currentMax = prices[i];
                }
                else if (result < currentMax - prices[i])
                {
                    result = currentMax - prices[i];
                }
            }

            return result;
        }
    }
}