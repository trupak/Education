using System.Diagnostics;
using Xunit;

namespace ChallengesTests
{
    public class ConnectChallenge : IChallenge
    {
        public class Node {
            public Node? Left;
            public Node? Right;
            public Node? Next;

            public Node()
            {
                
            }
            
            public Node(Node left, Node right, Node next) {
                this.Left = left;
                this.Right = right;
                this.Next = next;
            }
        }
        
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/192/";

        [Fact]
        public void ConnectTest()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Left = node6;
            node3.Right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node7.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node5, node4.Next);
            Assert.Equal(node6, node5.Next);
            Assert.Equal(node7, node6.Next);
        }
        
        [Fact]
        public void ConnectTest2()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node7 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node7.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node5, node4.Next);
            Assert.Equal(node7, node5.Next);
        }
        
        [Fact]
        public void ConnectTest3()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node7 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;

            node3.Right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node7.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node7, node4.Next);
        }
        
        [Fact]
        public void ConnectTest4()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node6 = new Node();
            var node7 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node3.Left = node6;
            node3.Right = node7;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node7.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node7, node6.Next);
        }
        
        [Fact]
        public void ConnectTest5()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();
            var node8 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;
            
            node3.Right = node6;
            node4.Left = node7;
            node6.Right = node8;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node8.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node5, node4.Next);
            Assert.Equal(node6, node5.Next);
            Assert.Equal(node8, node7.Next);
        }
        
        [Fact]
        public void ConnectTest6()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();
            var node8 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Right = node4;
            
            node3.Left = node5;
            node3.Right = node6;
            
            node4.Left = node7;
            node5.Left = node8;

            var newNode = Connect(node1);
            Assert.Equal(newNode, node1);
            Assert.Null(node1.Next);
            Assert.Null(node3.Next);
            Assert.Null(node6.Next);
            Assert.Null(node8.Next);
            
            Assert.Equal(node3, node2.Next);
            Assert.Equal(node5, node4.Next);
            Assert.Equal(node6, node5.Next);
            Assert.Equal(node8, node7.Next);
        }

        public Node Connect2(Node root)
        {
            UpdateNode(root, null);
            return root;
        }

        private void UpdateNode(Node root, Node? prev)
        {
            if (root.Left == null || root.Right == null)
                return;

            root.Left.Next = root.Right;
            if (prev != null)
                prev.Next = root.Left;
            
            UpdateNode(root.Left, prev != null ? prev.Right : null);
            UpdateNode(root.Right, root.Left.Right);
        }

        public Node Connect(Node root)
        {
            var topLeft = root;
            while (topLeft != null)
            {
                var head = topLeft;
                while (head != null)
                {
                    if (head.Left != null && head.Right != null)
                        head.Left.Next = head.Right;

                    if (head.Left == null && head.Right == null)
                    {
                        head = head.Next;
                    }
                    else
                    {
                        var nextNode = head.Next;
                        while (nextNode != null && nextNode.Left == null && nextNode.Right == null)
                        {
                            if (nextNode.Left != null || nextNode.Right != null)
                                break;
                            
                            nextNode = nextNode.Next;
                        }

                        if (nextNode != null)
                        {
                            if (head.Right != null)
                                head.Right.Next = nextNode.Left != null ? nextNode.Left : nextNode.Right;
                            else
                            {
                                Debug.Assert(head.Left != null, "head.Left != null");
                                head.Left.Next = nextNode.Left != null ? nextNode.Left : nextNode.Right;
                            }
                        }
                        
                        head = head.Next;
                    }
                }

                var nextNode2 = topLeft;
                while (nextNode2 != null && nextNode2.Left == null && nextNode2.Right == null)
                {
                    if (nextNode2.Left != null || nextNode2.Right != null)
                        break;
                            
                    nextNode2 = nextNode2.Next;
                }

                if (nextNode2 != null)
                {
                    topLeft = nextNode2.Left != null ? nextNode2.Left : nextNode2.Right;    
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