using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using AlgoFun.DP;
using static AlgoFun.DP.Knapsack;

namespace AlgoFun.Tests.DP
{
    [TestFixture]
    public class OptimalBinarySearchTreeTest 
    {
        [Test]
        public void TestCompute() 
        {
            var values = new double []
            {
                0.05, 0.4, 0.08, 0.04, 0.1, 0.1, 0.23
            };

            var obs = new OptimalBinarySearchTree();            
            var res = obs.Compute(values);

            Assert.That(Math.Round(res, 2), Is.EqualTo(2.18d));
        }
    }
}