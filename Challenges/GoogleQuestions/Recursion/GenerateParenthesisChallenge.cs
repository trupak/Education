using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Recursion
{
    public class GenerateParenthesisChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/62/recursion-4/3079/";
        
        [Theory]
        [InlineData(3, new[] {"((()))","(()())","(())()","()(())","()()()"})]
        public void GenerateParenthesisTests(int n, string[] expected) {
            Assert.Equal(expected.OrderBy(x => x), GenerateParenthesis(n).ToArray().OrderBy(x => x));
        }
        
        public List<String> GenerateParenthesis(int n) {
            var ans = new List<string>();
            if (n == 0) {
                ans.Add("");
            } else {
                for (int c = 0; c < n; ++c)
                    foreach(var left in GenerateParenthesis(c))
                    foreach(var right in GenerateParenthesis(n-1-c))
                        ans.Add("(" + left + ")" + right);
            }
            return ans;
        }
    }
}