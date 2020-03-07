using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgoFun.DP;
using AlgoFun.Graphs;
using NUnit.Framework;

namespace AlgoFun.Tests.DP
{

    [TestFixture]
    public class TravelingSalesmanTest
    {
        private TravelingSalesman _algo;

        [Test]
        public void ContainsTest()
        {
            _algo = new TravelingSalesman(null, 10);
            var set = Convert.ToInt32("000100", 2);
            Assert.That(_algo.Contains(set, 3), Is.True);
            Assert.That(_algo.Contains(set, 10), Is.False);
            Assert.That(_algo.Contains(set, 1), Is.False);
        }

        [Test]
        public void SetWithoutTest()
        {
            _algo = new TravelingSalesman(null, 10);
            var set = Convert.ToInt32("000111", 2);
            Assert.That(_algo.SetWithout(set, 3), Is.EqualTo(3));
        }

        [Test]
        public void NextSetsTest()
        {
            _algo = new TravelingSalesman(null, 10);
            var next = _algo.NextSets(new List<int>() { 1 });

            Assert.That(next.Count, Is.EqualTo(9));
            Assert.That(next[0], Is.EqualTo(Convert.ToInt32("11", 2)));
            Assert.That(next[8], Is.EqualTo(Convert.ToInt32("1000000001", 2)));

            next = _algo.NextSets(next);
            Assert.That(next.Count, Is.EqualTo(36));
            Assert.That(next.Contains(Convert.ToInt32("0000000111", 2)), Is.True);
            Assert.That(next.Contains(Convert.ToInt32("1000100001", 2)), Is.True);

            next = _algo.NextSets(next);
            Assert.That(next.Contains(Convert.ToInt32("0001000111", 2)), Is.True);
            Assert.That(next.Contains(Convert.ToInt32("1010100001", 2)), Is.True);
            Assert.That(next.Count, Is.EqualTo(84));
        }

        [Test]
        public void GetElementsTest()
        {
            _algo = new TravelingSalesman(null, 10);
            var elements = _algo.GetElements(Convert.ToInt32("1010100001", 2));

            Assert.That(elements.Count, Is.EqualTo(4));
            Assert.That(elements.Contains(1), Is.True);
            Assert.That(elements.Contains(6), Is.True);
            Assert.That(elements.Contains(8), Is.True);
            Assert.That(elements.Contains(10), Is.True);
        }

        [Test]
        public void GetAllElementsSetTest()
        {
            _algo = new TravelingSalesman(null, 10);
            var all = _algo.GetAllElementsSet();

            Assert.That(all, Is.EqualTo(Convert.ToInt32("1111111111", 2)));
        }

        [TestCase("tsp1.txt", 10.24)]
        [TestCase("tsp2.txt", 12.36)]
        //[TestCase("tsp3.txt", 14.00)]
        public void ComputeTest(string fileName, double expected) 
        {
            var lines = File.ReadAllLines(fileName);
            var n = int.Parse(lines[0]);
            var list = new List<(double x, double y)>();
            
            foreach (var ln in lines.Skip(1).Select(l => l.Split(" ")))
            {
                var x = double.Parse(ln[0]);
                var y = double.Parse(ln[1]);
                list.Add((x, y));
            }

            var clique = new double[n+1, n+1];

            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    var a = list[i];
                    var b = list[j];
                    var dist = TravelingSalesman.EuclideanDistance(a.x, a.y, b.x, b.y);;
                    clique[i+1,j+1] = dist;
                    clique[j+1,i+1] = dist;
                }
            }

            _algo = new TravelingSalesman(clique, n);
            var result = _algo.Compute();
            Assert.That(Math.Round(result,2), Is.EqualTo(expected));
        }
    }
}