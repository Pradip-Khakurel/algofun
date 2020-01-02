using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Graphs;
using System.IO;
using System.Threading;

namespace AlgoFun.Tests.Graphs
{
    [TestFixture]
    public class KosarajuAlgorithmTest
    {
        [Test]
        public void GraphOneTest()
        {
            var graph = new Dictionary<int, List<int>>();

            graph.Add(0, new List<int>() { 1, 2 });
            graph.Add(1, new List<int>() { 3 });
            graph.Add(2, new List<int>() { 3 });

            var algo = new KosarajuAlgorihtm(graph, 4);
            var list = algo.ComputeSccs();

            Assert.That(list.Count, Is.EqualTo(4));
        }

        [Test]
        public void GraphTwoTest()
        {
            var graph = new Dictionary<int, List<int>>();

            graph.Add(0, new List<int>() { 1 });
            graph.Add(1, new List<int>() { 2, 3 });
            graph.Add(2, new List<int>() { 0 });

            graph.Add(3, new List<int>() { 4 });
            graph.Add(4, new List<int>() { 5, 6 });
            graph.Add(5, new List<int>() { 3 });

            graph.Add(6, new List<int>() { 7 });
            graph.Add(7, new List<int>() { 8 });
            graph.Add(8, new List<int>() { 6 });

            var algo = new KosarajuAlgorihtm(graph, 9);
            var list = algo.ComputeSccs();

            Assert.That(list.Count, Is.EqualTo(3));
        }

        [Test]
        public void GraphFileTest()
        {
            var array = File.ReadAllLines("scc.txt");
            var graph = new Dictionary<int, List<int>>();

            foreach (var line in array)
            {
                var tuple = line.Split(" ");
                var from = int.Parse(tuple[0])-1;
                var to = int.Parse(tuple[1])-1;

                if(from == to) continue;

                if(!graph.ContainsKey(from)) {
                    graph.Add(from, new List<int>());
                }

                graph[from].Add(to);
            }

            var algo = new KosarajuAlgorihtm(graph, 875714);
            List<int> list = algo.ComputeSccs();
        }

    }
}
