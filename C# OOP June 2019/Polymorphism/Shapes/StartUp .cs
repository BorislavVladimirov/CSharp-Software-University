﻿using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[1000000];

            Shape rectagle = new Rectangle(5.5, 8.3);
            Shape circle = new Circle(2);

            Console.WriteLine(rectagle.CalculateArea());
            Console.WriteLine(rectagle.CalculatePerimeter());

        }
    }
}
