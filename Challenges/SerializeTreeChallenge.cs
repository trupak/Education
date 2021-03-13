using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class SerializeTreeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/51/design/891/";

        [Fact]
        public void SerializeTests()
        {
            var node = new TreeNode(new[] {1,2,3,4,5,6,7,8,9});
            var serialize = Serialize(node);
            Assert.Equal("1,2,3,4,5,6,7,8,9,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648,-2147483648", serialize);
            var newNode = Deserialize(serialize);
            Assert.True(node.Equals(newNode));
        }
        
        // Encodes a tree to a single string.
        public string Serialize(TreeNode? root)
        {
            if (root == null)
                return string.Empty;
            
            var result = new StringBuilder();
            var queue = new Queue<TreeNode>();
            var emptyNode = new TreeNode(int.MinValue);
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var tempNode = queue.Dequeue();
                result.Append(tempNode.val);
                result.Append(",");
 
                if (ReferenceEquals(tempNode,emptyNode))
                    continue;
                
                /*Enqueue left child */
                if (tempNode.left != null) 
                {
                    queue.Enqueue(tempNode.left);
                }
                else
                {
                    queue.Enqueue(emptyNode); 
                }
 
                /*Enqueue right child */
                if (tempNode.right != null) 
                {
                    queue.Enqueue(tempNode.right);
                }
                else
                {
                    queue.Enqueue(emptyNode);
                }
            }

            result.Length = result.Length - 1;
            return result.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode? Deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;
            
            var part = data.Split(',');
            var inOrder = part.Select(x => int.Parse(x)).ToArray();
            var level = 1;
            var result = new TreeNode();
            result.val = inOrder[0];
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(result);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (level >= inOrder.Length)
                    break;

                if (inOrder[level] != int.MinValue)
                {
                    node.left = new TreeNode(inOrder[level]);
                    q.Enqueue(node.left);
                }

                level++;
                    
                if (level >= inOrder.Length)
                    break;

                if (inOrder[level] != int.MinValue)
                {
                    node.right = new TreeNode(inOrder[level]);
                    q.Enqueue(node.right);
                }

                level++;
            }

            return result;
        }
    }
}