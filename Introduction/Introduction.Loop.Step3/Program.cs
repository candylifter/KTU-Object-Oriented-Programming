using System;

namespace Introduction.Loop.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaiciai nuo 5 iki 15 ir ju kvadratai bei kubai:");
            for (int i = 5; i <= 15; i++)
            {
                Console.WriteLine("{0} {1} {2}", i, i * i, i * i * i);
            }

            Console.ReadKey();
        }
    }
}
