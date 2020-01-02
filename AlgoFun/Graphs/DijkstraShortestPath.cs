using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun.Graphs
{
    public class DijkstraShortestPath
    {
        private const int INF = 1000000;
        private int _n;
        private IDictionary<int, List<WeightedEdge>> _graph;
        private PriorityQueue<int, int> _heap;
        private int[] _dist;
        private int _src;

        public DijkstraShortestPath(IDictionary<int, List<WeightedEdge>> graph, int n, int src)
        {
            _n = n;
            _graph = graph;
            _heap = new PriorityQueue<int, int>(_n, Comparer<int>.Create((x, y) => y.CompareTo(x)));
            _dist = new int[_n];
            _src = src;

            InitializeHeap();
        }

        public int[] Compute()
        {
            while(_heap.Count >  0) 
            {
                var nearest = _heap.Top;

                _heap.Pop();

                _dist[nearest.Key] = nearest.Value;

                Relax(nearest.Key);
            }

            return _dist;
        }

        private void Relax(int v)
        {
            var edges = _graph.ContainsKey(v) ? _graph[v] : new List<WeightedEdge>(0);

            foreach (var edge in edges)
            {
                if(!_heap.Contains(edge.Destination)) 
                {
                    continue;
                }

                var newDist = Math.Min(_heap.GetValue(edge.Destination), _dist[v] + edge.Weight);
                _heap.Delete(edge.Destination);
                _heap.Push(edge.Destination, newDist);
            }
        }

        private void InitializeHeap() 
        {
            for (int i = 0; i < _n; i++)
            {
                if (i == _src)
                { 
                    _dist[i] = 0;
                }
                else 
                {
                    _dist[i] = INF;
                    _heap.Push(i, INF);
                }
            }

            Relax(_src);
        }
    }
}