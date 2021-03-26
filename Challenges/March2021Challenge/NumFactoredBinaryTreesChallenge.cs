using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class NumFactoredBinaryTreesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3670/";

        [Theory]
        [InlineData(new[]{2}, 1)]
        [InlineData(new[]{2,4}, 3)]
        [InlineData(new[]{2,3,6}, 5)]
        [InlineData(new[]{2,4,5,10}, 7)]
        [InlineData(new[]{18,3,6,2}, 12)]
        [InlineData(new[]{45,42,2,18,23,1170,12,41,40,9,47,24,33,28,10,32,29,17,46,11,759,37,6,26,21,49,31,14,19,8,13,7,27,22,3,36,34,38,39,30,43,15,4,16,35,25,20,44,5,48},777)]
        public void NumFactoredBinaryTreesTests(int[] arr, int expected)
        {
            Assert.Equal(expected, NumFactoredBinaryTrees(arr));
        }

        private int NumFactoredBinaryTrees(int[] a) {
            int MOD = 1_000_000_007;
            int n = a.Length;
            Array.Sort(a);
            long[] dp = new long[n];
            Array.Fill(dp, 1);

            Dictionary<int, int> index = new();
            for (int i = 0; i < n; ++i)
                index.Add(a[i], i);

            for (int i = 0; i < n; ++i)
            for (int j = 0; j < i; ++j) {
                if (a[i] % a[j] == 0) { // A[j] is left child
                    int right = a[i] / a[j];
                    if (index.ContainsKey(right)) {
                        dp[i] = (dp[i] + dp[j] * dp[index[right]]) % MOD;
                    }
                }
            }

            long ans = 0;
            foreach (long x in dp)
            {
                ans += x;
            }
            return (int) (ans % MOD);
        }
    }
} 