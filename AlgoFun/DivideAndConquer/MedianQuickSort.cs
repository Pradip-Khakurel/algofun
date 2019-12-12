using System;

namespace AlgoFun
{
    public class MedianQuickSort : QuickSortBase
    {
        public override void ChoosePivotAndSwapItAtBeginning(int[] arr, int lo, int hi) 
        {
            int mid = lo + (hi-lo)/2;
            int first = arr[lo], second = arr[mid], third = arr[hi];

            int min = Math.Min(first, Math.Min(second, third));
            int max = Math.Max(first, Math.Max(second, third));

            if(min < second && second < max) {
                Swap(arr, lo, mid);
            }
            else if(min < third && third < max) {
                Swap(arr, lo, hi);
            }            
        }
    }
}