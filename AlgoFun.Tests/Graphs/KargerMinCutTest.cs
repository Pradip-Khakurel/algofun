using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System;

namespace AlgoFun.Tests.Graphs
{
    [TestFixture]
    public class KargerMinCutTest
    {
        [Test]
        public void TryGetMinGraph1Test()
        {
            var nodes = new Dictionary<int, List<int>>();

            nodes.Add(1, new List<int>() { 2, 3 });
            nodes.Add(2, new List<int>() { 1, 3 });
            nodes.Add(3, new List<int>() { 1, 2 });

            int actual = new KargerMinCut(nodes).TryGetMin(1);

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void TryGetMinGraph2Test()
        {
            var nodes = new Dictionary<int, List<int>>();

            nodes.Add(1, new List<int>() { 2, 3 });
            nodes.Add(2, new List<int>() { 1, 3, 4 });
            nodes.Add(3, new List<int>() { 1, 2, 4 });
            nodes.Add(4, new List<int>() { 2, 3 });

            int actual = new KargerMinCut(nodes).TryGetMin(10);

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void TryGetMinGraph3Test()
        {
            var nodes = new Dictionary<int, List<int>>();

            nodes.Add(1, new List<int>() { 2, 4 });
            nodes.Add(2, new List<int>() { 3, 1 });
            nodes.Add(3, new List<int>() { 4, 2 });
            nodes.Add(4, new List<int>() { 1, 3 });
            
            int actual = new KargerMinCut(nodes).TryGetMin(100);

            Assert.That(actual, Is.EqualTo(2));
        }        

        [Test]
        public void TryGetMinGraph5Test()
        {
            var array = File.ReadAllLines("kargerMinCut.txt")
                            .Select(s => Parse(s.Split("	"))).ToArray()
                            .ToList();

            var nodes = new Dictionary<int, List<int>>();

            foreach (var lst in array)
            {
                nodes.Add(lst.First(), lst.Skip(1).ToList());
            }

            int actual = new KargerMinCut(nodes).TryGetMin(100);

            Assert.That(actual, Is.EqualTo(17));
        }

        private int[] Parse(string[] arr)
        {
            return arr.Take(arr.Length-1).Select(s => int.Parse(s)).ToArray();
        }
    }
}
