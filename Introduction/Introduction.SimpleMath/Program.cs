﻿using System;

namespace Introduction.SimpleMath
{
    class Program
    {
        static void Main(string[] args)
        {
            // f(x) = sqrt(z-1)

            double squareRootResult;
            int z;

            Console.WriteLine("Iveskite z reiksme:");
            z = int.Parse(Console.ReadLine());

            if (z - 1 >= 0)
            {
                squareRootResult = Math.Pow(z - 1, 0.5);
                Console.WriteLine(" z = {0}, f(x) = {1}", z, squareRootResult);
            }
            else 
            {
                Console.WriteLine(" z = {0}, f-cija neegzistuoja", z);
            }

            Console.ReadKey();

        }
    }
}
