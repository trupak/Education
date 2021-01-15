using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class HasCycleChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/184/";

        [Fact]
        public void HasCycleTests()
        {
            var node1 = new ListNode(3);
            var node2 = new ListNode(2);
            var node3 = new ListNode(0);
            var node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2;
            Assert.True(HasCycle(node1));

            node1 = new ListNode(1);
            Assert.False(HasCycle(node1));
        }
        
        public bool HasCycleHashSet(ListNode head)
        {
            var cache = new HashSet<ListNode>();
            var tmp = head;
            while (tmp != null)
            {
                if (cache.Contains(tmp))
                    return true;

                cache.Add(tmp);
                tmp = tmp.next;
            }

            return false;
        }

        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) {
                    return true;
                }
            }
            return false;
        }
    }
}