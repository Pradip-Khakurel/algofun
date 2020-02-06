using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Greedy;
using System.IO;
using AlgoFun.Graphs;

[TestFixture]
public class KClusteringTest
{
    [Test]
    public void TestTwoEdges()
    {
        var edges = new[]
        {
            new FullWeightedEdge() { Source = 0, Destination = 1, Weight = 1 },
            new FullWeightedEdge() { Source = 1, Destination = 2, Weight = 2 }
        };

        var dist = new KClustering().Compute(edges, 2, 2);

        Assert.That(dist, Is.EqualTo(1));
    }

    [Test]
    public void TestFile()
    {
        var lines = File.ReadAllLines("Clustering1.txt");
        var n = int.Parse(lines[0]);
        var edges = new List<FullWeightedEdge>();

        for (int i = 1; i < lines.Length; i++)
        {
            var split = lines[i].Split(" ");

            edges.Add(new FullWeightedEdge()
            {
                Source = int.Parse(split[0])-1,
                Destination = int.Parse(split[1])-1,
                Weight = int.Parse(split[2]),
            });
        }

        var dist = new KClustering().Compute(edges, n, 4);

    }

}