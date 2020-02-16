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

    public class KnapsackTest
    {
        [Test]
        public void TestSmall()
        {
            var ks = new Knapsack();

            var items = new[]
            {
                new Item() { Value = 3, Weight = 4 },
                new Item() { Value = 2, Weight = 3 },
                new Item() { Value = 4, Weight = 2 },
                new Item() { Value = 4, Weight = 2 },
            };

            var res = ks.Compute(items, 6);

            Assert.That(res, Is.EqualTo(8));
        }

        [Test]
        public void TestFileSmall()
        {
            TestFile("knapsack1.txt", 2493893);           
        }


        [Test]
        public void TestFileBig()
        {
            TestFile("knapsack2.txt", 4243395);           
        }

        private void TestFile(string fileName, int expected)
        {
            var lines = File.ReadAllLines(fileName);
            var first = lines[0].Split(" ");
            var size = int.Parse(first[0]);
            var n = int.Parse(first[1]);

            var items = new List<Item>(n);

            for (int i = 1; i < lines.Length; i++)
            {
                var tmp = lines[i].Split(" ");
                items.Add(new Item()
                {
                    Value = int.Parse(tmp[0]),
                    Weight = int.Parse(tmp[1])
                });
            }

            var res = new Knapsack().Compute(items.ToArray(), size);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}