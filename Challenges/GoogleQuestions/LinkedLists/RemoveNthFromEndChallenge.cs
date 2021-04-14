using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace ChallengesTests.GoogleQuestions.LinkedLists
{
    public class RemoveNthFromEndChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/60/linked-list-5/3064/";

        [Theory]
        [InlineData(new[] {1,2,3,4,5}, 2, new[] {1,2,3,5})]
        [InlineData(new[] {1,2,3}, 3, new[] {2,3})]
        [InlineData(new[] {1,2,3}, 1, new[] {1,2})]
        public void RemoveNthFromEndTests(int[] list, int n, int[] expected)
        {
            var result = RemoveNthFromEnd(new ListNode(list), n);
            Assert.Equal(expected, result.ToList().ToArray());
        }
        
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var queue = new Queue<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                if (queue.Count > n)
                    queue.Dequeue();
                
                queue.Enqueue(cur);
                cur = cur.next;
            }

            if (queue.Count == n)
                return head.next;

            if (queue.Count == 2)
                queue.Dequeue().next = null;
            else
            {
                var prev = queue.Dequeue();
                var next = queue.Dequeue();
                prev.next = next.next;
            }

            return head;
        }
    }
}