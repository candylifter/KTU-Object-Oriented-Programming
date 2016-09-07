using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Loop.Step5
{
    class Program
    {
        static void Main(string[] args)
        {
            int mini = 5;
            int maxi = 15;
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
