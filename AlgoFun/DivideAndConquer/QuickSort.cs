using System;

namespace AlgoFun
{
    public abstract class QuickSortBase 
    {
        public int CountComparisons { get; private set; }

        public void Sort(int[] arr) 
        {
            CountComparisons = 0;

            if(arr == null) return;

            Sort(arr, 0, arr.Length-1);
        }

        private void Sort(int[] arr, int lo, int hi) 
        {
            if(lo >= hi) return;

            int partitionIndex = Partition(arr, lo, hi);
            Sort(arr, lo, partitionIndex-1);
            Sort(arr, partitionIndex+1, hi);
        }

        private int Partition(int[] arr, int lo, int hi) 
        {
            CountComparisons += hi-lo;

            ChoosePivotAndSwapItAtBeginning(arr, lo, hi);
           
            int j = lo, pivot = arr[lo];

            for (int i = lo+1; i <= hi; i++)
            {
                if(arr[i] <= pivot) 
                {
                    Swap(arr, i, j+1);
                    j++;
                }
            }

            Swap(arr, j, lo);

            return j;
        }

        public abstract void ChoosePivotAndSwapItAtBeginning(int[] arr, int lo, int hi);

        protected void Swap(int[] arr, int i, int j) 
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}