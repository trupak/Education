using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class RemoveNthFromEndChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/595/week-3-april-15th-april-21st/3712/";
        
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
            var first = head;
            var second = head;
            for (int i = 0; i <= n; i++)
            {
                if (first == null)
                    return head.next;
                
                first = first.next;
            }

            while (first != null)
            {
                first = first.next;
                second = second.next;
            }

            second.next = second.next?.next;
            return head;
        }
    }
}