﻿using System;
using System.Linq;

namespace CondenseArrayТoNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] condensed = new int[numbers.Length - 1];

            if (numbers.Length == 1)
            {
                Console.WriteLine($"{numbers[0]}");
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = numbers[j] + numbers[j + 1];
                }
                numbers = condensed;                
            }
            Console.WriteLine(numbers[0]);

        }
    }
}
