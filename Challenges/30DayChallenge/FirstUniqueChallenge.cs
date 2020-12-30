using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class FirstUniqueChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3313/";

        [Fact]
        public void FirstUniqueTest1()
        {
            FirstUnique firstUnique = new FirstUnique(new[] {2,3,5});
            Assert.Equal(2,firstUnique.ShowFirstUnique());; // return 2
            firstUnique.Add(5);            // the queue is now [2,3,5,5]
            Assert.Equal(2,firstUnique.ShowFirstUnique()); // return 2
            firstUnique.Add(2);            // the queue is now [2,3,5,5,2]
            Assert.Equal(3,firstUnique.ShowFirstUnique()); // return 3
            firstUnique.Add(3);            // the queue is now [2,3,5,5,2,3]
            Assert.Equal(-1,firstUnique.ShowFirstUnique()); // return -1
        } 
        
        [Fact]
        public void FirstUniqueTest2()
        {
            FirstUnique firstUnique = new FirstUnique(new[] {7,7,7,7,7,7});
            Assert.Equal(-1,firstUnique.ShowFirstUnique());;
            firstUnique.Add(7);           
            firstUnique.Add(3);            
            firstUnique.Add(3);            
            firstUnique.Add(7);            
            firstUnique.Add(17);           
            Assert.Equal(17,firstUnique.ShowFirstUnique());
        } 
        
        [Fact]
        public void FirstUniqueTest3()
        {
            FirstUnique firstUnique = new FirstUnique(new[] {809});
            Assert.Equal(809,firstUnique.ShowFirstUnique());;
            firstUnique.Add(809);           
            Assert.Equal(-1,firstUnique.ShowFirstUnique());
        } 
    }
}