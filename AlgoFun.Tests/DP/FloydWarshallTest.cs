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
    public class FloyWarshallTest
    {
        [Test]
        public void TestFiles() 
        {
            var files = new [] { "g1.txt", "g2.txt" , "g3.txt" };
            var res = new List<long?>();

            foreach (var fl in files)
            {
                var g = GetGraphFrom(fl);
                var n = g.GetLength(0);
                var fw = new FloydWarshall(g, n);
                
                fw.ComputeAllPairsShortestPath();

                res.Add(fw.GetShortestDistance());
            }
        }

        private int?[,] GetGraphFrom(string fileName) 
        {
            var arrs = File.ReadAllLines(fileName)
                           .Select(l => l.Split(" ").Select(int.Parse).ToArray())
                           .ToArray();

            var n = arrs[0][0];
            var graph = new int?[n,n];

            foreach (var x in arrs.Skip(1))
            {
                graph[x[0]-1, x[1]-1] = x[2];
            }
            
            return graph;
        }
    }
}