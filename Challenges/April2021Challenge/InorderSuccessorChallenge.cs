using System.Collections.Generic;
using System.Diagnostics;
using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class InorderSuccessorChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3700/";

        [Theory]
        [InlineData(new [] {2,1,3}, 1, 2)]
        [InlineData(new [] {5,3,6,2,4,-1,-1,1}, 6, null)]
        [InlineData(new [] {6,2,8,0,4,7,9,-1,-1,3,5}, 2, 3)]
        public void InorderSuccessorTests(int[] tree, int p, int? expected)
        {
            var treeNode = new TreeNode(tree);
            var pNode = treeNode.Search(p);
            var result = InorderSuccessor(treeNode, pNode);
            if (expected == null)
            {
                Assert.Null(result);
            }
            else
            {
                Debug.Assert(result != null, nameof(result) + " != null");
                Assert.Equal(expected, result.val);
            }
        }
        
        public TreeNode? InorderSuccessor(TreeNode root, TreeNode p)
        {
            var stack = new Stack<TreeNode>();
            var cur = root;
            var found = false;
            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                cur = stack.Pop();
                if (found)
                    return cur;
                
                if (Equals(cur, p))
                    found = true;
                
                cur = cur.right;
            }
            
            return null;
        }
    }
}