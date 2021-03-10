using System.Collections.Generic;
using Xunit;

namespace ChallengesTests
{
    public class LetterCombinationsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/46/backtracking/165/";

        [Theory]
        [InlineData("", new string[]{} )]
        [InlineData("2", new[]{ "a", "b", "c"})]
        [InlineData("23", new[]{ "ad","ae","af","bd","be","bf","cd","ce","cf"})]
        public void LetterCombinationsTests(string digits, string[] expected)
        {
            var resultLocal = LetterCombinations(digits);
            
            Assert.Equal(expected.Length, resultLocal.Count);
            foreach (var r in resultLocal)
            {
                Assert.Contains(r, expected);
            }
        }
        
        private Dictionary<char, IList<string>> voc = new Dictionary<char, IList<string>>();
        private IList<string> _result = new List<string>();
        
        public IList<string> LetterCombinations(string digits)
        {
            voc.Add('2', new List<string>{ "a", "b", "c" });
            voc.Add('3', new List<string>{ "d", "e", "f" });
            voc.Add('4', new List<string>{ "g", "h", "i" });
            voc.Add('5', new List<string>{ "j", "k", "l" });
            voc.Add('6', new List<string>{ "m", "n", "o" });
            voc.Add('7', new List<string>{ "p", "q", "r", "s" });
            voc.Add('8', new List<string>{ "t", "u", "v", });
            voc.Add('9', new List<string>{ "w", "x", "y", "z" });
            
            AddResults(digits, 0);
            return _result;
        }

        private void AddResults(string digits, int startIndex)
        {
            if (startIndex >= digits.Length)
                return;
            
            if (startIndex == 0)
                _result = new List<string>(){string.Empty};

            var forAdd = new List<string>();
            foreach (var res in _result)
            {
                foreach (var c in voc[digits[startIndex]])
                {
                    forAdd.Add(res + c);
                }
                
            }

            _result.Clear();
            foreach (var res in forAdd)
            {
                _result.Add(res);
            }

            AddResults(digits, startIndex + 1);
        }
    }
}