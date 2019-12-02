using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AlgoFun.Tests
{
    [TestFixture]
    public class InversionCounterTest
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void TestCountFromMemory(int[] arr, int expectedCount) 
        {
            var count = new InversionCounter().Count(arr);
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TestCountFromFile() {
            var array = File.ReadAllLines("CountIntegerArray.txt")
                            .Select(s => int.Parse(s))
                            .ToArray();

            var test = new InversionCounter().Count(array);
        }

        public static IEnumerable<TestCaseData> GetTestCases()
        {
            return new [] 
            {
               new TestCaseData(new[] { 1, 2, 3 }, 0),
               new TestCaseData(new[] { 7, 5, 4 }, 3),
               new TestCaseData(new[] { 10, 9, 8, 7, 5, 4 }, 15)
            };
        }
    }

}