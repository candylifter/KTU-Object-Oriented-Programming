using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual.Step1
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


            firstSolution(symbolCount, character, lineSymbolCount);
            //secondSolution(symbolCount, character, lineSymbolCount);
            //thirdSolution(symbolCount, character, lineSymbolCount);


            Console.WriteLine("");
            Console.ReadKey();
        }

        static void firstSolution(int symbolCount, char character, int lineSymbolCount)
        {
            for (int i = 1; i <= symbolCount; i++)
            {
                Console.Write(character);

                for (int j = 1; i % lineSymbolCount == 0 && j <= lineSymbolCount; j++)
                {
                    Console.WriteLine();
                    break;
                }
            }
        }

        static void secondSolution(int symbolCount, char character, int lineSymbolCount)
        {
            for (int i = 1; i <= symbolCount / lineSymbolCount; i++)
            {
                for (int j = 1; j <= lineSymbolCount; j++)
                {
                    Console.Write(character);
                }

                Console.WriteLine();
            }

            for (int i = 1; i <= symbolCount % lineSymbolCount; i++)
            {
                Console.Write(character);
            }
        }

        static void thirdSolution(int symbolCount, char character, int lineSymbolCount)
        {
            for (int i = 1; i <= symbolCount; i++)
            {
                Console.Write(character);

                for (; i % lineSymbolCount == 0;)
                {
                    Console.WriteLine();
                    break;
                }
            }
        }

    }
}
