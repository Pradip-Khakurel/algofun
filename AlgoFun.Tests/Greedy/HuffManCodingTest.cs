using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Greedy;
using System.IO;
using static HuffManCoding;

namespace AlgoFun.Tests.Greedy
{
    [TestFixture]
    public class HuffmanCodingTest
    {
        private readonly HuffManCoding _hmc = new HuffManCoding();

        [Test]
        public void ToHeapTest()
        {
            var values = new long[] { 15, 10, 18, 2 };
            var heap =  _hmc.ToHeap(values);

            Assert.That(heap.Top.Value, Is.EqualTo(2));
        }

        [Test]
        public void MinMax() 
        {
            var a = new Node();
            var b  = new Node();
            a.Left = b;

            var mm = _hmc.MinMax(a);            
            Assert.That(mm.min, Is.EqualTo(0));
            Assert.That(mm.max, Is.EqualTo(1));
        }

        [Test]
        public void TestCompute()
        {
            var values = new long[] { 3,2,6,8,2,6 };
            var mm = _hmc.Compute(values);

            Assert.That(mm.min, Is.EqualTo(2));
            Assert.That(mm.max, Is.EqualTo(4));
        }

        [Test]
        public void TestFile() 
        {
            var lines = File.ReadAllLines("huffman.txt");            
            var values = new List<long>(int.Parse(lines[0]));
            
            foreach (var ln in lines.Skip(1))
            {
                values.Add(int.Parse(ln));
            }

            var mm = _hmc.Compute(values);
            Assert.That(mm.min, Is.EqualTo(9));
            Assert.That(mm.max, Is.EqualTo(19));
        }         
    
    }
}