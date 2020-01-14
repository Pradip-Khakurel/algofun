using System;
using System.Collections.Generic;

namespace AlgoFun.Heaps
{
    public class MedianMaintenance
    {
        private PriorityQueue<int, int> _maxHeap;
        private PriorityQueue<int, int> _minHeap;

        public MedianMaintenance()
        {
        }

        public MedianMaintenance(int capacity)
        {
            _maxHeap = new PriorityQueue<int, int>(capacity, Comparer<int>.Create((x, y) => x.CompareTo(y)));
            _minHeap = new PriorityQueue<int, int>(capacity, Comparer<int>.Create((x, y) => y.CompareTo(x)));
        }

        public void Add(int x)
        {
            if (_maxHeap.Count == _minHeap.Count)
            {
                _maxHeap.Push(x, x);
            }
            else
            {
                _minHeap.Push(x, x);
            }

            if(_minHeap.Count == 0) return;

            var left = _maxHeap.Top.Key;
            var right = _minHeap.Top.Key;
            if (left > right)
            {
                _maxHeap.Pop();
                _minHeap.Pop();

                _maxHeap.Push(right, right);
                _minHeap.Push(left, left);
            }
        }

        public int GetMedian()
        {
            return _maxHeap.Top.Key;
        }
    }
}