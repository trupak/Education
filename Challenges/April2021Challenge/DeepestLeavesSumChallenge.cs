using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class DeepestLeavesSumChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3704/";

        [Theory]
        [InlineData(new[] {1,2,3,4,5,-1,6,7,-1,-1,-1,-1,8}, 15)]
        [InlineData(new[] {6,7,8,2,7,1,3,9,-1,1,4,-1,-1,-1,5}, 19)]
        [InlineData(new[] {50,-1,54,98,6,-1,-1,-1,34}, 34)]
        public void DeepestLeavesSumTests(int[] root, int expected)
        {
            var node = new TreeNode(root);
            Assert.Equal(expected, DeepestLeavesSum(node));
        }

        private int _maxDepth;
        private int _sum;

        public int DeepestLeavesSum(TreeNode root)
        {
            DeepestLeavesSum(root, 0);
            return _sum;
        }
        
        private void DeepestLeavesSum(TreeNode root, int depth)
        {
            if (root.left == null && root.right == null)
            {
                if (depth > _maxDepth)
                {
                    _sum = 0;
                    _maxDepth = depth;
                }
                
                if (depth == _maxDepth)
                    _sum += root.val;

                return ;
            }

            if (depth > _maxDepth)
            {
                _sum = 0;
                _maxDepth = depth;
            }
            
            if (root.left != null)
            {
                DeepestLeavesSum(root.left, depth + 1);
            }

            if (root.right != null)
            {
                DeepestLeavesSum(root.right, depth + 1);
            }
        }
    }
}