using System;
using NUnit.Framework;
using AlgoFun;
using System.Collections.Generic;

namespace AlgoFun.Tests.Heap
{
    [TestFixture]
    public class TwoSumsTest
    {
        [Test]
        public void TestHeapOne()
        {
            var heap = new PriorityQueue<int, int>(10, Comparer<int>.Create((x, y) => x.CompareTo(y)));

            for (int i = 0; i < 10; i++)
            {
                heap.Push(1, 10);
                heap.Push(2, 20);
                heap.Push(3, 5);

                Assert.That(heap.Top.Key, Is.EqualTo(2));
                Assert.That(heap.Top.Value, Is.EqualTo(20));

                heap.Pop();

                Assert.That(heap.Top.Key, Is.EqualTo(1));
                Assert.That(heap.Top.Value, Is.EqualTo(10));

                heap.Pop();

                Assert.That(heap.Top.Key, Is.EqualTo(3));
                Assert.That(heap.Top.Value, Is.EqualTo(5));

                heap.Pop();
            }
        }

        [Test]
        public void TestHeapTwo()
        {
            var heap = new PriorityQueue<int, int>(10, Comparer<int>.Create((x, y) => x.CompareTo(y)));

            for (int i = 0; i < 10; i++)
            {
                heap.Push(1, 10);
                heap.Push(2, 20);
                heap.Push(3, 5);

                Assert.That(heap.Top.Key, Is.EqualTo(2));
                Assert.That(heap.Top.Value, Is.EqualTo(20));

                heap.Pop();
                heap.Delete(3);
                heap.Push(3, 30);

                Assert.That(heap.Top.Key, Is.EqualTo(3));
                Assert.That(heap.Top.Value, Is.EqualTo(30));

                heap.Pop();
                heap.Pop();
            }
        }

        [Test]
        public void TestHeapThree() 
        {
            var heap = new PriorityQueue<int, int>(11, Comparer<int>.Create((x, y) => y.CompareTo(x)));

            for (int i = 0; i < 11; i++)
            {
                heap.Push(i, 1000000);
            }

            heap.Delete(2);
            heap.Push(2, 4);
            heap.Delete(6);
            heap.Push(6, 5);
            heap.Delete(4);
            heap.Push(4, 7);

            Assert.That(heap.Top.Value, Is.EqualTo(4));
            Assert.That(heap.Top.Key, Is.EqualTo(2));
        }
    }
}
