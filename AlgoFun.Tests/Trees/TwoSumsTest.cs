using System;
using NUnit.Framework;
using AlgoFun;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Trees;
using System.IO;

namespace AlgoFun.Tests.Trees
{
    [TestFixture]
    public class TwoSumsTest
    {
        [Test]
        public void TestOne() 
        {
            var algo = new TwoSums(0, 10);
            var test = algo.Solve(new long[] { 1, 2, 15});

            Assert.That(test, Is.EqualTo(1));
        }

        [Test]
        public void TestFile()
        {
            var array = File.ReadAllLines("2sum.txt")
                            .Select(long.Parse)
                            .ToArray();

            var test = new TwoSums(-10000, 10000).Solve(array);
        }
    }
}