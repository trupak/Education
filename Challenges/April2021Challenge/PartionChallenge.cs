using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class PartionChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3707/";

        
        [Theory]
        [InlineData(new[] {1,4,3,2,5,2}, 3, new[] {1,2,2,4,3,5})]
        [InlineData(new[] {2,1}, 2, new[] {1,2})]
        public void PartionTests(int[] list, int x, int[] expected)
        {
            var result = Partition(new ListNode(list), x);
            Assert.Equal(expected, result.ToList().ToArray());
        }
        
        public ListNode Partition(ListNode head, int x)
        {
            ListNode less = null;
            ListNode more = null;
            ListNode cur = head;
            ListNode lessHead = null;
            ListNode moreHead = null;
            while (cur != null)
            {
                var tmp = cur;
                if (cur.val < x)
                {
                    if (less == null)
                    {
                        less = cur;
                        lessHead = less;
                    }
                    else
                    {
                        less.next = cur;
                        less = less.next;
                    }
                }
                else
                {
                    if (more == null)
                    {
                        moreHead = cur;
                        more = cur;
                    }
                    else
                    {
                        more.next = cur;
                        more = more.next;
                    }
                }

                cur = tmp.next;
            }

            if (more != null)
                more.next = null;

            if (less != null)
                less.next = null;
            
            if (lessHead == null)
                return moreHead;
            
            if (less != null)
                less.next = moreHead;
            
            return lessHead;
        }
    }
}