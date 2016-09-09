using System;

namespace Introduction.Loop.Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            int mini;
            int maxi;

            Console.WriteLine("Iveskite ciklo pradzios reiksme:");
            mini = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite ciklo pabaigos reiksme:");
            maxi = int.Parse(Console.ReadLine());
            
            int counter = 0;

            Console.WriteLine("Skaiciai nuo {0} iki {1} ir ju kvadratai bei kubai:", mini, maxi);
            for (; mini <= maxi; mini++)
            {
                Console.WriteLine("{0} {1} {2}", mini, mini * mini, mini * mini * mini);
                counter++;
            }

            Console.WriteLine("Buvo skaiciuota kartu: {0}", counter);

            Console.ReadKey();
        }
    }
}
