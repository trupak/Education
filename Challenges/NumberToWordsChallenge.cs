using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class NumberToWordsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/188/";

        [Theory]
        [InlineData(123, "One Hundred Twenty Three")]
        [InlineData(12345, "Twelve Thousand Three Hundred Forty Five")]
        [InlineData(1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
        [InlineData(1234567891, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]
        public void NumberToWordsTests(int num, string expected)
        {
            Assert.Equal(expected, NumberToWords(num));
        }
        
        public string NumberToWords(int num)
        {
            var dictionary = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Elewen"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},

            };
            return string.Empty;
        }
    }
}