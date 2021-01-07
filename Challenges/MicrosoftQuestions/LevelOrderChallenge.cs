using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class LevelOrderChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/164/";
        
        [Theory]
        [InlineData(new int[] { 5,1,4,-1,-1,3,6 }, new int[] { 5,1,4,3,6})]
        public void LevelOrderTests(int[] tree, int[] expected)
        {
            var node = new TreeNode(tree);
            var result1 = LevelOrder(node);
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
        
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();
            
            IList<IList<int>> result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var r = new List<int>();
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    r.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                result.Add(r);
            }

            return result;
        }
    }
}