﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VerifyingAnAlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";
            Console.WriteLine(IsAlienSorted(words, order));
        }
        static bool IsAlienSorted(string[] words, string order)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
                dict[order[i]] = i + 1;
            for (int i = 1; i < words.Length; i++)
            {
                bool flag = false;
                var word1 = words[i - 1];
                var word2 = words[i];
                for (int j = 0; j < word1.Length && j < word2.Length; j++)
                {
                    if (dict[word1[j]] < dict[word2[j]])
                    {
                        flag = true;
                        break;
                    }
                    else
                        return false;
                }
                if (!flag && word1.Length > word2.Length)
                    return false;
            }
            return true;
        }
    }
}
