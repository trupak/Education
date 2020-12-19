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
            
            Assert.Equal(8,result.Val);
            Assert.Equal(5,result.Left.Val);
            Assert.Equal(1,result.Left.Left.Val);
            Assert.Equal(7,result.Left.Right.Val);
            Assert.Null(result.Left.Right.Left);
            Assert.Null(result.Left.Right.Right);
            Assert.Null(result.Left.Left.Left);
            Assert.Null(result.Left.Left.Right);
            
            Assert.Equal(10,result.Right.Val);
            Assert.Null(result.Right.Left);
            Assert.Equal(12,result.Right.Right.Val);
            Assert.Null(result.Right.Right.Right);
            Assert.Null(result.Right.Right.Left);
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
                while (nodeStack.Count > 0 && nodeStack.Peek().Val < child.Val)
                    node = nodeStack.Pop();

                if (node.Val < child.Val)
                    node.Right = child;
                else
                    node.Left = child;
                
                nodeStack.Push(child);
            }
            

            return root;
        }
    }
}