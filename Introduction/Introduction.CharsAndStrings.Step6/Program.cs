using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction.CharsAndStrings.Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> weekDays = new Dictionary<string, string>()
            {
                {"pirmadienis", "Pirmadienis - sudėtingiausia savaitės diena."},
                {"antradienis", "Antradienis - aktyvių veiksmų diena."},
                {"treciadienis", "Trečiadienis - sandoriams sudaryti tinkamiausia diena."},
                {"ketvirtadienis", "Ketvirtadienį reiktų imtis visuomeninių darbų"},
                {"penktadienis", "Penktadienį lengvai gimsta šedevrai, susitinka mylimieji."},
                {"sestadienis", "Šeštadienis - savo problemų sprendimo diena."},
                {"sekmadienis", "Sekmadienį reiktų pradėti naujus darbus."}
            };

            Console.WriteLine("Kokia siandien savaites diena?");
            string day = Console.ReadLine();

            if (weekDays.ContainsKey(day))
                Console.WriteLine("{0}", weekDays[day]);
            else
                Console.WriteLine("Tokios savaites dienos pas mus nebuna");

            Console.ReadKey();
        }
    }
}
