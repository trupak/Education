using System.Diagnostics;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class LowestCommonAncestorChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/182/";

        [Theory]
        [InlineData(new[] { 6,2,8,0,4,7,9,-1,-1,3,5 }, 2, 8, 6)]
        [InlineData(new[] { 6,2,8,0,4,7,9,-1,-1,3,5 }, 0, 4, 2)]
        [InlineData(new[] { 2,1 }, 1, 2, 2)]
        public void LowestCommonAncestorBstTest(int[] tree, int p, int q, int expected)
        {
            var root = new TreeNode(tree);
            var pNode = root.Search(p);
            var qNode = root.Search(q);
            var result = LowestCommonAncestorBst(root, pNode, qNode);
            
            Assert.NotNull(result);
            Assert.Equal(expected, result.val);
        }
        
        [Theory]
        [InlineData(new[] { 6,2,8,0,4,7,9,-1,-1,3,5 }, 2, 8, 6)]
        [InlineData(new[] { 6,2,8,0,4,7,9,-1,-1,3,5 }, 0, 4, 2)]
        [InlineData(new[] { 3,5,1,6,2,0,8,-1,-1,7,4 }, 5, 1, 3)]
        [InlineData(new[] { 3,5,1,6,2,0,8,-1,-1,7,4 }, 5, 4, 5)]
        [InlineData(new[] { 2,1 }, 1, 2, 2)]
        public void LowestCommonAncestorTest(int[] tree, int p, int q, int expected)
        {
            var root = new TreeNode(tree);
            var pNode = root.Search(p);
            var qNode = root.Search(q);
            var result = LowestCommonAncestor(root, pNode, qNode);
            
            Assert.NotNull(result);
            Debug.Assert(result != null, nameof(result) + " != null");
            Assert.Equal(expected, result.val);
        }

        private TreeNode? _ans;
        
        public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Recurse(root, p, q);
            return _ans;
        }
        
        public bool Recurse(TreeNode? root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return false;

            var left = Recurse(root.left, p, q) ? 1 : 0;
            var right = Recurse(root.right, p, q) ? 1 : 0;
            var mid = root == p || root == q ? 1 : 0;
            
            if (mid + left + right >= 2) {
                _ans = root;
            }
            
            return (mid + left + right) > 0;
        }
        
        public static TreeNode LowestCommonAncestorBst(TreeNode root, TreeNode p, TreeNode q)
        {
            var result = root;
            while (result != null)
            {
                if (result.val > q.val && result.val > p.val)
                    result = result.left;
                else if (result.val < q.val && result.val < p.val)
                    result = result.right;
                else
                    return result;
            }
            
            return null!;
        }
    }
}