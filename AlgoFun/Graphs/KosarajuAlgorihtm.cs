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
        private Dictionary<int, int> _finishingTimesRev;
        private Dictionary<int, int> _leaderOf;
        private List<int> _sccs;
        private HashSet<int> _visited;

        private int _n;
        private int _t;

        public IDictionary<int, int> LeaderOf => _leaderOf;

        public KosarajuAlgorihtm(Dictionary<int, List<int>> graph, int n)
        {
            _t = 0;
            _n = n;

            _graph = graph;
            _graphRev = GetReverseGraph();
            _finishingTimesRev = Enumerable.Range(0, _n).ToDictionary(x => x, _ => -1);
            _leaderOf = _graph.Keys.ToDictionary(k => k, k => k);
            _sccs = new List<int>();
            _visited = new HashSet<int>();
        }

        public List<int> ComputeSccs()
        {
            _visited.Clear();

            foreach(var i in _graphRev.Keys)
            {
                if (_visited.Contains(i)) continue;

                FirstPassDfs(i);
            }

            _visited.Clear();

            for (int t = _n - 1; t >= 0; t--)
            {
                var i = _finishingTimesRev[t];

                if (_visited.Contains(i)) continue;

                _sccs.Add(SecondPassDfs(i));
            }

            _sccs.Sort((a, b) => b.CompareTo(a));

            return _sccs;
        }

        private Dictionary<int, List<int>> GetReverseGraph()
        {
            var graphRev = new Dictionary<int, List<int>>(_n);

            foreach(var i in _graph.Keys)
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
            _visited.Add(i);

            var neighboors = _graphRev.ContainsKey(i) ? _graphRev[i] : EMPTY;

            foreach (var nei in neighboors)
            {
                if (_visited.Contains(nei)) continue;

                FirstPassDfs(nei);
            }

            _finishingTimesRev[_t] = i;
            _t++;
        }

        private int SecondPassDfs(int i)
        {
            var stack = new Stack<int>();
            var count = 0;

            _visited.Add(i);
            _leaderOf[i] = i;
            stack.Push(i);

            while(stack.Any())
            {                
                var cur = stack.Pop();
                var neighboors = _graph.ContainsKey(cur) ? _graph[cur] : EMPTY;

                count++;

                foreach (var nei in neighboors)
                {
                    if(_visited.Contains(nei)) continue;
                    _visited.Add(nei);
                    _leaderOf[nei] = i;
                    stack.Push(nei);
                }
            }

            return count;
        }
    }
}
