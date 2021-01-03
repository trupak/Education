using System;
using System.Text;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class ReverseWordsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/166/";

        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("  hello world  ", "world hello")]
        [InlineData("a good   example", "example good a")]
        [InlineData("  Bob    Loves  Alice   ", "Alice Loves Bob")]
        [InlineData("Alice does not even like bob", "bob like even not does Alice")]
        public void ReverseWordsTests(string s, string expected)
        {
            Assert.Equal(expected, ReverseWords(s));
        }
        
        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("Alice does not even like bob", "bob like even not does Alice")]
        public void ReverseWordsTests2(string s, string expected)
        {
            var c = s.ToCharArray();
            ReverseWords(c);
            Assert.Equal(expected, new string(c));
        }

        public void ReverseWords(char[] s)
        {
            var sb = new StringBuilder();
            var wordStart = -1;
            var wordEnd = s.Length;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (wordStart > 0)
                    {
                        if (wordStart < wordEnd)
                        {
                            if (sb.Length != 0)
                                sb.Append(" ");
                            
                            for (int j = wordStart; j < wordEnd; j++)
                                sb.Append(s[j]);
                        }
                    }
                    
                    wordEnd = i;
                    continue;
                }

                wordStart = i;

                if (i == 0)
                {
                    if (sb.Length != 0)
                        sb.Append(" ");
                    
                    for (int j = 0; j < wordEnd; j++)
                    {
                        sb.Append(s[j]);
                    }
                }
            }

            var result = sb.ToString();
            for (int i = 0; i < result.Length; i++)
            {
                s[i] = result[i];
            }
        }
        
        public string ReverseWords(string s)
        {
            var sb = new StringBuilder();
            var wordStart = -1;
            var wordEnd = s.Length;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (wordStart > 0)
                    {
                        if (wordStart < wordEnd)
                        {
                            if (sb.Length != 0)
                                sb.Append(" ");
                            
                            for (int j = wordStart; j < wordEnd; j++)
                                sb.Append(s[j]);
                        }
                    }
                    
                    wordEnd = i;
                    continue;
                }

                wordStart = i;

                if (i == 0)
                {
                    if (sb.Length != 0)
                        sb.Append(" ");
                    
                    for (int j = 0; j < wordEnd; j++)
                    {
                        sb.Append(s[j]);
                    }
                }
            }

            return sb.ToString();
        }
    }
} 