using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class LruCacheChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/531/week-4/3309/";

        [Fact]
        public void LruCacheTests()
        {
            LRUCache lRuCache = new LRUCache(2);
            lRuCache.Put(1, 1); 
            lRuCache.Put(2, 2); 
            Assert.Equal(1, lRuCache.Get(1));
            lRuCache.Put(3, 3); 
            Assert.Equal(-1, lRuCache.Get(2));
            lRuCache.Put(4, 4); 
            Assert.Equal(-1, lRuCache.Get(1));
            Assert.Equal(3, lRuCache.Get(3));
            Assert.Equal(4, lRuCache.Get(4));
        }
        
        [Fact]
        public void LruCacheTests2()
        {
            LRUCache lRuCache = new LRUCache(3);
            lRuCache.Put(1, 1); 
            lRuCache.Put(2, 2); 
            lRuCache.Put(3, 3); 
            lRuCache.Put(4, 4); 
            Assert.Equal(4, lRuCache.Get(4));
            Assert.Equal(3, lRuCache.Get(3));
            Assert.Equal(2, lRuCache.Get(2));
            Assert.Equal(-1, lRuCache.Get(1));
            lRuCache.Put(5, 5); 
            Assert.Equal(-1, lRuCache.Get(1));
            Assert.Equal(2, lRuCache.Get(2));
            Assert.Equal(3, lRuCache.Get(3));
            Assert.Equal(-1, lRuCache.Get(4));
            Assert.Equal(5, lRuCache.Get(5));
        }
        
        [Fact]
        public void LruCacheTests3()
        {
            LRUCache lRuCache = new LRUCache(1);
            lRuCache.Put(2, 1); 
            Assert.Equal(1, lRuCache.Get(2));
            lRuCache.Put(3, 2); 
            Assert.Equal(-1, lRuCache.Get(2));
            Assert.Equal(2, lRuCache.Get(3));
        }
    }
}