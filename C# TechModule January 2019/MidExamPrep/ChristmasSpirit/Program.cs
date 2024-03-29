﻿using System;

namespace ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int spirit = 0;
            int totalCost = 0;

            int ornamentSetPrice = 2;
            int treeSkirtPrice = 5;
            int treeGarlandsPrice = 3;
            int treeLightsPrice = 15;
            int lastDay = 0;

            for (int i = 1; i <= days; i++)
            {
                lastDay = i;

                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 == 0)
                {
                    totalCost += ornamentSetPrice * quantity;
                    spirit += 5;
                }
                if (i % 3 == 0)
                {
                    totalCost += treeSkirtPrice * quantity;
                    totalCost += treeGarlandsPrice * quantity;
                    spirit += 13;
                }
                if (i % 5 == 0)
                {
                    totalCost += treeLightsPrice * quantity;
                    spirit += 17;

                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }
                if (i % 10 == 0)
                {
                    spirit -= 20;
                    totalCost += 23;
                }

            }
            if (lastDay % 10 == 0)
            {
                spirit -= 30;
            }
            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
