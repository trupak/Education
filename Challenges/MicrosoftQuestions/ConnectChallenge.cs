using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class ConnectChallenge : IChallenge
    {
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/192/";

        [Fact]
        public void ConnectTest()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;
            node3.right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node7.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node5, node4.next);
            Assert.Equal(node6, node5.next);
            Assert.Equal(node7, node6.next);
        }
        
        [Fact]
        public void ConnectTest2()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node7 = new Node(7);

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node7.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node5, node4.next);
            Assert.Equal(node7, node5.next);
        }
        
        [Fact]
        public void ConnectTest3()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node7 = new Node(7);

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;

            node3.right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node7.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node7, node4.next);
        }
        
        [Fact]
        public void ConnectTest4()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node6 = new Node(6);
            var node7 = new Node(7);

            node1.left = node2;
            node1.right = node3;

            node3.left = node6;
            node3.right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node7.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node7, node6.next);
        }
        
        [Fact]
        public void ConnectTest5()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);
            var node8 = new Node(8);

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = node5;
            
            node3.right = node6;
            node4.left = node7;
            node6.right = node8;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node8.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node5, node4.next);
            Assert.Equal(node6, node5.next);
            Assert.Equal(node8, node7.next);
        }
        
        [Fact]
        public void ConnectTest6()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            var node7 = new Node(7);
            var node8 = new Node(8);

            node1.left = node2;
            node1.right = node3;

            node2.right = node4;
            
            node3.left = node5;
            node3.right = node6;
            
            node4.left = node7;
            node5.left = node8;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.next);
            Assert.Null(node3.next);
            Assert.Null(node6.next);
            Assert.Null(node8.next);
            
            Assert.Equal(node3, node2.next);
            Assert.Equal(node5, node4.next);
            Assert.Equal(node6, node5.next);
            Assert.Equal(node8, node7.next);
        }

        public Node Connect2(Node root)
        {
            UpdateNode(root, null);
            return root;
        }

        private void UpdateNode(Node root, Node prev)
        {
            if (root == null || root.left == null || root.right == null)
                return;

            root.left.next = root.right;
            if (prev != null)
                prev.next = root.left;
            
            UpdateNode(root.left, prev != null ? prev.right : null);
            UpdateNode(root.right, root.left.right);
        }

        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            var topLeft = root;
            while (topLeft != null)
            {
                var head = topLeft;
                while (head != null)
                {
                    if (head.left != null && head.right != null)
                        head.left.next = head.right;

                    if (head.left == null && head.right == null)
                    {
                        head = head.next;
                    }
                    else
                    {
                        var nextNode = head.next;
                        while (nextNode != null && nextNode.left == null && nextNode.right == null)
                        {
                            if (nextNode.left != null || nextNode.right != null)
                                break;
                            
                            nextNode = nextNode.next;
                        }

                        if (nextNode != null)
                        {
                            if (head.right != null)
                                head.right.next = nextNode.left != null ? nextNode.left : nextNode.right;
                            else
                                head.left.next = nextNode.left != null ? nextNode.left : nextNode.right;
                        }
                        
                        head = head.next;
                    }
                }

                var nextNode2 = topLeft;
                while (nextNode2 != null && nextNode2.left == null && nextNode2.right == null)
                {
                    if (nextNode2.left != null || nextNode2.right != null)
                        break;
                            
                    nextNode2 = nextNode2.next;
                }

                if (nextNode2 != null)
                {
                    topLeft = nextNode2.left != null ? nextNode2.left : nextNode2.right;    
                }
                else
                {
                    topLeft = null;
                }
            }
            
            return root;
        }
    }
}