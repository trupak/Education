using System.Collections.Generic;
using Xunit;

namespace DataStructures.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void InsertIntoSortedListTests()
        {
            var list = new List<int>
            {
                1, 2, 5, 6, 9, 12
            };
            list.InsertIntoSortedList(11);
            Assert.Equal(11, list[5]);
        }
    }
}