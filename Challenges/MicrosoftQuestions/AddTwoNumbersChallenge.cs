using System;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class AddTwoNumbersChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/170/";

        [Theory]
        [InlineData(new int[] {7,2,4,3}, new int[] {5,6,4}, new int[]{7,8,0,7})]
        [InlineData(new int[] {5}, new int[] {5}, new int[]{1, 0})]
        [InlineData(new int[] {0}, new int[] {0}, new int[]{0})]
        [InlineData(new int[] {4}, new int[] {5}, new int[]{9})]
        [InlineData(new int[] {9}, new int[] {9}, new int[]{1, 8})]
        [InlineData(new int[] {0}, new int[] {7,3}, new int[]{7, 3})]
        public void AddTwoNumbersTests(int[] ll1, int[] ll2, int[] expected)
        {
            var l1 = new ListNode(ll1);
            var l2 = new ListNode(ll2);
            var result = AddTwoNumbers(l1, l2).ToList();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }


        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }

            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return dummyHead.next;
        }
        
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var tmpL1 = l1;
            var tmpL2 = l2;
            while (tmpL1 != null && tmpL2 != null)
            {
                tmpL1 = tmpL1.next;
                tmpL2 = tmpL2.next;
            }

            if (tmpL1 != null && tmpL2 == null)
            {
                while (tmpL1 != null)
                {
                    l2 = new ListNode(0, l2);
                    tmpL1 = tmpL1.next;    
                }
            }
            
            if (tmpL2 != null && tmpL1 == null)
            {
                while (tmpL2 != null)
                {
                    l1 = new ListNode(0, l1);
                    tmpL2 = tmpL2.next;    
                }
            }
            
            ListNode result = new ListNode(0);
            ListNode current = result;
            l1 = new ListNode(0, l1);
            l2 = new ListNode(0, l2);
            while (l1 != null && l2 != null)
            {
                current.next = new ListNode((l1.val + l2.val + carry(l1, l2)) % 10);
                current = current.next;
                l1 = l1.next;
                l2 = l2.next;
            }

            while (result != null && result.val == 0)
            {
                result = result.next;
            }
            
            return result != null ? result : new ListNode(0);
        }

        private int carry(ListNode l1, ListNode l2)
        {
            if (l1.next == null || l2.next == null)
                return 0;

            var tmpl1 = l1;
            var tmpl2 = l2;
            while (tmpl1 != null && tmpl2 != null)
            {
                tmpl1 = tmpl1.next;
                tmpl2 = tmpl2.next;
                if (tmpl1 == null || tmpl2 == null)
                    return 0;
                
                if (tmpl1.val + tmpl2.val < 9)
                    return 0;

                if (tmpl1.val + tmpl2.val >= 10)
                    return 1;
            }

            return 1;
        }
    }
}