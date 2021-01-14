﻿using System;

namespace MinimumOperationsToReduceXToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 8828, 9581, 49, 9818, 9974, 9869, 9991, 10000, 10000, 10000, 9999, 9993, 9904, 8819, 1231, 6309 };
            int x = 134365;
            Console.WriteLine(MinOperations_Prefix(nums, x));
        }
        static int MinOperations_Suffix(int[] nums, int x)
        {
            int[] prefix = new int[nums.Length + 1], suffix = new int[nums.Length + 1];
            var res = int.MaxValue;
            for (int i = 1; i < prefix.Length; i++)
            {
                prefix[i] = prefix[i - 1] + nums[i - 1];
                suffix[i] = suffix[i - 1] + nums[^i];
            }
            for (int i = 0; i < prefix.Length && x - prefix[i] >= 0; i++)
            {
                var index = Array.BinarySearch(suffix, 0, suffix.Length - i, x - prefix[i]);
                if (index >= 0)
                    res = Math.Min(res, i + index);
            }
            return res == int.MaxValue ? -1 : res;
        }
        static int MinOperations_Prefix(int[] nums, int x)
        {
            var prefix = new int[nums.Length + 1];
            var suffix = new int[nums.Length + 1];
            for (int i = 1; i < nums.Length; i++)
            {
                prefix[i] = prefix[i - 1] + nums[i - 1];
                suffix[^(i + 1)] = suffix[^i] + nums[^i];
            }
            var res = int.MaxValue;
            for (int i = suffix.Length - 1; i >= 0; i--)
            {
                var index = Array.BinarySearch(prefix, 0, i + 1, x - suffix[i]);
                if (index >= 0)
                    res = Math.Min(res, index + nums.Length - i);
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
}
