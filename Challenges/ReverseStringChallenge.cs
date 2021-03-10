using System.Text;
using Xunit;

namespace ChallengesTests
{
    public class ReverseStringChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/187/";

        [Theory]
        [InlineData(new[] {'h','e','l','l','o' }, "olleh")]
        public void ReverseStringTests(char[] s, string expected)
        {
            ReverseString(s);
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                sb.Append(c);
            }
            
            Assert.Equal(expected, sb.ToString());
        }
        
        private void ReverseString(char[] s) {
            if (s.Length == 0)
                return;
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                var tmp = s[start];
                s[start] = s[end];
                s[end] = tmp;
                start++;
                end--;
            }
        }
    }
}