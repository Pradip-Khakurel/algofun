using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AlgoFun.Tests.DivideAndConquer
{
    [TestFixture]
    public class MedianQuickSortTest : QuickSortTestBase
    {
        [TestCaseSource(nameof(QuickSortTestBase.GetTestCases))]
        public void TestSort(int[] arr) 
        {
            TestSort(new MedianQuickSort(), arr);
        }        

        [Test]
        public void TestSortFromFile() 
        {
            TestSortFromFile(new MedianQuickSort(), 138382);
        } 
    }
}
