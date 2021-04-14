using System.Collections.Generic;

namespace DataStructures
{
    public class NestedInteger
    {
        private readonly IList<NestedInteger> _list;
        private bool _isInteger;
        private int _value;

        public NestedInteger(IList<NestedInteger> list)
        {
            _isInteger = false;
            _list = list;
        }
        
        public NestedInteger(int value)
        {
            _isInteger = true;
            _value = value;
        }
        
        public bool IsInteger()
        {
            return _isInteger;
        }

        public int GetInteger()
        {
            return _value;
        }

        public IList<NestedInteger> GetList()
        {
            return _list;
        }
    }
}