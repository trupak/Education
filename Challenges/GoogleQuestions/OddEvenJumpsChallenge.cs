using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChallengesTests.GoogleQuestions
{
    public class OddEvenJumpsChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/interview/card/google/67/sql-2/3045/";
        
        [Theory]
        [InlineData(new[] {5,1,3,4,2}, 3)]
        [InlineData(new[] {10,13,12,14,15}, 2)]
        [InlineData(new[] {1,2,3,2,1,4,4,5}, 6)]
        public void OddEvenJumpsTests(int[] arr, int expected) {
            Assert.Equal(expected, OddEvenJumps(arr));
        }
        
        public int OddEvenJumps(int[] a) {
            var length = a.Length;
            if (length <= 1) return length;
            var odd = new bool[length];
            var even = new bool[length];
            odd[length-1] = even[length-1] = true;

            var values = new Dictionary<int,int>();
            values.Add(a[length-1], length-1);
            for (var i = length-2; i >= 0; --i) {
                var v = a[i];
                if (values.ContainsKey(v)) {
                    odd[i] = even[values[v]];
                    even[i] = odd[values[v]];
                } else
                {
                    var lowerKeys = values.Keys.Where(x => x < v)
                        .OrderBy(x => x).ToList();
                    var lower = lowerKeys.Any() ? lowerKeys.LastOrDefault() : int.MinValue;
                    var higherKeys = values.Keys.Where(x => x > v)
                        .OrderBy(x => x).ToList();
                    var higher = higherKeys.Any() ? higherKeys.FirstOrDefault() : int.MinValue;

                    if (lower != int.MinValue)
                        even[i] = odd[values[lower]];
                    if (higher != int.MinValue) {
                        odd[i] = even[values[higher]];
                    }
                }

                if (!values.ContainsKey(v))
                    values.Add(v, i);
                else
                    values[v] = i;
            }

            int ans = 0;
            foreach (var b in odd)
            {
                if (b) ans++;
            }
            
            return ans;
        }
    }
}