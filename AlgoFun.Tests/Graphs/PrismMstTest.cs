using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Graphs;
using System.IO;
using System.Threading;
using AlgoFun.Greedy;

namespace AlgoFun.Tests.Graphs
{
    [TestFixture]
    public class PrismMstTest
    {
        [Test]
        public void TestOne()
        {
            var graph = new Dictionary<int, List<WeightedEdge>>();

            graph.Add(0, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 1, Weight = 3 },
                new WeightedEdge() { Destination = 3, Weight = 1 }
            });

            graph.Add(1, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 0, Weight = 3 },
                new WeightedEdge() { Destination = 2, Weight = 2 }
            });

            graph.Add(2, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 1, Weight = 2 },
                new WeightedEdge() { Destination = 3, Weight = 4 }
            });

            graph.Add(3, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 0, Weight = 1 },
                new WeightedEdge() { Destination = 2, Weight = 4 }
            });

            int count = new PrismMst(graph, 4, 0).Compute();

            Assert.That(count, Is.EqualTo(6));
        }

        [Test]
        public void TestFile()
        {
            var graph = new Dictionary<int, List<WeightedEdge>>();
            var array = File.ReadAllLines("prism.txt").Skip(1);

            foreach (var item in array)
            {
                var tuple = item.Split(" ");
                var from = int.Parse(tuple[0]) - 1;
                var to = int.Parse(tuple[1]) - 1;
                var wgt = int.Parse(tuple[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<WeightedEdge>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<WeightedEdge>());
                }

                graph[to].Add(new WeightedEdge() { Destination = from, Weight = wgt });
                graph[from].Add(new WeightedEdge() { Destination = to, Weight = wgt });
            }

            var count = new PrismMst(graph, 500, 0).Compute();
        }
    }
}