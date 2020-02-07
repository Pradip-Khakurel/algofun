using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Greedy;
using System.IO;
using System;

namespace AlgoFun.Tests.Greedy
{
    [TestFixture]
    public class BigClusteringTest
    {
        private BigClustering _bigClustering = new BigClustering(24);

        [Test]
        public void TestShift() 
        {
           var x = _bigClustering.ShiftBitI(556015, 5); // 556015 = 10000111101111101111      
           Assert.That(Convert.ToString(x, 2), Is.EqualTo("10000111101111001111"));

            var y = _bigClustering.ShiftBitI(556015, 4);     
           Assert.That(Convert.ToString(y, 2), Is.EqualTo("10000111101111111111"));                      
        }

        [Test]
        public void TestGetBitShiftCombinationsOfOnePosition()
        {
            var values = _bigClustering.GetBitShiftCombinationsOfNPositions(1, 1, new List<int>(){ 0, 1 });
        
            Assert.That(values.ElementAt(0), Is.EqualTo(0));
            Assert.That(values.ElementAt(1), Is.EqualTo(3));
        }

        [Test]
        public void TestGetBitShiftCombinationsOfTwoPositions()
        {
            var values = _bigClustering.GetBitShiftCombinationsOfNPositions(1, 2, new List<int>(){ 0, 1 });
        
            Assert.That(values.ElementAt(0), Is.EqualTo(2));
        }

        [Test]
        public void TestSimilar() 
        {
            _bigClustering = new BigClustering(4);

            var strs = new string[] { "0000", "0011", "1101", "0000", "0010", "1101" };
            var values = strs.Select(s => Convert.ToInt32(s, 2)).ToArray();

            var count = _bigClustering.Compute(values, 0);

            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void TestOneAway() 
        {
            _bigClustering = new BigClustering(4);

            var strs = new string[] { "1001", "0001", "0000", "0000" };
            var values = strs.Select(s => Convert.ToInt32(s, 2)).ToArray();

            var count = _bigClustering.Compute(values, 1);

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void TestFile() 
        {
            var lines = File.ReadAllLines("BigClustering.txt");
            var n = int.Parse(lines[0].Split(" ")[0]);
            var values = new List<int>(n);

            foreach (var ln in lines.Skip(1))
            {
                values.Add(Convert.ToInt32(ln.Replace(" ", ""), 2));
            }

            var count = _bigClustering.Compute(values, 2);
            Assert.That(count, Is.EqualTo(6118));
        }
    }
}