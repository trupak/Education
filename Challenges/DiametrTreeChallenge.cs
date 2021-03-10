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
                val = 1,
                left = new TreeNode
                {
                    val = 2,
                    left = new TreeNode
                    {
                        val = 4
                    },
                    right = new TreeNode
                    {
                        val = 5
                    }
                },
                right = new TreeNode
                {
                    val = 3
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
            var l = Depth(node.left);
            var r = Depth(node.right);
            _ans = Math.Max(_ans, l+r+1);
            return Math.Max(l, r) + 1;
        }
    }
}