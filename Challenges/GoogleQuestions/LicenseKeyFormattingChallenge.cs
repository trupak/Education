using System.Text;
using Xunit;

namespace ChallengesTests.GoogleQuestions
{
    public class LicenseKeyFormattingChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/67/sql-2/472/";
        
        [Theory]
        [InlineData("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
        [InlineData("2-5g-3-J", 2, "2-5G-3J")]
        [InlineData("2-4A0r7-4k", 3, "24-A0R-74K")]
        public void LicenseKeyFormattingTests(string s, int k, string expected) {
            Assert.Equal(expected, LicenseKeyFormatting(s, k));
        }
        
        public string LicenseKeyFormatting(string s, int k)
        {
            var clearedS = s
                .Replace("-", string.Empty).ToUpper();

            var sb = new StringBuilder();
            var mod = clearedS.Length % k;

            if (mod > 0)
            {
                for (int i = 0; i < mod; i++)
                    sb.Append(clearedS[i]);
            }

            for (int i = mod; i < clearedS.Length; i++)
            {
                if ((clearedS.Length - i) % k == 0 && i > 0)
                    sb.Append("-");

                sb.Append(clearedS[i]);
            }

            return sb.ToString();
        }
    }
}