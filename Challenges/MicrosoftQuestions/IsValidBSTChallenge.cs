using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class IsValidBSTChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/152/";

        [Fact]
        public void IsValidBSTTest()
        {
            var node = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };
            Assert.True(IsValidBST(node));
            node = new TreeNode(5)
            {
                left = new TreeNode(1),
                right = new TreeNode(6)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(7)
                }
            };
            Assert.False(IsValidBST(node));
        }
        
        public bool IsValidBST(TreeNode root)
        {
            return CheckNode(root, null, null);
        }

        private bool CheckNode(TreeNode node, int? min, int? max)
        {
            if (node == null)
                return true;

            if ((min.HasValue && node.val <= min) 
                || (max.HasValue && node.val >= max))
                return false;

            return CheckNode(node.left, min, node.val) && CheckNode(node.right, node.val, max);
        }
    }
}