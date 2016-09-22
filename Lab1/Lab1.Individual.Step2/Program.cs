using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Individual.Step2
{
    /*
        Buitinės technikos parduotuvė. Apsigyvenote bendrabutyje, tačiau kambaryje trūksta svarbiausio
        daikto – šaldytuvo. Turite duomenis apie įmonėje „Viskas Namams“ parduodamus šaldytuvus.
        Duomenų faile pateikta ši informacija: gamintojas, modelis, talpa, energijos klasė, montavimo tipas,
        spalva, požymis „turi šaldiklį“, kaina.
         Raskite, kokių skirtingų talpų šaldytuvus galima įsigyti, šaldytuvų talpų sąrašą
        atspausdinkite ekrane.
         Raskite pigiausią pastatomą šaldytuvą, turintį šaldiklį, ekrane atspausdinkite jo gamintoją,
        modelį, talpą ir kainą.
         Sudarykite šaldytuvų, kurių plotis nuo 52 iki 56 cm, sąrašą, į failą „Tilps.csv“ įrašykite visus
        duomenis apie šiuos šaldytuvus.
         Sudarykite „Bosch“ gaminamų šaldytuvų sąrašą, į failą „Bosch.csv“ įrašykite visą
        informaciją apie šiuos šaldytuvus
     */
    class Program
    {

        private static FridgeHandlers _handlers; 

        static void Main(string[] args)
        {
            _handlers = new FridgeHandlers();

            var fridges = _handlers.GetFridgesFromFile("Fridges.csv");

            _handlers.PrintFridges(fridges);

            var capacities = _handlers.GetCapacities(fridges);

            Console.WriteLine("Talpos:\n");
            foreach (var capacity in capacities)
            {
                Console.Write("{0}, ", capacity);
            }

            Console.ReadKey();
            
        }
    }
}
