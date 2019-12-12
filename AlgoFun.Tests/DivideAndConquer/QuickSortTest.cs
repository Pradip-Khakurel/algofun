using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AlgoFun.Tests.DivideAndConquer
{
    public abstract class QuickSortTestBase 
    {
        protected void TestSort(QuickSortBase quicksort, int[] arr) 
        {
            quicksort.Sort(arr);

            Assert.That(IsSorted(arr), Is.True);
        }        

        protected void TestSortFromFile(QuickSortBase quicksort, int comparisons) 
        {
            var arr = File.ReadAllLines("QuickSort.txt")
                            .Select(s => int.Parse(s))
                            .ToArray();
            
            quicksort.Sort(arr);
            Assert.That(quicksort.CountComparisons, Is.EqualTo(comparisons));
            Assert.That(IsSorted(arr), Is.True);
        }

        private bool IsSorted(int[] arr) 
        {
            for(int i=0;i<arr.Length-1;i++){
                if(arr[i] > arr[i+1]) return false; 
            }
            return true;
        }

        public static IEnumerable<TestCaseData> GetTestCases()
        {
            return new [] 
            {
               new TestCaseData(new[] { 1, 2, 3 }),
               new TestCaseData(new[] { 7, 5, 4 }),
               new TestCaseData(new[] { 10, 9, 8, 7, 5, 4 })
            };
        }  
    }
}