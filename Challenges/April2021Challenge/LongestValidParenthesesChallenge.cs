using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class LongestValidParenthesesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3695/";
        
        [Theory]
        [InlineData("(()", 2)]
        [InlineData("()", 2)]
        [InlineData(")()())", 4)]
        [InlineData("", 0)]
        [InlineData(")(", 0)]
        public void LongestValidParenthesesTests(string s, int expected) {
            Assert.Equal(expected, LongestValidParentheses(s));
        }

        public int LongestValidParentheses(string s)
        {
            var result = 0;
            var countLeft = 0;
            var countRight = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    countLeft++;
                
                if (s[i] == ')')
                    countRight++;
            }

            var maxResult = Math.Min(countLeft, countRight) * 2;
            
            for (int i = 0; i < s.Length; i++)
            {
                var queue = new Queue<char>();
                var currentMax = 0;
                if (result >= s.Length - i)
                    return result;
                
                for (int j = i; j < Math.Min(i + maxResult, s.Length); j++)
                {
                    if (queue.Count == 0 && s[j] == ')')
                        break;

                    if (s[j] == '(')
                    {
                        queue.Enqueue(s[j]);
                        continue;
                    }
                
                    var top1 = queue.Peek();
                    if (top1 == '(' && s[j] == ')')
                        queue.Dequeue();
                    else
                    {
                        queue.Enqueue(s[j]);
                    }

                    if (queue.Count == 0)
                        currentMax = j + 1 - i;
                }

                result = Math.Max(result, currentMax);
            }
            return result;
        }
    }
}