using System.Collections.Generic;
using System.Diagnostics;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class BuildTreeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/196/";

        [Theory]
        [InlineData(new[] {3,9,20,15,7}, new[] { 9,3,15,20,7}, new[] {3,9,20,15,7})]
        public void BuildTreeTests(int[] preorder, int[] inorder, int[] expected)
        {
            var node = BuildTree(preorder, inorder);
            Debug.Assert(node != null, nameof(node) + " != null");
            var result = node.ToPreOrder();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
        
        Dictionary<int, int> index = new Dictionary<int, int>();
    
        private TreeNode? BuildTreeHelper(int[] preorder, int preStart, int[] inorder, int inStart, int inEnd){
        
            if (inStart > inEnd)
                return null;
        
            if (inStart == inEnd)
                return new TreeNode(inorder[inStart]);
        
            int rootVal = preorder[preStart];
            int inOrderIndex = index[rootVal];
        
            TreeNode root = new TreeNode(rootVal);
            int leftCount = inOrderIndex - inStart;
            root.left = BuildTreeHelper(preorder, preStart + 1, inorder, inStart, inOrderIndex - 1);
            root.right = BuildTreeHelper(preorder, preStart + leftCount + 1, inorder, inOrderIndex + 1, inEnd);
            return root;
        }
 
        public TreeNode? BuildTree(int[] preorder, int[] inorder) {
        
            for (int i = 0; i < inorder.Length; i++){
                index.Add(inorder[i], i);
            }        
            return BuildTreeHelper(preorder, 0, inorder, 0, inorder.Length - 1);      
        }
    }
}