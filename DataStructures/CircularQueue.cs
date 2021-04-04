using System.Collections.Generic;

namespace DataStructures
{
    public class CircularQueue
    {
        private int _capacity;
        private LinkedList<int> _list;
        public CircularQueue(int k)
        {
            _capacity = k;
            _list = new LinkedList<int>();
        }
    
        public bool EnQueue(int value)
        {
            if (_list.Count >= _capacity)
                return false;

            _list.AddFirst(value);
            return true;
        }
    
        public bool DeQueue()
        {
            if (_list.Count == 0)
                return false;
            
            _list.RemoveLast();
            return true;
        }
    
        public int Front()
        {
            return _list.Last?.Value ?? -1;
        }
    
        public int Rear() {
            return _list.First?.Value ?? -1;
        }
    
        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    
        public bool IsFull() {
            return _list.Count == _capacity;
        }
    }
}