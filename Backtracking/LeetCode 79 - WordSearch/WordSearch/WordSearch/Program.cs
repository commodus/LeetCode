﻿//创建IsExist函数，传入参数为board, word，index(当前字母在word中的index)，x，y(当前board中坐标)。
//如果x或y越界，或者word中index指向的字母和x，y在board中指向的字母不同，则返回false。
//如果当前index指向了word的最后一个字母，并且在上一步没有返回false，则证明可以递归走到word最后一个字母，并且去board中的字母相同，则返回true。
//先用以个record记录一下当前board中所指向的字母，在将该字母设为一个非法字母、
//创建isExist，使他等于递归条用index+1和当前坐标上下左右四个位置。
//回溯时将board[x][y]复原。并返回isExist。
using System;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[3][]
            {
                new []{ 'A', 'B', 'C', 'E' },
                new []{ 'S', 'F', 'C', 'S' },
                new []{ 'A', 'D', 'E', 'E' },
            };
            string word = "ABCCED";
            Console.WriteLine(Exist(board, word));
        }
        static bool Exist(char[][] board, string word)
        {
            if (board.Length == 0 || board[0].Length == 0) return false;
            int row = board.Length, col = board[0].Length;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (IsExist(board, word, 0, r, c))
                        return true;
                }
            }
            return false;
        }

        static bool IsExist(char[][] board, string word, int index, int x, int y)
        {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length || word[index] != board[x][y])
                return false;
            if (index == word.Length - 1)
                return true;
            var record = board[x][y];
            board[x][y] = '0';
            var isExist = IsExist(board, word, index + 1, x - 1, y) ||
                          IsExist(board, word, index + 1, x + 1, y) ||
                          IsExist(board, word, index + 1, x, y - 1) ||
                          IsExist(board, word, index + 1, x, y + 1);
            board[x][y] = record;
            return isExist;
        }
    }
}
