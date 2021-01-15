using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class ReverseListChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/169/";

        [Fact]
        public void ReverseListTests()
        {
            checkReverse(new ListNode(new[] {1, 2, 3, 4, 5}), new int[] {5, 4, 3, 2, 1});
        }

        private void checkReverse(ListNode node, int[] expected)
        {
            var reversed = ReverseList(node).ToList();

            for (int i = 0; i < expected.Length; i++)
                Assert.Equal(expected[i], reversed[i]);
        }
        
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            
            ListNode prev = null;
            ListNode next = head.next;
            ListNode current = head;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            
            return prev;
        }
    }
}