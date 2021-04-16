using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class RemoveDuplicatesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3710/";
        
        [Theory]
        [InlineData("abcd", 2, "abcd")]
        [InlineData("deeedbbcccbdaa", 3, "aa")]
        [InlineData("pbbcggttciiippooaais", 2, "ps")]
        public void RemoveDuplicatesTests(string s, int k, string expected) {
            Assert.Equal(expected, RemoveDuplicates(s, k));
        }
        
        public string RemoveDuplicates(string s, int k)
        {
            var stack = new Stack<char>();
            var lastkcharacters = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
                if (lastkcharacters.Length < k)
                    lastkcharacters += s[i];    
                else
                    lastkcharacters = lastkcharacters.Substring(1) + s[i];
                
                if (lastkcharacters.Length == k)
                {
                    while (IsDuplicate(lastkcharacters, k))
                    {
                        for (int j = 0; j < k; j++)
                            stack.Pop();

                        lastkcharacters = string.Empty;
                        while (stack.Count > 0 && lastkcharacters.Length < k)
                            lastkcharacters = stack.Pop() + lastkcharacters;

                        for (int j = 0; j < lastkcharacters.Length; j++)
                            stack.Push(lastkcharacters[j]);
                    }
                }
            }

            var result = new char[stack.Count];
            var counter = stack.Count - 1;
            while (stack.Count > 0)
            {
                result[counter] = stack.Pop();
                counter--;
            }

            return new string(result);
        }

        private bool IsDuplicate(string s, int k)
        {
            if (s.Length < k)
                return false;
            
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                    return false;
            }
            
            return true;
        }
    }
}