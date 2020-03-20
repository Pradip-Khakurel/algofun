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
    public class TwoSatTest 
    {
        [Test]
        public void TestIsSatisfy()
        {
            var result = string.Join("", Enumerable.Range(1, 6).Select(i => TestIsSatisfy($"2sat{i}.txt") ? "1": "0"));
                                   
        }

        public bool TestIsSatisfy(string filename)
        {
            var clauses = File.ReadAllLines(filename)
                            .Skip(1)
                            .Select(l => l.Split(" "))
                            .Select(l => new Tuple<int, int>(int.Parse(l[0]), int.Parse(l[1])))
                            .ToArray();
            
            return new TwoSat().IsSatisfy(clauses);
        }
    }
}