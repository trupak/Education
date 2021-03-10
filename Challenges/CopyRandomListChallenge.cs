using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ChallengesTests
{
    public class CopyRandomListChallenge : IChallenge
    {
        public class Node {
            // ReSharper disable once InconsistentNaming
            public readonly int val;
            // ReSharper disable once InconsistentNaming
            public Node? next;
            // ReSharper disable once InconsistentNaming
            public Node? random;
    
            public Node(int val) {
                this.val = val;
                next = null;
                random = null;
            }
        }
        
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/32/linked-list/168/";

        [Fact]
        public void CopyRandomListTest()
        {
            var l1 = new Node(7);
            var l2 = new Node(13);
            var l3 = new Node(11);
            var l4 = new Node(10);
            var l5 = new Node(1);
            
            l1.next = l2;
            l2.next = l3;
            l2.random = l1;
            l3.next = l4;
            l3.random = l5;
            l4.next = l5;
            l4.random = l3;
            l5.random = l1;

            var newNode = CopyRandomList(l1);
            while (newNode != null && l1 != null)
            {
                Assert.Equal(newNode.val, l1.val);
                if (l1.random == null)
                {
                    Assert.Null(newNode.random);
                }
                else
                {
                    Debug.Assert(newNode.random != null, "newNode.random != null");
                    Assert.Equal(newNode.random.val, l1.random.val);
                }
                
                newNode = newNode.next;
                l1 = l1.next;
            }

            Assert.Null(newNode);
            Assert.Null(l1);
        }
        
        public Node CopyRandomList(Node head)
        {
            var cache = new Dictionary<Node, Node>();
            var h = head;
            var result = new Node(-1);
            var tmp = result;
            while (h != null)
            {
                tmp.next = new Node(h.val);
                cache.Add(h, tmp.next);
                tmp = tmp.next;
                h = h.next;
            }

            h = head;
            tmp = result.next;
            while (h != null)
            {
                if (h.random != null)
                {
                    Debug.Assert(tmp != null, nameof(tmp) + " != null");
                    tmp.random = cache[h.random];
                }

                Debug.Assert(tmp != null, nameof(tmp) + " != null");
                tmp = tmp.next;
                h = h.next;
            }

            Debug.Assert(result.next != null, "result.next != null");
            return result.next;
        }
    }
}