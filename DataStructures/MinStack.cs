using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class MinStack {
        class ValueWithMinumum
        {
            public int Value { get; set; }
            public int MinValue { get; set; }
        }
            
        private readonly List<ValueWithMinumum> _list = new List<ValueWithMinumum>();

        public void Push(int x)
        {
            _list.Add(new ValueWithMinumum
            {
                Value = x,
                MinValue = _list.Count > 0 ?
                    Math.Min(_list[^1].MinValue, x) : x
            });
        }
    
        public void Pop()
        {
            _list.RemoveAt(_list.Count - 1);
        }
    
        public int Top()
        {
            return _list[^1].Value;
        }
    
        public int GetMin()
        {
            return _list[^1].MinValue;
        }
    }
}