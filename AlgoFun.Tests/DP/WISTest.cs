using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using AlgoFun.DP;


namespace AlgoFun.Tests.DP
{
    [TestFixture]
    public class WISTest
    {
        [Test]
        public void TestFile() 
        {
            var lines = File.ReadAllLines("mwis.txt");            
            var values = new List<long>(int.Parse(lines[0]));
            
            foreach (var ln in lines.Skip(1))
            {
                values.Add(long.Parse(ln));
            }

            var res = new HashSet<long>(new WIS().Compute(values.ToArray()));
            var vertices = new long[] { 1, 2, 3, 4, 17, 117, 517, 997 };
            var arr = vertices.Select(v => res.Contains(v-1) ? '1' : '0' );
            var print = new string(arr.ToArray());
            Assert.That(print, Is.EqualTo("10100110"));
        }
    }
}