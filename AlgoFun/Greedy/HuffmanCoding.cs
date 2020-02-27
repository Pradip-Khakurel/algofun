using System;
using System.Collections.Generic;
using System.Linq;
using AlgoFun.Heaps;

public class HuffManCoding
{
    public class Node
    {
        public Node Left { get; set; }
        public Node right { get; set; }
                
        public Node()
        {
        }
    }

    public (int min, int max) Compute(IEnumerable<long> values)
    {
        if(values == null || values.Count() == 0) return (0, 0);

        PriorityQueue<Node, long> heap = ToHeap(values);

        Node head = Compute(heap);

        return MinMax(head);
    }

    private Node Compute(PriorityQueue<Node, long> heap)
    {
        while(heap.Count > 1) 
        {
            var first = heap.Top; heap.Pop();
            var second = heap.Top; heap.Pop();
            var node = new Node() { Left = first.Key, right = second.Key };
            heap.Push(node, first.Value+second.Value);
        }

        var head = heap.Top.Key; heap.Pop();

        return head;
    }

    public (int min, int max) MinMax(Node node)
    {        
        if(node == null) return (-1, -1);        

        var left = MinMax(node.Left);
        var right = MinMax(node.right);

        var min = Math.Min(left.min, right.min)+1; 
        var max = Math.Max(left.max, right.max)+1;

        return (min, max);
    }


    public PriorityQueue<Node, long> ToHeap(IEnumerable<long> values)
    {
        var n = values.Count();
        var heap = new PriorityQueue<Node, long>(n, Comparer<long>.Create((x, y) => y.CompareTo(x)));

        foreach (var val in values)
        {
            heap.Push(new Node(), val);
        }

        return heap;
    }
}