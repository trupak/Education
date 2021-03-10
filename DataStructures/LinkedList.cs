namespace DataStructures
{
    public class CustonListNode<TNode>
    {
        private TNode _value;

        public TNode Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        } 
            
        public CustonListNode<TNode> Left;
        public CustonListNode<TNode> Right;

        public CustonListNode(TNode value, CustonListNode<TNode> left = null, CustonListNode<TNode> right = null)
        {
            _value = value;
            Left = left;
            Right = right;
        }
    }
    
    public class CustomLinkedListWithCapacity<T>
    {
        private readonly int _capacity;
        private int _size;
        public int Size => _size;
        public CustonListNode<T> ListStart; 
        public CustonListNode<T> ListEnd;

        public CustomLinkedListWithCapacity(int capacity = 5)
        {
            _capacity = capacity;
        }
        
        private void Remove(CustonListNode<T> node)
        {
            if (node == null)
                return;

            var prevNode = node.Left;
            var nextNode = node.Right;

            if (prevNode != null)
                prevNode.Right = nextNode;
            else
                ListStart = nextNode;

            if (nextNode != null)
                nextNode.Left = prevNode;
            else
                ListEnd = prevNode;
            
            _size--;
        }

        public CustonListNode<T> Dequeue()
        {
            var result = ListEnd;
            Remove(ListEnd);
            return result;
        }

        public void MoveToStart(CustonListNode<T> existedNode)
        {
            Remove(existedNode);
            existedNode.Left = null;
            if (ListStart != null)
                ListStart.Left = existedNode;

            existedNode.Right = ListStart;
            ListStart = existedNode;
            if (ListEnd == null)
                ListEnd = ListStart;
            _size++;
        }
        
        public CustonListNode<T> Enqueue(T value)
        {
            var newNode = new CustonListNode<T>(value, right: ListStart);
            _size++;
            if (ListStart == null)
            {
                ListStart = newNode;
                ListEnd = newNode;
                
                return null;
            }
            
            if (ListStart != null)
                ListStart.Left = newNode;
            
            ListStart = newNode;
            
            if (_size > _capacity)
            {
                var result = ListEnd;
                Remove(ListEnd);
                return result;
            }

            return null;
        }
    }
}