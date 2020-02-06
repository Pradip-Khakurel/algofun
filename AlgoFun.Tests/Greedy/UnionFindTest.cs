using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AlgoFun.Greedy;
using System.IO;

[TestFixture]
public class UnionFindTest 
{
    [Test]
    public void TestOneUnion() 
    {
        var uf = new UnionFind(10);

        uf.Union(0, 9);

        Assert.That(uf.Find(0) == uf.Find(9), Is.True);
        Assert.That(uf.Find(9), Is.EqualTo(0));
    }

    [Test]
    public void TestTwoComponentsUnion() 
    {
        var uf = new UnionFind(10);

        uf.Union(0, 1);
        uf.Union(8, 9);
        uf.Union(1, 8);

        Assert.That(uf.Find(0) == uf.Find(9), Is.True);
        Assert.That(uf.Find(9), Is.EqualTo(0));
    }


    [Test]
    public void TestNComponentsUnion() 
    {
        var uf = new UnionFind(10);

        uf.Union(0, 1);
        uf.Union(8, 9);
        uf.Union(1, 8);
        uf.Union(7, 6);
        uf.Union(1, 6);

        Assert.That(uf.Find(7) == uf.Find(9), Is.True);
        Assert.That(uf.Find(7), Is.EqualTo(0));
    }

}