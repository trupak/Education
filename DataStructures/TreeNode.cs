using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class TreeNode {
        public int val;
        public TreeNode left;
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
                this.val = inOrder[0];
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