using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Recursion
{
    public class FindStrobogrammaticChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/62/recursion-4/399/";
        
        [Theory]
        [InlineData(1, new[] {"1","0","8"})]
        [InlineData(2, new[] {"11","69","88","96"})]
        public void FindStrobogrammaticTests(int n, string[] expected) {
            Assert.Equal(expected.OrderBy(x => x), FindStrobogrammatic(n).OrderBy(x => x).ToArray());
        }
        
        public IList<string> FindStrobogrammatic(int n)
        {
            return FindStrobogrammatic(n, n);
        }

        public List<string>  FindStrobogrammatic(int n, int length)
        {
            if (n == 0)
                return new List<string>{ "" };

            if (n == 1)
                return new List<string>{"0", "1", "8"};

            var prev = FindStrobogrammatic(n - 2, length);
            
            var newRes = new List<string>();
            foreach (var res in prev)
            {
                if (n != length)
                    newRes.Add("0" + res + "0");
                newRes.Add("1" + res + "1");
                newRes.Add("8" + res + "8");
                newRes.Add("6" + res + "9");
                newRes.Add("9" + res + "6");
            }

            return newRes;
        }
    }
}