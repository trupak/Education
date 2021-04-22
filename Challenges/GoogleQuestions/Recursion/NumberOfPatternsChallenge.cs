using Xunit;

namespace ChallengesTests.GoogleQuestions.Recursion
{
    public class NumberOfPatternsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/62/recursion-4/484/";
        
        [Theory]
        [InlineData(1,1,9)]
        [InlineData(1,2,65)]
        public void NumberOfPatternsTests(int m, int n, int expected) {
            Assert.Equal(expected, NumberOfPatterns(m,n));
        }

        private bool[] used = new bool[9];
        
        public int NumberOfPatterns(int m, int n)
        {
            var result = 0;
            for (int i = m; i <= n; i++)
            {
                result += CalcCount(-1, i);
                for (int j = 0; j < used.Length; j++)
                {
                    used[j] = false;
                }
            }
            return result;
        }
        
        public int CalcCount(int last, int n)
        {
            if (n == 0)
                return 1;

            var result = 0;
            for (int i = 0; i < 9; i++)
            {
                if (CanGo(last, i))
                {
                    used[i] = true;
                    result += CalcCount(i, n - 1);
                    used[i] = false;
                }
            }
            return result;
        }

        private bool CanGo(int last, int index)
        {
            if (last == -1)
                return true;

            if (used[index])
                return false;
            
            if ((index + last) % 2 == 1)
                return true;
            int mid = (index + last)/2;
            if (mid == 4)
                return used[mid];
            if ((index%3 != last%3) && (index/3 != last/3)) {
                return true;
            }
            return used[mid];
        }
    }
}