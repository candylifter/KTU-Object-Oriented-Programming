using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            //         { 1/x, -4 <= x < -2
            // f(x) =  { cosx, -2 <= x <= 2
            //         { 2x + 4

            double x, result;

            Console.WriteLine("Iveskite x reiksme:");
            x = double.Parse(Console.ReadLine());

            if (x >= -4 && x < -2)
            {
                result = 1 / x;
            }
            else if (x >= -2 && x <= 2)
            {
                result = Math.Cos(x);
            }
            else
            {
                result = 2 * x + 4;
            }

            Console.WriteLine("x = {0}, f(x) = {1:N3}", x, result);

            Console.ReadKey();
        }
    }
}
