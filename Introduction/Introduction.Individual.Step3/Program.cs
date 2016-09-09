using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber, secondNumber, result;
            char operation;

            Console.WriteLine("Įveskite pirmą skaičių:");
            firstNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite antrą skaičių:");
            secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite operacijos simbolį: (+, -, *, /)");
            operation = char.Parse(Console.ReadLine());

            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    Console.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber, result);
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    Console.WriteLine("{0} - {1} = {2}", firstNumber, secondNumber, result);
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    Console.WriteLine("{0} * {1} = {2}", firstNumber, secondNumber, result);
                    break;
                case '/':
                    result = firstNumber / secondNumber;
                    Console.WriteLine("{0} / {1} = {2:N3}", firstNumber, secondNumber, result);
                    break;
                default:
                    Console.WriteLine("KLAIDA");
                    break;
            }


            Console.ReadKey();
        }
    }
}
