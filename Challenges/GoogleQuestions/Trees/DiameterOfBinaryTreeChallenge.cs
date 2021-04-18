using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class DiameterOfBinaryTreeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3074/";

        [Theory]
        [InlineData(new[] {1,2,3,4,5}, 3)]
        [InlineData(new[] {1,2}, 1)]
        public void DiameterOfBinaryTreeTests(int[] tree, int expected)
        {
            var root = new TreeNode(tree);
            Assert.Equal(expected, DiameterOfBinaryTree(root));
        }
        
        public int DiameterOfBinaryTree(TreeNode root)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (root == null)
                return 0;

            var rootMax = MaxLength(root.left, 0) + MaxLength(root.right, 0);
            var left = DiameterOfBinaryTree(root.left);
            var right = DiameterOfBinaryTree(root.right);
            
            return Math.Max(rootMax, Math.Max(left,right));
        }

        private int MaxLength(TreeNode root, int max)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (root == null)
                return max;

            return Math.Max(MaxLength(root.left, max + 1), MaxLength(root.right, max + 1));
        }
    }
}