using System;
using System.Numerics;
using System.Text;
using Microsoft.VisualBasic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class MyAtoiChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/171/";

        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData("3.14159", 3)]
        [InlineData("+-12", 0)]
        [InlineData("20000000000000000000", int.MaxValue)]
        public void MyAtoiTests(string s, int expected)
        {
            Assert.Equal(expected, MyAtoi(s));
        }
        
        public int MyAtoi(string s)
        {
            var trimmed = s.TrimStart(' ');
            if (trimmed == string.Empty
                || (!Char.IsDigit(trimmed[0]) && trimmed[0] != '-' && trimmed[0] != '+'))
            {
                return 0;
            }

            var multiplier = trimmed[0] == '-' ? -1 : 1;
            var index = 1;
            long result = Char.IsDigit(trimmed[0]) ? int.Parse(trimmed[0].ToString()) : 0;
            while (index < trimmed.Length)
            {
                if (Char.IsDigit(trimmed[index]))
                {
                    result = result * 10 + int.Parse(trimmed[index].ToString());
                }
                else
                {
                    break;
                }

                if (result > int.MaxValue)
                    return multiplier > 0 ? int.MaxValue : int.MinValue;
                
                index++;
            }

            return (int) (multiplier*result);
        }
    }
}