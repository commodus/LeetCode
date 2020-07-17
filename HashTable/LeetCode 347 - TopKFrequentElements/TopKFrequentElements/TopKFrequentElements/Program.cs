﻿//统计每个数字出现的频率记录入字典。将字典中数字的频率加入一个列表，在对列表排序。
//利用linq语句找出字典中频率大于等于列表中倒数第k个频率的数字。
using System;
using System.Collections.Generic;
using System.Linq;

namespace TopKFrequentElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            int k = 1;
            Console.WriteLine(TopKFrequent(nums, k));
        }
        static int[] TopKFrequent(int[] nums, int k)
        {
            var numFreq = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!numFreq.ContainsKey(num))
                    numFreq[num] = 1;
                else
                    numFreq[num]++;
            }
            var freqOrder = numFreq.Select(x => x.Value).ToList();
            freqOrder.Sort();
            var threshold = freqOrder[freqOrder.Count - k];
            return numFreq.Where(x => x.Value >= threshold).Select(x => x.Key).ToArray();
        }
    }
}
