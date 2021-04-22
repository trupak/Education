using System.Diagnostics;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class FlipEquivChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3077/";

        [Theory]
        [InlineData(new[]{1,2,3,4,5,6,-1,-1,-1,7,8},new[] {1,3,2,-1,6,4,5,-1,-1,-1,-1,8,7},true)]
        public void FlipEquivTests(int[] tree1, int[] tree2, bool expected)
        {
            Assert.Equal(expected, FlipEquiv(new TreeNode(tree1), new TreeNode(tree2)));
        }
        
        public bool FlipEquiv(TreeNode? root1, TreeNode? root2) {
            if (root1 == null && root2 == null)
                return true;

            if (root1 == null && root2 != null || root2 == null && root1 != null)
                return false;

            Debug.Assert(root2 != null, nameof(root2) + " != null");
            Debug.Assert(root1 != null, nameof(root1) + " != null");
            if (root1.val != root2.val)
                return false;
            
            return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right) ||
                   FlipEquiv(root1.right, root2.left) && FlipEquiv(root1.left, root2.right);
        }
    }
}