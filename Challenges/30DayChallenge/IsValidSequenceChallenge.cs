using System.Reflection.Metadata.Ecma335;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class IsValidSequenceChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/532/week-5/3315/";

        [Fact]
        public void IsValidSequenceTest1()
        {
            var root = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0)
                    {
                        left = new TreeNode(1)
                    },
                    right = new TreeNode(1)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(0)
                    }
                },
                right = new TreeNode(0)
                {
                    right = new TreeNode(0)
                }
            };
            
            Assert.True(IsValidSequence(root, new []{0,1,0,1}));
        }
        
        [Fact]
        public void IsValidSequenceTest2()
        {
            var root = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0)
                    {
                        right = new TreeNode(1)
                    },
                    right = new TreeNode(1)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(0)
                    }
                },
                right = new TreeNode(0)
                {
                    right = new TreeNode(0)
                }
            };
            
            Assert.False(IsValidSequence(root, new []{0,0,1}));
        }
        
        [Fact]
        public void IsValidSequenceTest3()
        {
            var root = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0)
                    {
                        right = new TreeNode(1)
                    },
                    right = new TreeNode(1)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(0)
                    }
                },
                right = new TreeNode(0)
                {
                    right = new TreeNode(0)
                }
            };
            
            Assert.False(IsValidSequence(root, new []{0,1,1}));
        }
        
        [Fact]
        public void IsValidSequenceTest4()
        {
            var root = new TreeNode(8)
            {
                right = new TreeNode(3)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(1)
                },
                left = new TreeNode(2)
            };
            
            Assert.False(IsValidSequence(root, new []{8}));
        }
        
        [Fact]
        public void IsValidSequenceTest5()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(2)
                    {
                        right = new TreeNode(2)
                        {
                            left = new TreeNode(9),
                            right = new TreeNode(3)
                        }
                    }
                },
            };
            
            Assert.False(IsValidSequence(root, new []{3,0}));
        }
        
        public bool IsValidSequence(TreeNode root, int[] arr)
        {
            return IsValidSequenceInternal(root, arr, 0);
        }

        public bool IsValidSequenceInternal(TreeNode root, int[] arr, int startIndex)
        {
            if (root == null)
                return false;

            if (root.val != arr[startIndex])
                return false;
            
            if (startIndex == arr.Length - 1)
            {
                return root.val == arr[startIndex]
                       && root.left == null
                       && root.right == null;
            } 

            return IsValidSequenceInternal(root.left, arr, startIndex + 1) ||
                   IsValidSequenceInternal(root.right, arr, startIndex + 1);
        }
    }
}