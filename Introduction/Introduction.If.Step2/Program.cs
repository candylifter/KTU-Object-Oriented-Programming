using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.If.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;

            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = (char)Console.Read();

            for (int i = 1; i < 51; i++)
            {
                Console.Write(character);
                if (i % 5 == 0)
                {
                    Console.WriteLine(character);
                }
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
