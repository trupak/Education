using Xunit;

namespace ChallengesTests.GoogleQuestions
{
    public class TotalFruitChallenge: IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/67/sql-2/3046/";
        
        [Theory]
        [InlineData(new[] {1,2,1}, 3)]
        [InlineData(new[] {0,1,2,2}, 3)]
        [InlineData(new[] {1,2,3,2,2}, 4)]
        [InlineData(new[] {3,3,3,1,2,1,1,2,3,3,4}, 5)]
        [InlineData(new[] {1,0,1,4,1,4,1,2,3}, 5)]
        public void TotalFruitTests(int[] tree, int expected) {
            Assert.Equal(expected, TotalFruit(tree));
        }
        
        public int TotalFruit(int[] tree)
        {
            var basket1 = tree[0];
            var basket2 = -1;
            var maxCount = 1;
            var currentCount = 1;
            var lastCount = 1;
            
            for (int i = 1; i < tree.Length; i++)
            {
                if (basket2 == -1 && basket1 != tree[i])
                {
                    basket2 = tree[i];
                    currentCount++;
                    if (currentCount > maxCount)
                        maxCount = currentCount;

                    lastCount = 1;
                    continue;
                }

                if (tree[i] != basket1 && tree[i] != basket2)
                {
                    currentCount = lastCount + 1;
                    basket1 = basket2;
                    basket2 = tree[i];
                }
                else
                {
                    if (tree[i] == basket1)
                    {
                        basket1 = basket2;
                        basket2 = tree[i];
                    }
                    
                    currentCount++;
                }
                
                if (currentCount > maxCount)
                    maxCount = currentCount;
                
                if (tree[i - 1] == tree[i])
                    lastCount++;
                else
                    lastCount = 1;
            }
            
            return maxCount;
        }
    }
}