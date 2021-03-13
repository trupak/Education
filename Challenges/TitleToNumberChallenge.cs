using Xunit;

namespace ChallengesTests
{
    public class TitleToNumberChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/48/others/183/";
        
        [Theory]
        [InlineData("A", 1)]
        [InlineData("AB", 28)]
        [InlineData("ZY", 701)]
        [InlineData("FXSHRXW", 2147483647)]
        public void TitleToNumberTests(string columnTitle, int expected) {
            Assert.Equal(expected, TitleToNumber(columnTitle));
        }
        
        public int TitleToNumber(string columnTitle)
        {
            var dimention = 1;
            var result = 0;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                var number = ((columnTitle[i] - 'A') + 1) * dimention;
                result += number;
                dimention *= 26;
            }

            return result;
        }
    }
}