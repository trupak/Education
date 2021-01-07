using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class InorderTraversalChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/153/";

        [Theory]
        [InlineData(new int[] { 5,1,4,-1,-1,3,6 }, new int[] { 1, 5, 3, 4, 6})]
        public void InorderTraversalTests(int[] tree, int[] expected)
        {
            var node = new TreeNode(tree);
            var result = InorderTraversal(node);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
        
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>();
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var current = root;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                result.Add(current.val);
                current = current.right;
            }
            
            return result;
        }
        
        public IList<int> InorderTraversal2(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var result = new List<int>();
            
            result.AddRange(InorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(InorderTraversal(root.right));
            
            return result;
        }
    }
}