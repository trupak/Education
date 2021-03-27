using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class CountSubstringsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/591/week-4-march-22nd-march-28th/3686/";
        
        [Theory]
        [InlineData("aaa", 6)]
        [InlineData("abc", 3)]
        public void CountSubstringsTests(string s, int expected) {
            Assert.Equal(expected,CountSubstrings(s));
        }
        
        public int CountSubstrings(string s) {
            int ans = 0;

            for (int i = 0; i < s.Length; ++i) {
                // odd-length palindromes, single character center
                ans += CountPalindromesAroundCenter(s, i, i);

                // even-length palindromes, consecutive characters center
                ans += CountPalindromesAroundCenter(s, i, i + 1);
            }

            return ans;
        }
        
        private int CountPalindromesAroundCenter(string ss, int lo, int hi) {
            int ans = 0;

            while (lo >= 0 && hi < ss.Length) {
                if (ss[lo] != ss[hi])
                    break;      // the first and last characters don't match!

                // expand around the center
                lo--;
                hi++;

                ans++;
            }

            return ans;
        }
        
        // ReSharper disable once UnusedMember.Global
        public int CountSubstringsBruteForce(string s)
        {
            var result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result++;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (IsPalindromic(s, i, j))
                        result++;
                }
            }
            
            return result;
        }

        public bool IsPalindromic(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}