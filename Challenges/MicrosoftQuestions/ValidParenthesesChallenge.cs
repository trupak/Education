using System;
using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class ValidParenthesesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/179/";

        [Theory]
        [InlineData("()",true)]
        [InlineData("()[]{}",true)]
        [InlineData("(]",false)]
        [InlineData("([)]",false)]
        [InlineData("{[]}",true)]
        public void Tests(string s, bool expected)
        {
            Assert.Equal(expected, IsValid(s));
        }
        
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (rightBracet(s[i]))
                {
                    if (stack.Count == 0)
                        return false;

                    if (!mathedBracet(stack.Pop(), s[i]))
                        return false;
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return stack.Count == 0;
        }

        private bool rightBracet(Char c)
        {
            return c == '}' || c == ']' || c == ')';
        }

        private bool mathedBracet(Char l, Char r)
        {
            if (l == '{' && r == '}' || l == '}' && r == '{')
                return true;
            
            if (l == '[' && r == ']' || l == ']' && r == '[')
                return true;
            
            if (l == '(' && r == ')' || l == ')' && r == '(')
                return true;
            
            return false;
        }
    }
}