﻿//创建入度表和出度表，根据graph填写入度表和出度表。出度表为有几条路径从当前节点出发。入度表为有那几个节点指向当前节点。
//将出度为0的节点入队，并加入结果。
//在队不为空的条件下循环，弹出对头，将它入度表的所有节点的出度减一。如果该节点出度为0，则将其加入结果并入队。
//最后给结果排序。
using System;
using System.Collections.Generic;

namespace FindEventualSafeStates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] graph = new int[][]
            {
                new int[]{1, 2}, 
                new int[]{2, 3}, 
                new int[]{5}, 
                new int[]{0}, 
                new int[]{5}, 
                new int[]{}, 
                new int[]{} 
            };
            Console.WriteLine(EventualSafeNodes_BFS(graph));
        }
        static IList<int> EventualSafeNodes_BFS(int[][] graph)
        {
            var outDegree = new int[graph.Length];
            var inDegree = new List<int>[graph.Length];
            var safeNode = new bool[graph.Length];
            for (int i = 0; i < inDegree.Length; i++)
                inDegree[i] = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                outDegree[i] += graph[i].Length;
                foreach (var edge in graph[i])
                    inDegree[edge].Add(i);
            }
            var queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (outDegree[i] == 0)
                {
                    queue.Enqueue(i);
                    safeNode[i] = true;
                }
            }
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var next in inDegree[cur])
                {
                    outDegree[next]--;
                    if (outDegree[next] == 0)
                    {
                        queue.Enqueue(next);
                        safeNode[next] = true;
                    }
                }
            }
            var res = new List<int>();
            for (int i = 0; i < safeNode.Length; i++)
                if(safeNode[i]) res.Add(i);
            return res;
        }
    }
}
