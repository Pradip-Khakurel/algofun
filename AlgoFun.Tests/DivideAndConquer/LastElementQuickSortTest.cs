using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AlgoFun.Tests.DivideAndConquer
{
    [TestFixture]
    public class LastElementQuickSortTest : QuickSortTestBase
    {
        [TestCaseSource(nameof(QuickSortTestBase.GetTestCases))]
        public void TestSort(int[] arr) 
        {
            TestSort(new LastElemenQuickSort(), arr);
        }        

        [Test]
        public void TestSortFromFile() 
        {
            TestSortFromFile(new LastElemenQuickSort(), 164123);
        } 
    }
}
