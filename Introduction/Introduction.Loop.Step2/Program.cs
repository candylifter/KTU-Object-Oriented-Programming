﻿using System;

namespace Introduction.Loop.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaiciai nuo 5 iki 15 ir ju kvadratai:");
            for (int i = 5; i <= 15; i++)
            {
                Console.WriteLine("{0} {1}", i, i * i);
            }

            Console.ReadKey();

        }
    }
}
