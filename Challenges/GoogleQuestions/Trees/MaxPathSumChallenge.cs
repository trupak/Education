using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class MaxPathSumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3067/";

        [Theory]
        [InlineData(new[] {-3}, -3)]
        [InlineData(new[] {3, -2, -1}, 3)]
        [InlineData(new[] {2,1,3}, 6)]
        [InlineData(new[] {-10,9,20,-1,-1,15,7}, 42)]
        [InlineData(new[] {9,6,-3,-1,-1,-6,2,-1,-1,2,-1,-6,-6,-6}, 16)]
        public void MaxPathSumTests(int[] tree, int expected)
        {
            var root = new TreeNode(tree);
            Assert.Equal(expected, MaxPathSum(root));
        }

        public int MaxPathSum(TreeNode root)
        {
            var left = Math.Max(root.left != null ? MaxPathSum(root.left, 0) : 0, 0);
            var right = Math.Max(root.right != null ? MaxPathSum(root.right, 0) : 0, 0);
            var sum = root.val + left + right;
            var sumLeft = root.left != null ? MaxPathSum(root.left) : int.MinValue;
            var sumRight = root.right != null ? MaxPathSum(root.right) :  int.MinValue;
            
            return Math.Max(sum, Math.Max(sumLeft, sumRight));
        }
        
        public int MaxPathSum(TreeNode root, int parentSum)
        {
            var left = root.left != null ? MaxPathSum(root.left, parentSum) : parentSum;
            var right = root.right != null ? MaxPathSum(root.right, parentSum) : parentSum;

            return Math.Max(Math.Max(left, right),0) + root.val;
        }
    }
}