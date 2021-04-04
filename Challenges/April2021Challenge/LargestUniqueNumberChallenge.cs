using System;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class LargestUniqueNumberChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3692/";
        
        [Theory]
        [InlineData(new [] { 5,7,3,9,4,9,8,3,1 }, 8)]
        [InlineData(new [] { 9,9,8,8 }, -1)]
        public void LargestUniqueNumberTests(int[] a, int expected) {
            Assert.Equal(expected, LargestUniqueNumber(a));
        }
        
        public int LargestUniqueNumber(int[] a)
        {
            Array.Sort(a);

            if (a.Length == 1)
                return a[0];
            
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (a[i] != a[i + 1])
                        return a[i];
                }
                else if (i == a.Length - 1)
                {
                    if (a[i] != a[i - 1])
                        return a[i];
                }
                else if (a[i] != a[i - 1] && a[i] != a[i + 1])
                    return a[i];
            }
            
            return -1;
        }
    }
}