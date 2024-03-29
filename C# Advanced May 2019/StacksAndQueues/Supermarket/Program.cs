﻿using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while (input != "End")
            {
                switch (input)
                {
                    case "Paid":
                        while (queue.Count != 0)
                        {
                            Console.WriteLine(queue.Dequeue());
                        }
                        break;
                    default:
                        queue.Enqueue(input);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
