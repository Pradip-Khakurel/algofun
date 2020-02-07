using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoFun.Greedy
{
    public class BigClustering
    {
        private List<int> _positions;

        public BigClustering(int bitSize)
        {
            _positions = Enumerable.Range(0, bitSize).ToList();
        }

        public int Compute(IEnumerable<int> values, int k)
        {
            var uf = new UnionFind(values.Count());
            var map = GetMap(values);

            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j < values.Count(); j++)
                {
                    var val = values.ElementAt(j);
                    var combs = GetBitShiftCombinationsOfNPositions(val, i, _positions);

                    foreach (var cn in combs)
                    {
                        if (map.ContainsKey(cn))
                        {
                            foreach (var key in map[cn])
                            {
                                uf.Union(j, key);
                            }
                        }
                    }
                }
            }

            return uf.Count;
        }

        private IDictionary<int, IList<int>> GetMap(IEnumerable<int> values)
        {
            var map = new Dictionary<int, IList<int>>();
            var id = 0;

            foreach (var val in values)
            {
                if (!map.ContainsKey(val)) map.Add(val, new List<int>());

                map[val].Add(id++);
            }


            return map;
        }

        public IEnumerable<int> GetBitShiftCombinationsOfNPositions(int value, int n, List<int> positions)
        {
            var result = new List<int>();

            GetBitShiftCombinationsOfNPositions(value, n, 0, positions, result);

            return result;
        }

        private void GetBitShiftCombinationsOfNPositions(int val, int n, int start, List<int> positions, List<int> result)
        {
            if (n == 0)
            {
                result.Add(val);
                return;
            }

            for (int i = start; i <= positions.Count - n; i++)
            {
                var next = ShiftBitI(val, positions[i]);

                GetBitShiftCombinationsOfNPositions(next, n - 1, start + 1, positions, result);
            }
        }

        public int ShiftBitI(int val, int i)
        {
            return val ^ (1 << i);
        }
    }
}