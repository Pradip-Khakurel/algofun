using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.Trees
{
    public class TwoSums
    {
        private readonly SortedSet<long> _set;
        private readonly HashSet<long> _values;
        private readonly long _lowerValue;
        private readonly long _upperValue;

        public TwoSums(long min, long max)
        {
            _set = new SortedSet<long>();
            _values = new HashSet<long>();
            _lowerValue = min;
            _upperValue = max;
        }

        public int Solve(long[] arr)
        {
            foreach (var item in arr)
            {
                Add(item);
            }

            return _values.Count();
        }

        private void Add(long x)
        {
            var low = _lowerValue - x;
            var up = _upperValue - x;

            if (low > up) return;

            var range = _set.GetViewBetween(low, up);

            foreach (var y in range)
            {
                _values.Add(y+x);
            }


            _set.Add(x);
        }
    }
}
