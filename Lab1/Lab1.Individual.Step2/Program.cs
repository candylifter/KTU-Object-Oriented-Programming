using System;

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

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _handlers = new FridgeHandlers();

            var fridges = _handlers.GetFridgesFromFile("Fridges.csv");

            var capacities = _handlers.GetCapacities(fridges);

            Console.WriteLine("Talpos:");
            _handlers.PrintArray(capacities);

            var cheapest = _handlers.GetCheapestPlacableWithFreezerFridge(fridges);

            Console.WriteLine("\nPigiausias pastatomas šaldytuvas su šaldikliu:");

            if (cheapest != null)
            {
                _handlers.PrintCheapest(cheapest);
            }
            else
            {
                Console.WriteLine("Nėra tokių šaldytuvų");
            }

            var filteredFridges = _handlers.FilterByWidth(fridges, 52, 56);

            _handlers.PrintToFile(filteredFridges, "Tilps.csv");

            Console.ReadKey();
            
        }
    }
}
