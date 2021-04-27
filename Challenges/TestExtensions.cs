using System;
using System.Collections.Generic;

namespace ChallengesTests
{
    public static class TestsExtensions
    {
        public static IList<IList<int>> ToLists(this string s)
        {
            var data = s.Substring(1, s.Length - 2);
            if (string.IsNullOrEmpty(data))
                return new List<IList<int>>();
            data = data
                .Replace("],[", "|")
                .Replace("[",string.Empty)
                .Replace("]", String.Empty);
            var rows = data.Split('|');

            var result = new List<IList<int>>();

            for (var index = 0; index < rows.Length; index++)
            {
                var row = rows[index];
                var numbers = row.Split(',');
                var newList = new List<int>();
                result.Add(newList);

                for (int i = 0; i < numbers.Length; i++)
                {
                    newList.Add(Convert.ToInt32(numbers[i]));
                }
            }

            return result;
        }
        
        public static int[][] ToMatrix(this string s)
        {
            var data = s.Substring(1, s.Length - 2);
            if (string.IsNullOrEmpty(data))
                return new int[0][];
            data = data
                .Replace("],[", "|")
                .Replace("[",string.Empty)
                .Replace("]", String.Empty);
            var rows = data.Split('|');

            var result = new int[rows.Length][];

            for (var index = 0; index < rows.Length; index++)
            {
                var row = rows[index];
                var numbers = row.Split(',');
                result[index] = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    result[index][i] = Convert.ToInt32(numbers[i]);
                }
            }

            return result;
        }
        
        public static string[][] ToStringMatrix(this string s)
        {
            var data = s.Substring(1, s.Length - 2);
            if (string.IsNullOrEmpty(data))
                return new string[0][];
            data = data
                .Replace("],[", "|")
                .Replace("[",string.Empty)
                .Replace("]", String.Empty);
            var rows = data.Split('|');

            var result = new string[rows.Length][];

            for (var index = 0; index < rows.Length; index++)
            {
                var row = rows[index];
                var numbers = row.Split(',');
                result[index] = new string[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    result[index][i] = numbers[i];
                }
            }

            return result;
        }
    }
}