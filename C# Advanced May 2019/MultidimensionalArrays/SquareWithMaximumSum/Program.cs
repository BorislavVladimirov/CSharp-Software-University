﻿using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class StartUp
    {
        public static void Main()
        {
            int[] dim = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dim[0], dim[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] token = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = token[j];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedCol = col;
                        selectedRow = row;
                    }
                }
            }

            Console.WriteLine($"{matrix[selectedRow, selectedCol]}" +
                $" {matrix[selectedRow, selectedCol + 1]}" + Environment.NewLine +
                $"{matrix[selectedRow + 1, selectedCol]} " +
                $"{matrix[selectedRow + 1, selectedCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
