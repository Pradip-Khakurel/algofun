using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Graphs;
using AlgoFun.DP;
using AlgoFun.Heaps;

namespace AlgoFun.Heuristics
{
    public class TravelingSalesmanHeuristics
    {
        public class City
        {
            public double x { get; set; }

            public double y { get; set; }
        }

        public double Compute(City[] cities)
        {
            var n = cities.Count();
            var unvisited = new HashSet<int>();
            var result = 0d;

            for (int i = 1; i < n; i++) unvisited.Add(i);

            var last = 0;

            while (unvisited.Count > 0)
            {
                var minDist = double.MaxValue;
                var minId = n;

                foreach (var curId in unvisited)
                {
                    var curDist = TravelingSalesman.EuclideanDistance(cities[last].x, cities[last].y, cities[curId].x, cities[curId].y);

                    if (curDist < minDist || (curDist == minDist && curId < minId))
                    {
                        minId = curId;
                        minDist = curDist;
                    }
                }

                unvisited.Remove(minId);

                last = minId;
                result += minDist;
            }

            return result + TravelingSalesman.EuclideanDistance(cities[0].x, cities[0].y, cities[last].x, cities[last].y);
        }

    }
}