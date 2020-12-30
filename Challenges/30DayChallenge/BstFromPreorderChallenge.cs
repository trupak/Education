using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class BstFromPreorderChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3305/";

        [Fact]
        public void BstFromPreorderTest()
        {
            var result = BstFromPreorder(new int[]
            {
                8, 5, 1, 7, 10, 12
            });
            
            Assert.Equal(8,result.val);
            Assert.Equal(5,result.left.val);
            Assert.Equal(1,result.left.left.val);
            Assert.Equal(7,result.left.right.val);
            Assert.Null(result.left.right.left);
            Assert.Null(result.left.right.right);
            Assert.Null(result.left.left.left);
            Assert.Null(result.left.left.right);
            
            Assert.Equal(10,result.right.val);
            Assert.Null(result.right.left);
            Assert.Equal(12,result.right.right.val);
            Assert.Null(result.right.right.right);
            Assert.Null(result.right.right.left);
        }
        
        public TreeNode BstFromPreorder(int[] preorder)
        {
            var root = new TreeNode(preorder[0]);

            var nodeStack = new Stack<TreeNode>();
            nodeStack.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                var child = new TreeNode(preorder[i]);

                TreeNode node = nodeStack.Peek();
                while (nodeStack.Count > 0 && nodeStack.Peek().val < child.val)
                    node = nodeStack.Pop();

                if (node.val < child.val)
                    node.right = child;
                else
                    node.left = child;
                
                nodeStack.Push(child);
            }
            

            return root;
        }
    }
}