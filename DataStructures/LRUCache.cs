using System.Collections.Generic;

namespace DataStructures
{
    // ReSharper disable once InconsistentNaming
    public class LRUCache
    {
        
        private readonly Dictionary<int, CustonListNode<(int Key,int Value)>> _nodes = 
            new Dictionary<int, CustonListNode<(int Key, int Value)>>();
        private CustomLinkedListWithCapacity<(int Key,int Value)> _linkedList;
        
        public LRUCache(int capacity)
        {
            _linkedList = new CustomLinkedListWithCapacity<(int Key,int Value)>(capacity);
        }
    
        public int Get(int key)
        {
            if (!_nodes.ContainsKey(key))
                return -1;

            var result = _nodes[key];
            _linkedList.MoveToStart(result);
            return _nodes[key].Value.Value;
        }
    
        public void Put(int key, int value) {
            if (_nodes.ContainsKey(key))
            {
                var position = _nodes[key];
                _linkedList.MoveToStart(position);
                position.Value = ( key, value );
            }
            else
            {
                var deletedNode = _linkedList.Enqueue(( key, value ));
                _nodes.Add(key, _linkedList.ListStart);
                if (deletedNode != null)
                {
                    _nodes.Remove(deletedNode.Value.Key);    
                }
            }
        }
    }
}