using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class LRUCacheChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3309/";

        [Fact]
        public void LRUCacheTests()
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); 
            lRUCache.Put(2, 2); 
            Assert.Equal(1, lRUCache.Get(1));
            lRUCache.Put(3, 3); 
            Assert.Equal(-1, lRUCache.Get(2));
            lRUCache.Put(4, 4); 
            Assert.Equal(-1, lRUCache.Get(1));
            Assert.Equal(3, lRUCache.Get(3));
            Assert.Equal(4, lRUCache.Get(4));
        }
        
        [Fact]
        public void LRUCacheTests2()
        {
            LRUCache lRUCache = new LRUCache(3);
            lRUCache.Put(1, 1); 
            lRUCache.Put(2, 2); 
            lRUCache.Put(3, 3); 
            lRUCache.Put(4, 4); 
            Assert.Equal(4, lRUCache.Get(4));
            Assert.Equal(3, lRUCache.Get(3));
            Assert.Equal(2, lRUCache.Get(2));
            Assert.Equal(-1, lRUCache.Get(1));
            lRUCache.Put(5, 5); 
            Assert.Equal(-1, lRUCache.Get(1));
            Assert.Equal(2, lRUCache.Get(2));
            Assert.Equal(3, lRUCache.Get(3));
            Assert.Equal(-1, lRUCache.Get(4));
            Assert.Equal(5, lRUCache.Get(5));
        }
        
        [Fact]
        public void LRUCacheTests3()
        {
            LRUCache lRUCache = new LRUCache(1);
            lRUCache.Put(2, 1); 
            Assert.Equal(1, lRUCache.Get(2));
            lRUCache.Put(3, 2); 
            Assert.Equal(-1, lRUCache.Get(2));
            Assert.Equal(2, lRUCache.Get(3));
        }
    }
}