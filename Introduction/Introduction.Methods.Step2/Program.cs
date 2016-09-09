﻿using System;

namespace Introduction.Methods.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            double functionResult;
            int a;
            double x;

            Console.WriteLine("Įveskite a reiškmę");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite x reiškmę");
            x = double.Parse(Console.ReadLine());

            functionResult = CalculateFunctionValue(a, x);
            Console.WriteLine(" Reikšmė a = {0}, reiškmė x = {1}, fx = {2}", a, x, functionResult);
            Console.ReadKey();
        }

        static double CalculateFunctionValue(int a, double x)
        {
            double value;

            if (x <= 0)
            {
                value = a * Math.Exp(-x);
            }
            else if (x < 1)
            {
                value = 5 * a * x - 7;
            }
            else
            {
                value = Math.Pow(x + 1, 0.5);
            }

            return value;
        }
    }
}
