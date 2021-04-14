using Xunit;

namespace ChallengesTests.GoogleQuestions.Arrays
{
    public class BackspaceCompareChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/59/array-and-strings/3060/";

        [Theory]
        [InlineData("a#c", "b", false)]
        [InlineData("ab#c", "ad#c", true)]
        [InlineData("a##c", "#a#c", true)]
        [InlineData("a#b#", "c#d#", true)]
        [InlineData("ab##", "c#d#", true)]
        [InlineData("bbbextm", "bbb#extm", false)]
        [InlineData("nzp#o#g", "b#nzp#o#g", true)]
        public void BackspaceCompareTests(string s, string t, bool expected)
        {
            Assert.Equal(expected, BackspaceCompare(s, t));
        }
        
        public bool BackspaceCompare(string s, string t)
        {
            var sIndex = s.Length - 1;
            var tIndex = t.Length - 1;

            while (sIndex >= 0 && tIndex >= 0)
            {
                sIndex = MoveToNextSymbol(s, sIndex);
                tIndex = MoveToNextSymbol(t, tIndex);

                if (sIndex == -1 || tIndex == -1)
                    return sIndex == tIndex;

                if (s[sIndex] != t[tIndex])
                    return false;

                sIndex--;
                tIndex--;
            }
            
            sIndex = MoveToNextSymbol(s, sIndex);
            tIndex = MoveToNextSymbol(t, tIndex);
            
            return sIndex == tIndex;
        }

        private int MoveToNextSymbol(string s, int sIndex)
        {
            var backspaceCount = 0;
            while (sIndex >= 0 && (backspaceCount > 0 || s[sIndex] == '#'))
            {
                if (s[sIndex] == '#')
                {
                    backspaceCount++;
                }
                else
                {
                    backspaceCount--;
                }
                sIndex--;
            }

            return sIndex;
        }
    }
}