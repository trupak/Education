using System;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class DiametrTreeChallenge : IChallenge
    {
        public string Link =>
            "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/529/week-2/3293/";
        
        [Fact]
        public void DiameterOfBinaryTreeTest()
        {
            var node = new TreeNode
            {
                Val = 1,
                Left = new TreeNode
                {
                    Val = 2,
                    Left = new TreeNode
                    {
                        Val = 4
                    },
                    Right = new TreeNode
                    {
                        Val = 5
                    }
                },
                Right = new TreeNode
                {
                    Val = 3
                }
            };
            
            Assert.Equal(3, DiameterOfBinaryTree(node));
        }

        private int _ans;
        
        public int DiameterOfBinaryTree(TreeNode root) {
            _ans = 1;
            Depth(root);
            return _ans - 1;
        }
        private int Depth(TreeNode node) {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (node == null) return 0;
            var l = Depth(node.Left);
            var r = Depth(node.Right);
            _ans = Math.Max(_ans, l+r+1);
            return Math.Max(l, r) + 1;
        }
    }
}