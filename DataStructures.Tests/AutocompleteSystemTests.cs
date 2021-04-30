using System.Linq;
using Xunit;

namespace DataStructures.Tests
{
    public class AutocompleteSystemTests
    {
        [Fact]
        public void Tests()
        {
            var system = new AutocompleteSystem(
                new[] {"abc", "abbc", "a"},
                new [] {3,3,3});

            var result = system.Input('b');
            Assert.Equal(new string[0] , result);
            result = system.Input('c');
            Assert.Equal(new string[0] , result);
            result = system.Input('#');
            Assert.Equal(new string[0] , result);
            result = system.Input('b');
            Assert.Equal(new [] {"bc"}.OrderBy(x => x), result);
            result = system.Input('c');
            Assert.Equal(new [] {"bc"}.OrderBy(x => x), result);
            result = system.Input('#');
            Assert.Equal(new string[0] , result);
            
            result = system.Input('a');
            Assert.Equal(new[] {"a", "abbc", "abc"} , result);
            result = system.Input('b');
            Assert.Equal(new[] {"abbc", "abc"} , result);
            result = system.Input('c');
            Assert.Equal(new[] {"abc"} , result);
            result = system.Input('#');
            Assert.Equal(new string[0] , result);
            result = system.Input('a');
            Assert.Equal(new[] {"abc", "a", "abbc"} , result);
            result = system.Input('b');
            Assert.Equal(new[] {"abc", "abbc" } , result);
            result = system.Input('c');
            Assert.Equal(new[] {"abc"} , result);
            result = system.Input('#');
            Assert.Equal(new string[0] , result);
        }
    }
}