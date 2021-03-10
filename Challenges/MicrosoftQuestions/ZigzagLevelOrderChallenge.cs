using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class ZigzagLevelOrderChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/197/";
        
        [Theory]
        [InlineData(new[] { 5,1,4,-1,-1,3,6 }, new[] { 5,4,1,3,6})]
        [InlineData(new[] { 1,2,3,4,-1,-1,5 }, new[] { 1,3,2,4,5})]
        [InlineData(new[] { 0,2,4,1,-1,3,-10,5,1,-1,6,-1,8 }, new[] { 0,4,2,1,3,-10,8,6,1,5})]
        public void ZigzagLevelOrderTests(int[] tree, int[] expected)
        {
            var node = new TreeNode(tree);
            var result1 = ZigzagLevelOrder(node);
            var result = new List<int>();
            for (int i = 0; i < result1.Count; i++)
            {
                result.AddRange(result1[i]);
            }
            
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
        
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            var linkedList = new Stack<TreeNode>();
            linkedList.Push(root);
            var isNextLineLeft = false;
            while (linkedList.Count > 0)
            {
                var r = new List<int>();
                var tmpStack = new Queue<TreeNode>();
                var size = linkedList.Count;
                for (int i = 0; i < size; i++)
                {
                    if (isNextLineLeft)
                    {
                        var node = linkedList.Pop();
                        r.Add(node.val);
                        if (node.right != null)
                            tmpStack.Enqueue(node.right);
                        
                        if (node.left != null)
                            tmpStack.Enqueue(node.left);
                    }
                    else
                    {
                        var node = linkedList.Pop();
                        r.Add(node.val);
                        if (node.left != null)
                            tmpStack.Enqueue(node.left);
                        
                        if (node.right != null)
                            tmpStack.Enqueue(node.right);
                    }
                        
                }

                foreach (var treeNode in tmpStack)
                    linkedList.Push(treeNode);

                isNextLineLeft = !isNextLineLeft;
                result.Add(r);
            }
            
            return result;
        }
    }
}