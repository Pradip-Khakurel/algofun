using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System;
using AlgoFun.Graphs;

namespace AlgoFun.Tests.Graphs
{
    [TestFixture]
    public class DijsktraShortestPathTest
    {
        [Test]
        public void TestGraphOne()
        {
            var graph = new Dictionary<int, List<WeightedEdge>>();

            graph.Add(0, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 1, Weight = 2 },
                new WeightedEdge() { Destination = 2, Weight = 4 }
            });
            graph.Add(1, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 2, Weight = 1 },
                new WeightedEdge() { Destination = 3, Weight = 3 }
            });

            graph.Add(2, new List<WeightedEdge>()
            {
                new WeightedEdge() { Destination = 3, Weight = 1 }
            });

            var path = new DijkstraShortestPath(graph, 4, 0).Compute();

            Assert.That(path[0], Is.EqualTo(0));
            Assert.That(path[1], Is.EqualTo(2));
            Assert.That(path[2], Is.EqualTo(3));
            Assert.That(path[3], Is.EqualTo(4));
        }

        [Test]
        // 3024,2610,3016,9946,2367,2399,2029,2442,2610,3068
        // 2599,2610,2947,2052,2367,2399,2029,2442,2505,3068
        public void TestGraphFileOne()
        {
            var path = TesFile("dijkstraData.txt", 200, 0);
            var vertices = new[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            var ans = string.Join(",", vertices.Select(v => path[v - 1].ToString()));
        }

        [Test]
        public void TestGraphFilTwo()
        {
            var path = TesFile("djikstrashort.txt", 11, 0);
            var ans = string.Join(",", path.Select(v => v.ToString()));
        }

        [Test]
        public void TestGraphFileThree()
        {
            var path = TesFile("dijkstrashort2.txt", 8, 0);
            var ans = string.Join(",", path.Select(v => v.ToString()));
        }

        private int[] TesFile(string filename, int n, int src)
        {
            var graph = new Dictionary<int, List<WeightedEdge>>();
            var array = File.ReadAllLines(filename);

            foreach (var item in array)
            {
                var line = item.Split("	");
                var id = int.Parse(line[0]);
                graph.Add(id - 1, new List<WeightedEdge>());

                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i] == "") continue;

                    var tuple = line[i].Split(",");
                    var dest = int.Parse(tuple[0]);
                    var wgt = int.Parse(tuple[1]);

                    if (dest == id) continue;

                    graph[id - 1].Add(new WeightedEdge() { Destination = dest - 1, Weight = wgt });
                }
            }

            return new DijkstraShortestPath(graph, n, src).Compute();
        }
    }
}