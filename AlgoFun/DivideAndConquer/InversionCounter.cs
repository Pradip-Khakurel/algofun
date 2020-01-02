using System;

namespace AlgoFun
{
    public class InversionCounter
    {                                                                                                                                                                                                                                           
        public long Count(int[] array)
        {
            if (array == null || array.Length == 0) return 0;

            return MergeSortCount(array, new int[array.Length], 0, array.Length - 1);
        }

        // 1 3 2
        private long MergeSortCount(int[] array, int[] helper, int lo, int hi)
        {
            if (lo >= hi) return 0;

            int mid = lo + (hi - lo) / 2;

            var left = MergeSortCount(array, helper, lo, mid);
            var right = MergeSortCount(array, helper, mid + 1, hi);

            Array.Copy(array, lo, helper, lo, hi-lo+1);
            
            int i = lo, j = mid+1, k = lo;
            long count=0;

            while (i <= mid && j <= hi)
            {
                if (helper[i] <= helper[j])
                {
                    array[k++] = helper[i++];
                }
                else
                {
                    array[k++] = helper[j++];
                    count += mid-i+1;
                }
            }

            while (i <= mid) array[k++] = helper[i++];

            return count+left+right;
        }
    }
}