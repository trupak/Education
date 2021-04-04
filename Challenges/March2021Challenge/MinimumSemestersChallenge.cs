using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class MinimumSemestersChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/592/week-5-march-29th-march-31st/3688/";

        [Fact]
        public void MinimumSemestersTests()
        {
            var n = 3;
            var relations = new[]
            {
                new[] {1, 3},
                new[] {2, 3},
            };
            var result = MinimumSemesters(n, relations);
            Assert.Equal(2, result);
            
            n = 3;
            relations = new[]
            {
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 1},
            };
            result = MinimumSemesters(n, relations);
            Assert.Equal(-1, result);
        }
        
        public int MinimumSemesters(int n, int[][] relations)
        {
            var dependedCourses = new HashSet<int>();
            var learnedCourses = new HashSet<int>();
            var newCourses = true;
            var semesters = 0;
            while (newCourses)
            {
                semesters++;
                newCourses = false;
                dependedCourses.Clear();
                for (int i = 0; i < relations.Length; i++)
                {
                    if (learnedCourses.Contains(relations[i][0]))
                        continue;
                    
                    dependedCourses.Add(relations[i][1]);
                }

                for (int i = 1; i <= n; i++)
                {
                    if (learnedCourses.Contains(i) || dependedCourses.Contains(i))
                        continue;

                    newCourses = true;
                    learnedCourses.Add(i);
                }

                if (learnedCourses.Count == n)
                    return semesters;
                
                if (dependedCourses.Count == 0)
                    break;
            }
            return -1;
        }
    }
}