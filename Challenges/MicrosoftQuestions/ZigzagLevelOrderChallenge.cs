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
        [InlineData(new int[] { 5,1,4,-1,-1,3,6 }, new int[] { 5,4,1,3,6})]
        [InlineData(new int[] { 1,2,3,4,-1,-1,5 }, new int[] { 1,3,2,4,5})]
        [InlineData(new int[] { 0,2,4,1,-1,3,-10,5,1,-1,6,-1,8 }, new int[] { 0,4,2,1,3,-10,8,6,1,5})]
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
            if (root == null)
                return new List<IList<int>>();

            var result = new List<IList<int>>();
            var linkedList = new LinkedList<TreeNode>();
            linkedList.AddFirst(root);
            var isNextLineLeft = false;
            while (linkedList.Count > 0)
            {
                var r = new List<int>();
                var size = linkedList.Count;
                var startNode = isNextLineLeft ? linkedList.First : linkedList.Last;
                for (int i = 0; i < size; i++)
                {
                    if (isNextLineLeft)
                    {
                        var node = linkedList.First.Value;
                        linkedList.RemoveFirst();
                        if (r.Count == 0)
                        {
                            r.Add(node.val);
                        }
                        else
                        {
                            r.Insert(0,node.val);
                        }
                        if (node.left != null)
                            linkedList.AddLast(node.left);
                        
                        if (node.right != null)
                            linkedList.AddLast(node.right);
                    }
                    else
                    {
                        var node = startNode.Value;
                        if (r.Count == 0)
                        {
                            r.Add(node.val);
                        }
                        else
                        {
                            r.Insert(0,node.val);
                        }
                        
                        if (node.left != null)
                            linkedList.AddLast(node.left);
                    
                        if (node.right != null)
                            linkedList.AddLast(node.right);
                        var tmp = startNode.Previous;
                        linkedList.Remove(startNode);
                        startNode = tmp;
                    }
                        
                }

                isNextLineLeft = !isNextLineLeft;
                result.Add(r);
            }
            
            return result;
        }
    }
}