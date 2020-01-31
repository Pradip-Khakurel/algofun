using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;

namespace AlgoFun.Greedy
{
    public class PrismMst
    {
        private static IEnumerable<WeightedEdge> EMPTY = new List<WeightedEdge>(0);
        private const int INF = 1000000;

        private int _n;
        private IDictionary<int, List<WeightedEdge>> _graph;
        private PriorityQueue<int, int> _heap;
        private int _src;
        private ISet<int> _visited;

        public PrismMst(IDictionary<int, List<WeightedEdge>> graph, int n, int src)
        {
            _n = n;
            _src = src;
            _graph = graph;
            _visited = new HashSet<int>();
            _heap = new PriorityQueue<int, int>(_n, Comparer<int>.Create((x, y) => y.CompareTo(x)));

            InitializeHeap();
        }

        public int Compute()
        {
            int length = 0;

            while (_heap.Count > 0)
            {
                var top = _heap.Top;
                var node = top.Key;

                _heap.Pop();
                _visited.Add(node);
                length += top.Value;

                Update(GetNeighbors(node));
            }

            return length;
        }

        private void InitializeHeap()
        {
            _visited.Add(_src);

            for (int i = 0; i < _n; i++)
            {
                if (i == _src) continue;
                _heap.Push(i, INF);
            }

            Update(GetNeighbors(_src));
        }

        private void Update(IEnumerable<WeightedEdge> neighbors)
        {
            foreach (var nei in neighbors)
            {
                if (!_visited.Contains(nei.Destination))
                {
                    var min = Math.Min(_heap.GetValue(nei.Destination), nei.Weight);
                    _heap.Delete(nei.Destination);
                    _heap.Push(nei.Destination, min);
                }
            }
        }

        private WeightedEdge GetMinOrDefaultEdgePointingToVisitedSet(IEnumerable<WeightedEdge> edges)
        {
            WeightedEdge minEdge = null;
            int min = int.MaxValue;

            foreach (var edge in edges)
            {
                if (!_visited.Contains(edge.Destination) || edge.Weight >= min) continue;

                min = edge.Weight;
                minEdge = edge;
            }

            return minEdge;
        }

        private IEnumerable<WeightedEdge> GetNeighbors(int i)
        {
            return !_graph.ContainsKey(i) ? EMPTY : _graph[i];
        }
    }
}
