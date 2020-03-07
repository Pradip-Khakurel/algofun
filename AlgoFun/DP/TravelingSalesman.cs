using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;

namespace AlgoFun.DP
{
    public class TravelingSalesman
    {
        private const double INF = double.MaxValue;
        private readonly int _n;
        private readonly double[,] _clique;

        public TravelingSalesman(double[,] clique, int n)
        {
            _clique = clique;
            _n = n;
        }

        public double Compute()
        {
            var sets = new List<int>() { 1 };
            var dp = InitDpBaseCase(sets);
            Dictionary<(int, int), double> nextDp;

            for (int size = 2; size <= _n; size++)
            {
                sets = NextSets(sets);
                nextDp = InitDpBaseCase(sets);
                foreach (var set in sets)
                {
                    var elements = GetElements(set);
                    foreach (int j in elements)
                    {
                        if (j == 1) continue;

                        var min = INF;
                        var without = SetWithout(set, j);

                        foreach (var k in elements)
                        {
                            if (k == j) continue;

                            if (dp[(without, k)] == INF) continue;
                            double cost = _clique[j, k];
                            min = Math.Min(min, dp[(without, k)] + cost);
                        }

                        nextDp[(set, j)] = min;
                    }
                }
                dp = nextDp;
            }

            var result = INF;
            var all = GetAllElementsSet();

            for (int j = 2; j <= _n; j++)
            {
                result = Math.Min(result, dp[(all, j)] + _clique[j, 1]);
            }

            return result; ;
        }

        public Dictionary<(int, int), double> InitDpBaseCase(List<int> sets)
        {
            var dp = new Dictionary<(int, int), double>();

            foreach (var set in sets)
            {
                if (set == 1)
                {
                    dp.Add((set, 1), 0);
                }
                else
                {
                    dp.Add((set, 1), INF); // avoid visiting vertex 1 again
                }
            }

            return dp;
        }

        public int GetAllElementsSet()
        {
            return ~((-1) << _n);
        }

        public IEnumerable<int> GetElements(int set)
        {
            var list = new List<int>();

            for (int i = 1; i <= _n; i++)
            {
                if (Contains(set, i))
                {
                    list.Add(i);
                }
            }

            return list;
        }

        public List<int> NextSets(List<int> sets)
        {
            var nextSets = new HashSet<int>();
            for (int j = 2; j <= _n; j++)
            {
                foreach (var set in sets)
                {
                    if (Contains(set, j)) continue;
                    nextSets.Add(set | (1 << (j - 1)));
                }
            }
            return nextSets.ToList();
        }

        public bool Contains(int set, int i)
        {
            return (set & (1 << i - 1)) != 0;
        }

        public int SetWithout(int set, int i)
        {
            return set & ~(1 << i - 1);
        }

        public static double EuclideanDistance(double x, double y, double z, double w)
        {
            return Math.Sqrt(Math.Pow((x - z), 2) + Math.Pow((y - w), 2));
        }
    }
}