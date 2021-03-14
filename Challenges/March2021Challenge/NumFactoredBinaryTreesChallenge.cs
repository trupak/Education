using System.Collections.Generic;
using Xunit;

namespace ChallengesTests.March2021Challenge
{
    public class NumFactoredBinaryTreesChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/march-leetcoding-challenge-2021/589/week-2-march-8th-march-14th/3670/";

        [Theory]
        [InlineData(new[]{2}, 1)]
        [InlineData(new[]{2,4}, 3)]
        [InlineData(new[]{2,3,6}, 5)]
        [InlineData(new[]{2,4,5,10}, 7)]
        [InlineData(new[]{18,3,6,2}, 12)]
        [InlineData(new[]{45,42,2,18,23,1170,12,41,40,9,47,24,33,28,10,32,29,17,46,11,759,37,6,26,21,49,31,14,19,8,13,7,27,22,3,36,34,38,39,30,43,15,4,16,35,25,20,44,5,48},777)]
        public void NumFactoredBinaryTreesTests(int[] arr, int expected)
        {
            Assert.Equal(expected, NumFactoredBinaryTrees(arr));
        }

        private Dictionary<int, List<(int, int)>> _mCache = new Dictionary<int, List<(int, int)>>();
        private Dictionary<int, int> _countCache = new Dictionary<int, int>();
        
        public int NumFactoredBinaryTrees(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (_mCache.ContainsKey(arr[i] * arr[j]))
                    {
                        _mCache[arr[i] * arr[j]].Add((arr[i], arr[j]));
                    }
                    else
                    {
                        _mCache[arr[i] * arr[j]] = new List<(int, int)>
                        {
                            (arr[i], arr[j])
                        };
                    }
                    
                    if (arr[i] != arr[j])
                        _mCache[arr[i] * arr[j]].Add((arr[j], arr[i]));
                        
                }
            }

            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += CountOfTrees(arr[i]);
            }
            
            return result;
        }

        public int CountOfTrees(int number)
        {
            if (!_mCache.ContainsKey(number))
            {
                return 1;
            }

            if (_countCache.ContainsKey(number))
                return _countCache[number];
            
            var sum = 1;
            foreach (var pair in _mCache[number])
            {
                sum += 1;
                var sumItem1 = CountOfTrees(pair.Item1) - 1;
                sum += sumItem1;
                var sumItem2 = CountOfTrees(pair.Item2) - 1;
                sum += sumItem2;
            }

            _countCache[number] = sum;
            return sum;
        }
    }
} 