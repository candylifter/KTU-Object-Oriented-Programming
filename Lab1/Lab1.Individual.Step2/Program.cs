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

        static List<Fridge> CreateBoschFridges()
        {
            _handlers = new FridgeHandlers();

            var fridges = new List<Fridge>();

            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {

                var fridge = new Fridge()
                {
                    Manufacturer = "Bosch",
                    Model = "Freezer " + rnd.Next(100, 1000).ToString(),
                    Capacity = rnd.Next(30, 45),
                    Color = "Baltas",
                    EnergyClass = _handlers.GenerateRandomEnergyClass(rnd),
                    Width = rnd.Next(50, 60),
                    HasFreezer = true,
                    InstallationType = "Laisvai pastatomas",
                    Price = rnd.Next(500, 3000)
                };

                fridges.Add(fridge);
            }

            return fridges;
        }


        static void Main(string[] args)
        {
            _handlers = new FridgeHandlers();

            var fridges = _handlers.GetFridgesFromFile("Fridges.csv");

            var capacities = _handlers.GetCapacities(fridges);

            Console.WriteLine("\nTalpos:");
            _handlers.PrintArray(capacities);

            var cheapest = _handlers.GetCheapestPlacableWithFreezerFridge(fridges);

            Console.WriteLine("\nPigiausias pastatomas šaldytuvas su šaldikliu:");
            _handlers.PrintCheapest(cheapest);

            var boschFridges = CreateBoschFridges();

            var filteredBoschFridges = _handlers.FilteryByWidth(boschFridges, 52, 56);

            _handlers.PrintToFile(filteredBoschFridges, "Tilps.csv");


            _handlers.PrintToFile(boschFridges, "Bosch.csv");

            Console.ReadKey();
            
        }
    }
}
