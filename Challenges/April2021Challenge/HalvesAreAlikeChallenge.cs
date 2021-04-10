using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class HalvesAreAlikeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/593/week-1-april-1st-april-7th/3699/";
        
        [Theory]
        [InlineData("book",true)]
        [InlineData("textbook",false)]
        [InlineData("MerryChristmas",false)]
        [InlineData("AbCdEfGh",true)]
        public void HalvesAreAlikeTests(string s, bool expected) {
            Assert.Equal(expected, HalvesAreAlike(s));
        }
        
        public bool HalvesAreAlike(string s)
        {
            var half = s.Length / 2;
            var counter = 0;
            var letters = new HashSet<char>
            {
                'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
            };
            for (int i = 0; i < half; i++)
            {
                if (letters.Contains(s[i]))
                    counter++;
                
                if (letters.Contains(s[half + i]))
                    counter--;
            }
            
            return counter == 0;
        }
    }
}