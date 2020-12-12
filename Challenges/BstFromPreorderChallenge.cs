using System.Collections.Generic;
using DataStructures;

namespace ChallengesTests
{
    public class BstFromPreorderChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/530/week-3/3305/";
        
        public TreeNode BstFromPreorder(int[] preorder)
        {
            var root = new TreeNode
            {
                Val = preorder[0]
                
            };

            var nodeStack = new Stack<TreeNode>();
            nodeStack.Push(root);
            for (int i = 1; i < preorder.Length; i++)
            {
                while (true)
                {
                    var currNode = nodeStack.Peek();
                    if (currNode.Val > preorder[i] && currNode.Left == null)
                    {
                        currNode.Left = new TreeNode
                        {
                            Val = preorder[i]
                        };
                        nodeStack.Push(currNode.Left);
                    }
                
                    if (currNode.Val < preorder[i] && currNode.Right == null)
                    {
                        currNode.Right = new TreeNode
                        {
                            Val = preorder[i]
                        };
                        nodeStack.Push(currNode.Right);
                    }    
                }
                
            }
            

            return root;
        }
        
        private void AddValue
    }
}