using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            int symbolCount;
            int lineSymbolCount;


            Console.WriteLine("Iveskite spausdinama simboli");
            character = char.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite bendra spausdinamu simboliu kieki");
            symbolCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite vienos eilutes simboliu kieki");
            lineSymbolCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= symbolCount; i++)
            {
                if (i % lineSymbolCount == 0)
                {
                    Console.WriteLine(character);
                }
                else 
                {
                    Console.Write(character);
                }
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
