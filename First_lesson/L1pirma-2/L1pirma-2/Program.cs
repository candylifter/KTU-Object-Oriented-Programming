using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1pirma_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 3;
            int b = 8;
            int suma;

            Console.WriteLine("Iveskite sveikaja a reiksme");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite sveikaja b reiksme");
            b = int.Parse(Console.ReadLine());

            suma = a + b;

            Console.WriteLine("{0} + {1} = {2}", a, b, suma);

            Console.ReadLine();

        }
    }
}
