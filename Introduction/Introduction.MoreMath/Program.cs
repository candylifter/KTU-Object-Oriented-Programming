using System;

namespace Introduction.MoreMath
{
    class Program
    {
        static void Main(string[] args)
        {
            //          { ae^-x, x<=0
            // f(x) =   { 5ax - 7, 0 < x < 1
            //          { sqrt(x+1)

            int a;
            double x;
            double functionResult;

            Console.WriteLine("Iveskite a reiksme:");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Iveskite x reiksme:");
            x = double.Parse(Console.ReadLine());

            if ( x <= 0 )
            {
                functionResult = a * Math.Exp(-x);
            }
            else if ( x < 1 )
            {
                functionResult = 5 * a * x - 7;
            }
            else
            {
                functionResult = Math.Pow(x + 1, 0.5);
            }

            Console.WriteLine(" Reiksme a = {0}, x = {1}, f(x) = {2}", a, x, functionResult);
            Console.ReadKey();
    
        }
    }
}
