using System;
using System.Collections.Generic;

namespace AlgoFun
{
    public class PriorityQueue<TKey, TValue>
    {
        public class Element
        {
            public TKey Key { get; }
            public TValue Value { get; }
            public Element(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        #region constructors

        public PriorityQueue(int capacity, IComparer<TValue> comparer)
        {
            _keyAt = new TKey[capacity > 0 ? capacity : DefaultCapacity];
            _valueAt = new TValue[capacity > 0 ? capacity : DefaultCapacity];
            _keyIndexOf = new Dictionary<TKey, int>();
            _count = 0;
            _comparer = comparer;
        }

        #endregion

        #region public members

        public int Count
        {
            get { return _count; }
        }

        public Element Top
        {
            get
            {
                return new Element(_keyAt[0], _valueAt[0]);
            }
        }

        public void Push(TKey key, TValue value)
        {
            if (_count == _valueAt.Length)
            {
                Array.Resize(ref _valueAt, _valueAt.Length * 2);
                Array.Resize(ref _keyAt, _keyAt.Length * 2);
            }

            _keyIndexOf.Add(key, _count);
            _valueAt[_count] = value;
            _keyAt[_count] = key;

            HeapifyUp(_count);

            _count++;
        }

        public void Pop()
        {
            _count--;

            Swap(0, _count);
            HeapifyDown(0);

            _keyIndexOf.Remove(_keyAt[_count]);
            _keyAt[_count] = default(TKey);
            _valueAt[_count] = default(TValue);
        }

        public void Delete(TKey key)
        {
            if (!Contains(key))
            {
                return;
            }
            
            _count--;

            var index = _keyIndexOf[key];        

            Swap(index, _count);
            HeapifyDown(index);
            HeapifyUp(index);

            _keyIndexOf.Remove(key);
            _keyAt[_count] = default(TKey);
            _valueAt[_count] = default(TValue);
        }

        public bool Contains(TKey key)
        {
            return _keyIndexOf.ContainsKey(key);
        }

        public TValue GetValue(TKey key)
        {
            return _valueAt[_keyIndexOf[key]];
        }

        #endregion

        #region private members

        private void HeapifyDown(int index)
        {
            var left = HeapLeftChild(index);

            while (left < _count)
            {
                var right = HeapRightFromLeft(left);

                var best = (right >= _count || _comparer.Compare(_valueAt[left], _valueAt[right]) >= 0) ? left : right;

                if (_comparer.Compare(_valueAt[index], _valueAt[best]) >= 0)
                {
                    break;
                }

                Swap(index, best);

                index = best;
                left = HeapLeftChild(best);
            }
        }

        private void HeapifyUp(int index)
        {
            int parent = HeapParent(index);

            while (index > 0 && _comparer.Compare(_valueAt[index], _valueAt[parent]) > 0)
            {
                Swap(index, parent);

                index = parent;
                parent = HeapParent(index);
            }
        }

        private void Swap(int idx1, int idx2)
        {
            var tmpValue = _valueAt[idx1];
            var tmpKey = _keyAt[idx1];

            _valueAt[idx1] = _valueAt[idx2];
            _keyAt[idx1] = _keyAt[idx2];
            _keyIndexOf[_keyAt[idx1]] = idx1;

            _valueAt[idx2] = tmpValue;
            _keyAt[idx2] = tmpKey;
            _keyIndexOf[_keyAt[idx2]] = idx2;
        }

        /// <summary>
        /// Calculate the parent node index given a child node's index, taking advantage
        /// of the "shape" property.
        /// </summary>
        private static int HeapParent(int i)
        {
            return (i - 1) / 2;
        }

        /// <summary>
        /// Calculate the left child's index given the parent's index, taking advantage of
        /// the "shape" property. If there is no left child, the return value is >= _count.
        /// </summary>
        private static int HeapLeftChild(int i)
        {
            return (i * 2) + 1;
        }

        /// <summary>
        /// Calculate the right child's index from the left child's index, taking advantage
        /// of the "shape" property (i.e., sibling nodes are always adjacent). If there is
        /// no right child, the return value >= _count.
        /// </summary>
        private static int HeapRightFromLeft(int i)
        {
            return i + 1;
        }

        private TValue[] _valueAt;
        private TKey[] _keyAt;
        private Dictionary<TKey, int> _keyIndexOf;
        private int _count;
        private IComparer<TValue> _comparer;
        private const int DefaultCapacity = 6;

        #endregion
    }
}