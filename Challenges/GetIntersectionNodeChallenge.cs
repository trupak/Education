using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace ChallengesTests
{
    public class GetIntersectionNodeChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/212/";

        [Fact]
        public void GetIntersectionNodeTest()
        {
            var l1 = new ListNode(new[] {1, 2, 3, 4, 5, 6});
            var l2 = new ListNode(new[] {7, 8, 9});
            var intersect = l1.next.next.next.next;
            l2.next.next.next = intersect;
            GetIntersectionNode(l1, l2);
            Assert.Equal(intersect, GetIntersectionNode(l1,l2));
        }
        
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            ListNode pa = headA, pb = headB;
            while (pa != pb) {
                pa = (pa != null) ? pa.next : headB;
                pb = (pb != null) ? pb.next : headA;
            }
            return pa;
        }
        
        public ListNode? GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            var hashset = new HashSet<ListNode>();
            
            while (headB != null)
            {
                hashset.Add(headB);
                headB = headB.next;
            }

            while (headA != null)
            {
                if (hashset.Contains(headA))
                    return headA;
                
                headA = headA.next;
            }
            
            return null;
        }
    }
}