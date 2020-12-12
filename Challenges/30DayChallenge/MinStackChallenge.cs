using DataStructures;
using DataStructures.Tests;
using Xunit;

namespace ChallengesTests
{
    public class MinStackChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3292/";
        
        [Fact]
        public void MinStackTests()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Assert.Equal(-3, minStack.GetMin()); // return -3
            minStack.Pop();
            Assert.Equal(0,minStack.Top());    // return 0
            Assert.Equal(-2,minStack.GetMin()); // return -2
        }
    }
}