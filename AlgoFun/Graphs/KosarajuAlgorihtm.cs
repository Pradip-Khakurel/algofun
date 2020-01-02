using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoFun.Graphs
{
    public class KosarajuAlgorihtm
    {
        private static List<int> EMPTY = new List<int>(0);

        private Dictionary<int, List<int>> _graph;
        private Dictionary<int, List<int>> _graphRev;
        private int[] _finishingTimesRev;
        private List<int> _sccs;
        private bool[] _visited;

        private int _n;
        private int _t;

        public KosarajuAlgorihtm(Dictionary<int, List<int>> graph, int n)
        {
            _t = 0;
            _n = n;

            _graph = graph;
            _graphRev = GetReverseGraph();
            _finishingTimesRev = new int[_n];
            _sccs = new List<int>();
        }

        public List<int> ComputeSccs()
        {
            _visited = new bool[_n];

            for (int i = _n - 1; i >= 0; i--)
            {
                if (_visited[i]) continue;

                FirstPassDfs(i);
            }

            _visited = new bool[_n];

            for (int i = _n - 1; i >= 0; i--)
            {
                var j = _finishingTimesRev[i];

                if (_visited[j]) continue;

                _sccs.Add(SecondPassDfs(j));
            }

            _sccs.Sort((a, b) => b.CompareTo(a));

            return _sccs;
        }

        private Dictionary<int, List<int>> GetReverseGraph()
        {
            var graphRev = new Dictionary<int, List<int>>(_n);

            for (int i = 0; i < _n; i++)
            {
                if (!_graph.ContainsKey(i)) continue;

                var neighboors = _graph[i];

                foreach (var nei in neighboors)
                {
                    if (!graphRev.ContainsKey(nei))
                    {
                        graphRev.Add(nei, new List<int>());
                    }

                    graphRev[nei].Add(i);
                }
            }


            return graphRev;
        }

        private void FirstPassDfs(int i)
        {
            _visited[i] = true;

            var neighboors = _graphRev.ContainsKey(i) ? _graphRev[i] : EMPTY;

            foreach (var nei in neighboors)
            {
                if (_visited[nei]) continue;

                FirstPassDfs(nei);
            }

            _finishingTimesRev[_t] = i;
            _t++;
        }

        private int SecondPassDfs(int i)
        {
            var stack = new Stack<int>();
            var count = 0;

            _visited[i] = true;
            stack.Push(i);

            while(stack.Any())
            {                
                var cur = stack.Pop();
                var neighboors = _graph.ContainsKey(cur) ? _graph[cur] : EMPTY;

                count++;

                foreach (var nei in neighboors)
                {
                    if(_visited[nei]) continue;
                    _visited[nei] = true;
                    stack.Push(nei);
                }
            }

            return count;
        }
    }
}
