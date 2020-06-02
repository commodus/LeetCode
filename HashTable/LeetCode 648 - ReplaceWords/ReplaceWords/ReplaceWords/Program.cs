﻿//创建IsSuch方法检查一个successor是否能被一个root所替代。逻辑为如果successor的长度小于root的长度，则返回false
//只有root的每一个字母都与successor对应位置的字母相同，则返回true。
//在主方法中，将sentence用Split函数转化为字符串数组，并存入words。创建roots列表，将dict中的每个单词存入roots，并按照其长度排序。
//遍历words中的每一个单词，遍历roots中的每一个root，对其和当前遍历到的单词调用isSuc函数检查是否可以替换，如可以替换，则替换，并停止对roots的遍历。
//最后创建res，并将替换后的words拼入res，并返回res。
using System;
using System.Collections.Generic;

namespace ReplaceWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dict = new List<string>() { "cat", "bat", "rat" };
            string sentence = "the cattle was rattled by the battery";
            Console.WriteLine(ReplaceWords(dict, sentence));
        }
        static bool IsSuc(string root, string successor)
        {
            if (successor.Length < root.Length)
                return false;
            for (int i = 0; i < root.Length; i++)
                if (root[i] != successor[i])
                    return false;
            return true;
        }
        static string ReplaceWords(IList<string> dict, string sentence)
        {
            var words = sentence.Split(' ');
            var roots = new List<string>();
            foreach (var root in dict)
                roots.Add(root);
            roots.Sort();
            for (int i = 0; i < words.Length; i++)
            {
                foreach (var root in roots)
                {
                    if (IsSuc(root, words[i]))
                    {
                        words[i] = root;
                        break;
                    }
                }
            }
            string res = "";
            foreach (var word in words)
                res += word + " ";
            return res.Substring(0, res.Length - 1);
        }
    }
}
