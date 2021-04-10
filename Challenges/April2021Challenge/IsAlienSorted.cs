using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class IsAlienSortedChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3702";

        [Theory]
        [InlineData(new[] { "hello","leetcode" },"hlabcdefgijkmnopqrstuvwxyz",true)]
        [InlineData(new[] { "word","world","row" },"worldabcefghijkmnpqstuvxyz",false)]
        [InlineData(new[] { "apple","app" },"abcdefghijklmnopqrstuvwxyz",false)]
        [InlineData(new[] { "hello","hello" },"abcdefghijklmnopqrstuvwxyz",true)]
        public void IsAlienSortedTests(string[] words, string order, bool expected)
        {
            Assert.Equal(expected,IsAlienSorted(words, order));
        }
        
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words.Length < 2)
                return true;

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!CompareWords(words[i], words[i + 1], order))
                    return false;
            }
            
            return true;
        }

        private bool CompareWords(string a, string b, string order)
        {
            var index = 0;
            while (index < a.Length && index < b.Length)
            {
                if (a[index] == b[index])
                {
                    index++;
                    continue;
                }
                var orderIndex = 0;
                while (orderIndex < order.Length && order[orderIndex] != a[index] && order[orderIndex] != b[index])
                    orderIndex++;

                return order[orderIndex] != b[index];
            }

            return a.Length <= b.Length;
        }
    }
}