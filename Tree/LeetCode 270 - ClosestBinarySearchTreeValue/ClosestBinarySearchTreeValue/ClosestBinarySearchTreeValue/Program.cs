﻿using System;
using System.Collections.Generic;

namespace ClosestBinarySearchTreeValue
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ClosestValue_BFS(TreeNode root, double target)
        {
            var queue = new Queue<TreeNode>();
            double min = double.MaxValue;
            int res = 0;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    min = Math.Min(min, Math.Abs(cur.val - target));
                    if (Math.Abs(cur.val - target) == min)
                        res = cur.val;
                    if(cur.left != null) queue.Enqueue(cur.left);
                    if(cur.right != null) queue.Enqueue(cur.right);
                }
            }
            return res;
        }
    }
}
