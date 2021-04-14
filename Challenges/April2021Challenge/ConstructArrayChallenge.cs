using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class ConstructArrayChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3705/";
        
        [Theory]
        [InlineData(3,1,new[] {1,2,3})]
        [InlineData(3,2,new[] {1,3,2})]
        [InlineData(5,2,new[] {1,5,4,3,2})]
        [InlineData(5,4,new[] {1,5,2,4,3})]
        [InlineData(10,3,new[] {1,10,2,3,4,5,6,7,8,9})]
        public void ConstructArrayTests(int n, int k, int[] expected) {
            Assert.Equal(expected, ConstructArray(n,k));
        }
        
        public int[] ConstructArray(int n, int k)
        {
            var result = new int[n];
            if (k == 1)
            {
                for (int i = 0; i < n; i++)
                    result[i] = i + 1;

                return result;
            }

            var index = 1;
            var left = 1;
            var right = n;
            result[0] = 1;
            while (index < n)
            {
                if (index < k && result[index - 1] == left ||
                    index >= k && result[index - 1] != left)
                {
                    result[index] = right;
                    right--;    
                }
                else if (index < k && result[index - 1] != left ||
                         index >= k && result[index - 1] == left)
                {
                    left++;
                    result[index] = left;
                }    
                
                index++;
            }

            return result;
        }
    }
}