using Xunit;

namespace DataStructures.Tests
{
    public class PrefixTreeTests
    {
        [Fact]
        public void Tests()
        {
            var trie = new PrefixTrie();
            trie.Insert("apple");
            Assert.True(trie.Search("apple"));   // return True
            Assert.False(trie.Search("app"));     // return False
            Assert.True(trie.StartsWith("app")); // return True
            trie.Insert("app");
            Assert.True(trie.Search("app"));     // return True
        }
    }
}