using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.DP
{
    public class FloydWarshall
    {
        private readonly int?[,] _graph;
        private readonly int _n;
        private long[,] _dp;


        public FloydWarshall(int?[,] graph, int n)
        {
            _n = n;
            _graph = graph;
            _dp = new long[n, n];
        }

        public void ComputeAllPairsShortestPath()
        {
            Init();

            for (int k = 0; k < _n; k++)
            {
                var next = new long[_n, _n];

                for (int i = 0; i < _n; i++)
                {
                    for (int j = 0; j < _n; j++)
                    {
                        if (_dp[i, k] == long.MaxValue || _dp[k, j] == long.MaxValue)
                        {
                            next[i, j] = _dp[i, j];
                        }
                        else
                        {
                            next[i, j] = Math.Min(_dp[i, j], _dp[i, k] + _dp[k, j]);
                        }
                    }
                }

                _dp = next;
            }
        }

        private void Init()
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (_graph[i, j].HasValue)
                    {
                        _dp[i, j] = _graph[i, j].Value;
                    }
                    else if (i == j)
                    {
                        _dp[i, j] = 0;
                    }
                    else
                    {
                        _dp[i, j] = long.MaxValue;
                    }
                }
            }
        }

        public long? GetShortestDistance()
        {
            if (HasNegativeCycle()) return null;

            long shortest = long.MaxValue;

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (shortest > _dp[i, j])
                    {
                        shortest = _dp[i, j];
                    }
                }
            }

            return shortest;
        }

        private bool HasNegativeCycle()
        {
            for (int i = 0; i < _n; i++)
            {
                if (_dp[i, i] < 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}