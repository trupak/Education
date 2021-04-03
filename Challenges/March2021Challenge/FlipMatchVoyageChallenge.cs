using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class FlipMatchVoyageChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3689/";
        
        [Theory]
        [InlineData(new int[] {1,2,3}, new int[] {1,3,2}, new int[] {1})]
        [InlineData(new int[] {1,2}, new int[] {1,2}, new int[] {-1})]
        public void FlipMatchVoyageTests(int[] root, int[] voyage,int[] expected)
        {
            var node = new TreeNode(root);
            var result = FlipMatchVoyage(node, voyage);
            
            Assert.Equal(expected, result.ToArray());
        }
        
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            return null;
        }

        public bool IsFlip(TreeNode root, int a, int b)
        {
            if (root == null)
                return true;
        }
    }
}