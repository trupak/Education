using System;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class MaxPathSumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/532/week-5/3314/";

        [Fact]
        public void MaxPathSumTest1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            Assert.Equal(6, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest2()
        {
            var root = new TreeNode(-10)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            Assert.Equal(42, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest3()
        {
            var root = new TreeNode(-3);

            Assert.Equal(-3, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest4()
        {
            var root = new TreeNode(2)
            {
                left = new TreeNode(-1)
            };

            Assert.Equal(2, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest5()
        {
            var root = new TreeNode(-2)
            {
                left = new TreeNode(-1)
            };

            Assert.Equal(-1, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest6()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(-2)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(-1)
                    },
                    right = new TreeNode(3)  
                },
                right = new TreeNode(-3)
                {
                    left = new TreeNode(-2)
                }
            };

            Assert.Equal(3, MaxPathSum(root));
        }
        
        [Fact]
        public void MaxPathSumTest7()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(-2),
                right = new TreeNode(3)
            };

            Assert.Equal(4, MaxPathSum(root));
        }


        private int _maxSum = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumInner(root);
            return _maxSum;
        }
        public int MaxPathSumInner(TreeNode? root)
        {
            if (root == null)
                return 0;
            
            int leftSubTreeSize = Math.Max(MaxPathSumInner(root.left), 0);
            int rightSubTreeSize = Math.Max(MaxPathSumInner(root.right), 0);
            int priceNewPath = root.val + leftSubTreeSize + rightSubTreeSize;
            _maxSum = Math.Max(_maxSum, priceNewPath);
            return root.val + Math.Max(leftSubTreeSize, rightSubTreeSize);
        }
    }
}