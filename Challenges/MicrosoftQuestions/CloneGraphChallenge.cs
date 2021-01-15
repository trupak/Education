using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.MicrosoftQuestions
{
    public class CloneGraphChallenge : IChallenge
    {
        public class Node {
            public int val;
            public IList<Node> neighbors;

            public Node() {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val) {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors) {
                val = _val;
                neighbors = _neighbors;
            }

            public Dictionary<int, List<int>> ToList()
            {
                var cache = new List<Node>();
                var result = new Dictionary<int, List<int>>();
                AddNode(this, cache, result);
                return result;
            }

            private void AddNode(Node node, List<Node> cache, Dictionary<int, List<int>> result)
            {
                if (cache.Contains(node))
                    return;
                
                cache.Add(node);
                result.Add(node.val, node.neighbors.Select(x => x.val).ToList());
                foreach (var nodeNeighbor in node.neighbors)
                {
                    AddNode(nodeNeighbor, cache, result);
                }
            }
        }
        
        public string Link
            => "https://leetcode.com/explore/interview/card/microsoft/31/trees-and-graphs/210/";

        [Fact]
        public void CloneGraphTest()
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            node1.neighbors = new List<Node> {node2, node4};
            node2.neighbors = new List<Node> {node1, node3};
            node3.neighbors = new List<Node> {node2, node4};
            node4.neighbors = new List<Node> {node1, node3};
            var result = CloneGraph(node1);
            Assert.NotEqual(node1, result);
            var start = node1.ToList();
            var end = result.ToList();
            foreach (var nodeExpected in start.Keys)
            {
                Assert.True(end.ContainsKey(nodeExpected));
                for (int i = 0; i < start[nodeExpected].Count; i++)
                {
                    Assert.Equal(start[nodeExpected][i], end[nodeExpected][i]);
                }
            }
        }

        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;
            
            var cache = new HashSet<Node>();
            var createdCache = new Dictionary<Node, Node>();
            
            var rootNode = new Node(node.val);
            createdCache.Add(node, rootNode);
            AddNode(node, rootNode, cache, createdCache);
            return rootNode;
        }

        private void AddNode(Node source, Node dest, HashSet<Node> cache, Dictionary<Node, Node> created)
        {
            if (cache.Contains(source))
                return;

            cache.Add(source);
            
            foreach (var sourceNeighbor in source.neighbors)
            {
                Node? newNode = null;
                if (created.ContainsKey(sourceNeighbor))
                {
                    newNode = created[sourceNeighbor];
                }
                else
                {
                    newNode = new Node(sourceNeighbor.val);
                    created.Add(sourceNeighbor, newNode);
                }
                dest.neighbors.Add(newNode);    
            }
            
            
            foreach (var sourceNeighbor in source.neighbors)
            {
                AddNode(sourceNeighbor, created[sourceNeighbor], cache, created);
            }
        }
    }
}