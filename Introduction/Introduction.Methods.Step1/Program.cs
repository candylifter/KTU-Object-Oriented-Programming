using System;

namespace Introduction.Methods.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            Console.WriteLine("Įveskite spausdinamą simbolį:");
            character = (char)Console.Read();
            Print(character);
            Console.ReadKey();

        }

        static void Print(char characterToPoint)
        {
            for (int i = 1; i < 51; i++)
            {
                if (i % 5 == 0)
                    Console.WriteLine(characterToPoint);
                else
                    Console.Write(characterToPoint);
            }
            Console.WriteLine("");
        }
    }
}
