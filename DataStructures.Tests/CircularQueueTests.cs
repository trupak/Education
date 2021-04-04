using Xunit;

namespace DataStructures.Tests
{
    public class CircularQueueTests
    {
        [Fact]
        public void QueueWorks()
        {
            var myCircularQueue = new CircularQueue(3);
            Assert.True(myCircularQueue.EnQueue(1));
            Assert.True(myCircularQueue.EnQueue(2));
            Assert.True(myCircularQueue.EnQueue(3));
            Assert.False(myCircularQueue.EnQueue(4));
            Assert.Equal(3,myCircularQueue.Rear());
            Assert.True(myCircularQueue.IsFull());
            Assert.True(myCircularQueue.DeQueue());
            Assert.True(myCircularQueue.EnQueue(4));
            Assert.Equal(4, myCircularQueue.Rear());
        }
    }
}