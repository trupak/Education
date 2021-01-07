using System.Collections.Generic;

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

        public TreeNode FromInOrder(int?[] inOrder, int startIndex)
        {
            if (inOrder[startIndex] == null)
                return null;

            return new TreeNode(inOrder[startIndex].Value)
            {
                left = FromInOrder(inOrder, startIndex + 1)
            };
        }
    }
}