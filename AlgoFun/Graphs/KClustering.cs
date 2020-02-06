using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;

public class KClustering
{
    public int Compute(IEnumerable<FullWeightedEdge> edges, int n, int k)
    {
        if (n < k) return -1;

        var uf = new UnionFind(n);

        foreach (var edge in edges.OrderBy(x => x.Weight))
        {
            if (uf.Find(edge.Source) == uf.Find(edge.Destination)) continue;

            if (n == k)
            {
                return edge.Weight;
            }
            else
            {
                uf.Union(edge.Source, edge.Destination);
                n--;
            }
        }

        return -1;
    }
}