using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class CollectionExtensions
    {
        public static void InsertIntoSortedList<T>(this IList<T> list, T value, int start = 0, int end = -1) where T:IComparable
        {
            if (end == -1)
                end = list.Count - 1;
            
            if (list.Count == 0)
            {
                list.Add(value);
                return;
            }
            
            var i = (start + end) / 2;
            if (list[i].CompareTo(value) == 0)
            {
                list.Insert(i, value);
            }
            else if (list[i].CompareTo(value) > 0)
            {
                if (i == start)
                {
                    list.Insert(i, value);
                }
                else
                {
                    InsertIntoSortedList(list, value, start, i);    
                }
            }
            else
            {
                if (i == end)
                {
                    list.Insert(i + 1, value);
                }
                else
                {
                    InsertIntoSortedList(list, value, i + 1, end);    
                }
            }
        }
    }
}