using System;

namespace Introduction.Loop.Step4
{
    class Program
    {
        static void Main(string[] args)
        {
            int mini = 5;
            int maxi = 15;


            Console.WriteLine("Skaiciai nuo {0} iki {1} ir ju kvadratai bei kubai:", mini, maxi);
            for (; mini <= maxi; mini++)
            {
                Console.WriteLine("{0} {1} {2}", mini, mini * mini, mini * mini * mini);
            }

            Console.ReadKey();
        }
    }
}
