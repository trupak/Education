using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class DecodeStringChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3073/";
        
        [Theory]
        [InlineData("3[a]2[bc]", "aaabcbc")]
        [InlineData("3[a2[c]]", "accaccacc")]
        [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
        [InlineData("abc3[cd]xyz", "abccdcdcdxyz")]
        public void DecodeStringTests(string s, string expected) {
            Assert.Equal(expected, DecodeString(s));
        }
        
        public string DecodeString(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ']')
                {
                    var word = string.Empty;
                    while (stack.Count > 0)
                    {
                        if (stack.Peek() != '[')
                        {
                            word = stack.Pop() + word;
                        }
                        else
                        {
                            stack.Pop();
                            break;
                        }
                    }
                    
                    var count = string.Empty;
                    while (stack.Count > 0)
                    {
                        if (char.IsDigit(stack.Peek()))
                            count = stack.Pop() + count;
                        else
                            break;
                    }

                    for (int j = 0; j < Convert.ToInt32(count); j++)
                        for (int k = 0; k < word.Length; k++)
                            stack.Push(word[k]);
                }
                else
                {
                    stack.Push(s[i]);
                }
            }

            return new string(stack.Reverse().ToArray());
        }
    }
}