using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.GoogleQuestions.Trees
{
    public class CalcEquationChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/google/61/trees-and-graphs/331/";

        [Fact]
        public void CalcEquationTests()
        {
            var equations = new List<IList<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b", "c"}
            };
            var values = new double[] {2, 3};
            var queries = new List<IList<string>>
            {
                new List<string>
                {
                    "a", "c"
                },
                new List<string>
                {
                    "b", "a"
                },
                new List<string>
                {
                    "a", "e"
                },
                new List<string>
                {
                    "a", "a"
                },
                new List<string>
                {
                    "x", "x"
                }
            };
            var result = CalcEquation(equations, values, queries);
            var expected = new double[] {6.0, 0.5, -1.0, 1.0, -1.0};
            Assert.Equal(expected, result);
        }

        public double[] CalcEquation(IList<IList<string>> equations, double[] values,
            IList<IList<string>> queries)
        {

            var graph = new Dictionary<string, Dictionary<string, double>>();

            // Step 1). build the graph from the equations
            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                var dividend = equation[0];
                var divisor = equation[1];
                double quotient = values[i];

                if (!graph.ContainsKey(dividend))
                    graph.Add(dividend, new Dictionary<string, double>());
                if (!graph.ContainsKey(divisor))
                    graph.Add(divisor, new Dictionary<string, double>());

                graph[dividend].Add(divisor, quotient);
                graph[divisor].Add(dividend, 1 / quotient);
            }

            // Step 2). Evaluate each query via bactracking (DFS)
            // by verifying if there exists a path from dividend to divisor
            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                var dividend = query[0];
                var divisor = query[1];

                if (!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor))
                    results[i] = -1.0;
                else if (dividend == divisor)
                    results[i] = 1.0;
                else
                {
                    var visited = new HashSet<string>();
                    results[i] = backtrackEvaluate(graph, dividend, divisor, 1, visited);
                }
            }

            return results;
        }

        private double backtrackEvaluate(Dictionary<string, Dictionary<string, double>> graph, string currNode,
            string targetNode, double accProduct, HashSet<string> visited)
        {
            // mark the visit
            visited.Add(currNode);
            double ret = -1.0;

            Dictionary<string, double> neighbors = graph[currNode];
            if (neighbors.ContainsKey(targetNode))
                ret = accProduct * neighbors[targetNode];
            else
            {
                foreach (var pair in neighbors)
                {
                    var nextNode = pair.Key;
                    if (visited.Contains(nextNode))
                        continue;
                    ret = backtrackEvaluate(graph, nextNode, targetNode,
                        accProduct * pair.Value, visited);
                    if (ret != -1.0)
                        break;
                }
            }

            // unmark the visit, for the next backtracking
            visited.Remove(currNode);
            return ret;
        }
    }
}