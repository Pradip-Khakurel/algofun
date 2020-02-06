using System;
using System.Collections.Generic;

public class UnionFind 
{
    private readonly int[] _leaderOf;
    private readonly IDictionary<int, List<int>> _childrenOf;
    private readonly int[] _ranksOf;

    public UnionFind(int n) 
    {
        _leaderOf = new int[n];
        _childrenOf = new Dictionary<int, List<int>>();
        _ranksOf = new int[n];

        for (int i = 0; i < n; i++)
        {
            _leaderOf[i] = i;
            _childrenOf.Add(i, new List<int>() { i });           
        }
    }

    public void Union(int x, int y) 
    {
        x = Find(x);
        y = Find(y);

        if(x == y) return;

        int min = _ranksOf[x] < _ranksOf[y] ? x : y; 
        int max = _ranksOf[x] < _ranksOf[y] ? y : x; 

        _ranksOf[max]++;

        foreach (var child in _childrenOf[min])
        {
            _childrenOf[max].Add(child);
            _leaderOf[child] = max;
        }

        _childrenOf.Remove(min);
    }

    public int Find(int x) 
    {
        return _leaderOf[x];
    }
}