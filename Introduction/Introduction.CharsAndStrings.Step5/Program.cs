using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step5
{
    class Program
    {
        static void Main(string[] args)
        {
            string day;
            Console.WriteLine("Kokia šiandien savaitės diena?");
            day = Console.ReadLine();

            switch (day) 
            {
                case "pirmadienis":
                    Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
                    break;
                case "antradienis":
                    Console.WriteLine("Antradienis - aktyvių veiksmų diena.");
                    break;
                case "treciadienis":
                    Console.WriteLine("Trečiadienis - sandoriams sudaryti tinkamiausia diena.");
                    break;
                case "ketvirtadienis":
                    Console.WriteLine("Ketvirtadienį reiktų imtis visuomeninių darbų");
                    break;
                case "penktadienis":
                    Console.WriteLine("Penktadienį lengvai gimsta šedevrai, susitinka mylimieji.");
                    break;
                case "sestadienis":
                    Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
                    break;
                case "sekmadienis":
                    Console.WriteLine("Sekmadienį reiktų pradėti naujus darbus.");
                    break;
                default:
                    Console.WriteLine("Tokios savaitės dienos pas mus nebūna");
                    break;
            }

            Console.ReadKey();
        }
    }
}
