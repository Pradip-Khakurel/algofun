using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgoFun 
{
    public class KargerMinCut 
    {
        private readonly Dictionary<int, List<int>> _nodes;

        private Dictionary<int, HashSet<int>> _groups;
        private HashSet<Tuple<int, int>> _edges;

        public KargerMinCut(Dictionary<int, List<int>> nodes) 
        {
            _nodes = nodes;
        }

        public int TryGetMin(int n)
        {
            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                min = Math.Min(min, GetCut());
            }

            return min;
        }

        private int GetCut() 
        {
            if(_nodes.Count <= 2) return _nodes.Count;
            
            InitGroups(); 
            InitEdges();          
            Contract();

            var count = 0;
            var groupA = _groups.First().Value;            
            
            foreach (var id in groupA)
            {
                foreach (var neigh in _nodes[id])
                {
                    if(groupA.Contains(neigh)) continue;
                    count++;
                }
            }

            return count;
        }

        private void InitEdges()
        {
            _edges = new HashSet<Tuple<int, int>>();
            
            foreach (var node in _nodes)
            {
                foreach (var neigh in node.Value)
                {                    
                    var first = Math.Min(node.Key, neigh);
                    var second = Math.Max(node.Key, neigh);
                    var tuple = new Tuple<int, int>(first, second);

                    if(first == second || _edges.Contains(tuple)) continue;

                    _edges.Add(tuple);
                }
            }
        }

        private void InitGroups() 
        {
            _groups = new Dictionary<int, HashSet<int>>();

            foreach (var node in _nodes)
            {
                _groups.Add(node.Key, new HashSet<int>() { node.Key });
            }            
        }

        private void Contract()
        {       
            var rand = new Random(Guid.NewGuid().GetHashCode());

            while(_groups.Count > 2) 
            {                
                var edge = _edges.ElementAt(rand.Next(0, _edges.Count));                
                var first = _groups.First(g => g.Value.Contains(edge.Item1));
                var second = _groups.First(g => g.Value.Contains(edge.Item2));

                foreach (var id in second.Value)
                {
                    first.Value.Add(id);
                }

                RemoveSelfLoops(first.Value);

                _groups.Remove(second.Key);                                
            }
        }

        private void RemoveSelfLoops(HashSet<int> group)
        {
                var selfloops = new List<Tuple<int, int>>();

                foreach (var edg in _edges)
                {
                    if(group.Contains(edg.Item1) && group.Contains(edg.Item2)) 
                    {
                        selfloops.Add(edg);
                    }
                }

                foreach (var slf in selfloops)
                {
                    _edges.Remove(slf);
                }
        }
    } 
}