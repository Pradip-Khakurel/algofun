using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;
using AlgoFun.DP;
using AlgoFun.Heaps;

namespace AlgoFun.Heuristics
{
    public class TwoSat
    {
        public bool IsSatisfy(Tuple<int, int>[] clauses)
        {
            var graph = InitGraph(clauses);
            var algo = new KosarajuAlgorihtm(graph, graph.Keys.Count);

            algo.ComputeSccs();

            return !graph.Any(p => graph.ContainsKey(p.Key) && graph.ContainsKey(-p.Key) 
                                    && algo.LeaderOf[p.Key] == algo.LeaderOf[-p.Key]);            
        }

        private Dictionary<int, List<int>> InitGraph(Tuple<int, int>[] clauses)
        {
            var graph = new Dictionary<int, List<int>>();

            foreach (var cl in clauses)
            {
                if(!graph.ContainsKey(-cl.Item1)) graph.Add(-cl.Item1, new List<int>());

                graph[-cl.Item1].Add(cl.Item2);

                if(!graph.ContainsKey(-cl.Item2)) graph.Add(-cl.Item2, new List<int>());

                graph[-cl.Item2].Add(cl.Item1);
            }

            return graph;
        }
    }
}