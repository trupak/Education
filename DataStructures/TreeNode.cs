using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructures
{
    public class TreeNode {
        // ReSharper disable once InconsistentNaming
        public int val;
        // ReSharper disable once InconsistentNaming
        public TreeNode left;
        // ReSharper disable once InconsistentNaming
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left= null!, TreeNode right= null!) {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public TreeNode(int[] inOrder)
        {
            if (inOrder != null && inOrder.Length > 0)
            {
                var level = 1;
                val = inOrder[0];
                Queue<TreeNode> q = new Queue<TreeNode>();
                q.Enqueue(this);
                while (q.Count > 0)
                {
                    var node = q.Dequeue();
                    if (level >= inOrder.Length)
                        break;

                    if (inOrder[level] != -1)
                    {
                        node.left = new TreeNode(inOrder[level]);
                        q.Enqueue(node.left);
                    }

                    level++;
                    
                    if (level >= inOrder.Length)
                        break;

                    if (inOrder[level] != -1)
                    {
                        node.right = new TreeNode(inOrder[level]);
                        q.Enqueue(node.right);
                    }

                    level++;
                }
            }
            
        }

        public TreeNode Search(int value)
        {
            return Search(this, value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(TreeNode))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var otherNode = obj as TreeNode;
            Debug.Assert(otherNode != null, nameof(otherNode) + " != null");
            if (val != otherNode.val)
                return false;

            var leftEqual = left == null || left.Equals(otherNode.left);
            var rightEqual = right == null || right.Equals(otherNode.right);
            return leftEqual && rightEqual;
        }

        protected bool Equals(TreeNode other)
        {
            return val == other.val && Equals(left, other.left) && Equals(right, other.right);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

        public List<int> ToPreOrder()
        {
            var queue = new Queue<TreeNode>();
            var result = new List<int>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                else if (node.right != null)
                    result.Add(-1);
                
                if (node.right != null)
                    queue.Enqueue(node.right);
                else if (node.left != null)
                    result.Add(-1);
            }

            return result;
        }

        public static TreeNode Search(TreeNode node, int value)
        {
            if (node == null)
                return null;
            
            if (node.val == value)
                return node;

            var left = Search(node.left, value);
            if (left != null)
                return left;
            var right = Search(node.right, value);
            return right;
        }
    }
}