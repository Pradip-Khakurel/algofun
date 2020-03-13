using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;
using AlgoFun.DP;
using AlgoFun.Heaps;
using AlgoFun.Heuristics;
using NUnit.Framework;
using System.IO;
using static AlgoFun.Heuristics.TravelingSalesmanHeuristics;

namespace AlgoFun.Tests.Heuristics 
{
    [TestFixture]
    public class TravelingSalesmanHeuristicsTest
    {
        [Test]
        public void TestCompute()
        {
            var cities = File.ReadAllLines("tsph.txt")
                            .Select(l => l.Split(" "))
                            .Select(s => new City() 
                            {
                                x = double.Parse(s[1]),
                                y = double.Parse(s[2])
                            }).ToArray();
            
            var res = new TravelingSalesmanHeuristics().Compute(cities);
            Assert.That((int)res, Is.EqualTo(1203406));
        }
    }
}