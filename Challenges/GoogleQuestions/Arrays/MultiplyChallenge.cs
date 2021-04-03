using System;
using System.Numerics;
using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class MultiplyChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/59/array-and-strings/3051/";
        
        [Theory]
        [InlineData("2","3","6")]
        [InlineData("123","456","56088")]
        [InlineData("9","99","891")]
        [InlineData("123456789", "987654321","121932631112635269")]
        public void MultiplyTests(string num1, string num2, string expected) {
            Assert.Equal(expected, Multiply(num1,num2));
        }
        
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";
            
            var num1A = new int[num1.Length];
            var num2A = new int[num2.Length];
            for (int i = 0; i < num1.Length; i++)
                num1A[i] = Convert.ToInt32(num1[i].ToString());
            
            for (int i = 0; i < num2.Length; i++)
                num2A[i] = Convert.ToInt32(num2[i].ToString());

            var result = new int[num1.Length * num2.Length + 10];
            
            for (int i = num1A.Length - 1; i >= 0; i--)
            {
                var current = result.Length - 1 - (num1A.Length - 1 - i);
                for (int j = num2A.Length - 1; j >= 0; j--)
                {
                    int mod;
                    result[current - 1] += Math.DivRem(num1A[i] * num2A[j], 10, out mod);
                    result[current] += mod;
                    if (result[current] >= 10)
                    {
                        result[current - 1] += Math.DivRem(result[current], 10, out mod);
                        result[current] = mod;
                    }
                    current--;
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0 && sb.Length == 0)
                    continue;

                sb.Append(result[i].ToString());
            }
            
            return sb.ToString();
        }
    }
}