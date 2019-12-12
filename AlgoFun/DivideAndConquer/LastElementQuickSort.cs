using System;

namespace AlgoFun
{
    public class LastElemenQuickSort : QuickSortBase
    {
        public override void ChoosePivotAndSwapItAtBeginning(int[] arr, int lo, int hi) 
        {
            Swap(arr, lo, hi);
       }
    }
}