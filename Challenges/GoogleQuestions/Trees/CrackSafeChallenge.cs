using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class CrackSafeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3075/";
        
        [Theory]
        [InlineData(1,2,"10")]
        [InlineData(2,2,"01100")]
        public void CrackSafeTests(int n, int k, string expected) {
            Assert.Equal(expected, CrackSafe(n,k));
        }
        
        HashSet<String> _seen = null!;
        StringBuilder _ans = null!;

        public String CrackSafe(int n, int k) {
            if (n == 1 && k == 1) return "0";
            _seen = new HashSet<string>();
            _ans = new StringBuilder();

            var sb = new StringBuilder();
            for (int i = 0; i < n-1; ++i)
                sb.Append("0");
            var start = sb.ToString();

            Dfs(start, k);
            _ans.Append(start);
            return _ans.ToString();
        }

        private void Dfs(string node, int k) {
            for (int x = 0; x < k; ++x) {
                string nei = node + x;
                if (!_seen.Contains(nei)) {
                    _seen.Add(nei);
                    Dfs(nei.Substring(1), k);
                    _ans.Append(x);
                }
            }
        }
    }
}