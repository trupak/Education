using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class MergeTwoListsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/175/";

        [Theory]
        [InlineData(new int[] {1,2,4}, new int[] {1,3,4}, new int[] {1,1,2,3,4,4})]
        [InlineData(new int[] {}, new int[] {}, new int[] {})]
        [InlineData(new int[] {}, new int[] {0}, new int[] {0})]
        public void MergeTwoListsTests(int[] l1, int[] l2, int[] expected)
        {
            var result = MergeTwoLists(l1 == null || l1.Length == 0 ?
                null : new ListNode(l1), l2 == null || l2.Length == 0 ? null : 
                new ListNode(l2));
            
            var merged = result != null ? result.ToList() : new List<int>();

            Assert.Equal(expected.Length, merged.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], merged[i]);
            }
        }

        [Fact]
        public void MergeKListsTests()
        {
            var result = MergeKLists(new ListNode[]
            {
                new ListNode(new int[] {1, 4, 5}),
                new ListNode(new int[] {1, 3, 4}),
                new ListNode(new int[] {2, 6})
            });

            var merged = result != null ? result.ToList() : new List<int>();
            
            var expected = new int[] {1, 1, 2, 3, 4, 4, 5, 6};
            
            Assert.Equal(expected.Length, merged.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], merged[i]);
            }
        }
        
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            var current = result;
            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    current.next = l2;
                    l2 = l2.next;
                    current = current.next;
                    continue;
                }
                
                if (l2 == null)
                {
                    current.next = l1;
                    l1 = l1.next;
                    current = current.next;
                    continue;
                }
                
                var x1 = l1.val;
                var x2 = l2.val;
                if (x1 < x2)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }

                current = current.next;
            }
            return result.next;
        }
        
        public ListNode MergeKLists(ListNode[] lists)
        {
            var result = new ListNode(0);
            var current = result;
            while (lists.Any(x => x != null))
            {
                ListNode minNode = new ListNode(int.MaxValue);

                var minIndex = -1;
                for (var index = 0; index < lists.Length; index++)
                {
                    var listNode = lists[index];
                    if (listNode == null)
                        continue;

                    if (minNode.val > listNode.val)
                    {
                        minIndex = index;
                        minNode = listNode;
                    }
                }

                current.next = minNode;
                current = current.next;
                lists[minIndex] = lists[minIndex].next;
            }
            return result.next;
        }
    }
}