using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class CopyRandomListChallenge : IChallenge
    {
        public class Node {
            public int val;
            public Node next;
            public Node random;
    
            public Node(int _val) {
                val = _val;
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
                    tmp.random = cache[h.random];
                
                tmp = tmp.next;
                h = h.next;
            }
            
            return result.next;
        }
    }
}