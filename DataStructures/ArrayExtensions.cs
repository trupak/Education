namespace DataStructures
{
    public static class ArrayExtensions
    {
        public static void MergeSort(this int[] array)
        {
            if (array.Length == 0 || array.Length == 1)
                return;

            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)
                return;

            if (start + 1 == end)
            {
                if (array[start] > array[end])
                {
                    var tmp = array[start];
                    array[start] = array[end];
                    array[end] = tmp;
                }
                
                return;
            }

            int mid = (end + start) / 2;
            MergeSort(array, start, mid -1);
            MergeSort(array, mid, end);

            var index1 = start;
            var index2 = mid;
            var cache = new int[end - start + 1];
            var index = 0;
            for (int i = start; i <= end; i++,index++)
            {
                if (index2 > end)
                {
                    cache[index] = array[index1];
                    index1++;
                }
                else if (index1 == mid)
                {
                    cache[index] = array[index2];
                    index2++;
                }
                else if (array[index1] < array[index2])
                {
                    cache[index] = array[index1];
                    index1++;
                }
                else
                {
                    cache[index] = array[index2];
                    index2++;
                }
            }

            index = 0;
            for (int i = start; i <= end; i++,index++)
            {
                array[i] = cache[index];
            }
        }
    }
}