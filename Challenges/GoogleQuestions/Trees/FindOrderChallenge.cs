using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class FindOrderChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/3070/";

        [Theory]
        [InlineData(2, "[[1,0]]", new[] {0,1})]
        [InlineData(4, "[[1,0],[2,0],[3,1],[3,2]]", new[] {0,1,2,3})]
        [InlineData(1, "[]", new[] {0})]
        [InlineData(2, "[]", new[] {0,1})]
        [InlineData(4, "[[3,0],[0,1]]", new[] {1,2,0,3})]
        public void FindOrderTests(int numCourses, string prerequisites, int[] expected)
        {
            Assert.Equal(expected, FindOrder(numCourses, prerequisites.ToMatrix()));
        }
        
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var result = new List<int>();
            var allNode = new HashSet<int>();
            var dependant = new HashSet<int>();
            for (int i = allNode.Count; i < numCourses; i++)
                allNode.Add(i);
            
            while (result.Count < numCourses)
            {
                dependant.Clear();
                for (int i = 0; i < prerequisites.Length; i++)
                {
                    if (!allNode.Contains(prerequisites[i][1]))
                        continue;
                
                    dependant.Add(prerequisites[i][0]);
                }

                var newNodeFound = false;
                var forRemove = new List<int>();
                foreach (var node in allNode)
                {
                    if (!dependant.Contains(node))
                    {
                        result.Add(node);
                        forRemove.Add(node);
                        newNodeFound = true;
                    }
                }

                foreach (var remove in forRemove)
                    allNode.Remove(remove);
                
                if (!newNodeFound)
                    return new int[0];
            }
            
            return result.ToArray();
        }
    }
}