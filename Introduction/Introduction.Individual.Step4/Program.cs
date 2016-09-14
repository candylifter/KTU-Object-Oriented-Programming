using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.Individual.Step4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> nameEndings = new Dictionary<string, string>() 
            {
                {"as", "ai"},
                {"is", "i"},
                {"ys", "y"},
                {"a", "a"},
                {"ė", "e"}
            };

            string name;

            Console.WriteLine("Iveskite varda:");
            name = Console.ReadLine();


            string formatedString = HandleNameEnding(nameEndings, name);
            Console.WriteLine("Labas, {0}!", formatedString);
            Console.ReadKey();
        }

        static string HandleNameEnding(Dictionary<string, string> nameEndings, string name)
        {
            string formatedName = name;
            foreach (var ending in nameEndings)
            {
                if (name.EndsWith(ending.Key))
                {
                    formatedName = name.Substring(0, name.Length - ending.Key.Length) + ending.Value;
                }
            }

            return formatedName;
        }
    }
}
