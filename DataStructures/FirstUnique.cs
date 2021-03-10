using System.Collections.Generic;

namespace DataStructures
{
    public class FirstUnique
    {
        private Dictionary<int, LinkedListNode<int>> _items = new Dictionary<int, LinkedListNode<int>>();
        private LinkedList<int> _list = new LinkedList<int>();

        public FirstUnique(int[] nums) {
            for (int i = 0; i < nums.Length; i++)
            {
                Add(nums[i]);
            }
        }
    
        public int ShowFirstUnique()
        {
            if (_list == null || _list.Count == 0)
                return -1;

            if (_list.First != null) return _list.First.Value;

            return -1;
        }
    
        public void Add(int value)
        {
            if (_items.ContainsKey(value))
            {
                if (_items[value].List != null)
                    _list.Remove(_items[value]);
            }
            else
            {
                _list.AddLast(value);
                _items.Add(value, _list.Last);
            }
        }
    }
}