using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/* U3-22. Buitinės technikos parduotuvė. Turite informaciją apie skirtingose buitinės technikos parduotuvėse
esančius šaldytuvus. Keičiasi duomenų formatas. Pirmoje eilutėje pavadinimas, antroje – adresas, trečioje –
telefonas. Toliau informacija apie šaldytuvus pateikta tokiu pačiu formatu kaip L1 užduotyje.
 Raskite, kokių skirtingų talpų šaldytuvus galima įsigyti, šaldytuvų talpų sąrašą
atspausdinkite ekrane.
 Raskite pigiausią pastatomą šaldytuvą, turintį šaldiklį, ekrane atspausdinkite kuriose
parduotuvėse galima jį įsigyti, jo gamintoją, modelį, talpą ir kainą.
 Sudarykite šaldytuvų, kurių plotis nuo 52 iki 56 cm, sąrašą, į failą „Tilps.csv“ įrašykite visus
duomenis apie šiuos šaldytuvus.
 Ar yra tokių šaldytuvų, kuriuos galima įsigyti visose parduotuvėje? Atspausdinkite tokių
šaldytuvų sąrašą faile „Visur.csv“. */
namespace Lab2.Individual.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop1 = GetShopFromFile("./Shop1.csv");
            var shop2 = GetShopFromFile("./Shop2.csv");
            var city = new City(2);
            city.AddShop(shop1);
            city.AddShop(shop2);

            var distinctCaps = city.FilterFridgesByDistinctCapacities();
            PrintCapacities(distinctCaps);

            var cheapestFridge = city.GetCheapestFridge();
            Shop[] hasCheapestShops = null;
            if (!Object.Equals(cheapestFridge, null)) { hasCheapestShops = city.FilterShopsByFridge(cheapestFridge); }
            PrintCheapestFridge(cheapestFridge, hasCheapestShops);

            var fridgesByRange = city.GetFridgesByWidthRange(52, 56);
            PrintFridgesToFile(fridgesByRange, "./Tilps.csv");

            var fridgesEverywhere = city.GetFridgesInAllShops();
            PrintFridgesToFile(fridgesEverywhere, "./Visur.csv");

            Console.ReadKey();
        }

        static void PrintFridgesToFile(Fridge[] fridges, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                if (Object.Equals(fridges, null))
                {
                    writer.WriteLine("No fridges found");
                }
                else
                {
                    foreach (var fridge in fridges)
                    {
                        string payload = String.Format(
                            "{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                            fridge.Manufacturer, fridge.Model, fridge.EnergyClass, fridge.Color, fridge.Price,
                            fridge.Capacity, fridge.InstallationType, fridge.HasFreezer, fridge.Width);

                        writer.WriteLine(payload);
                    }
                }
            }
        }

        static void PrintCheapestFridge(Fridge fridge, Shop[] shops)
        {

            Console.WriteLine("Cheapest fridge:");
            if (Object.Equals(fridge, null))
            {
                Console.WriteLine("No fridges found by this criteria");
            }
            else
            {
                Console.WriteLine(fridge.ToString());
                Console.WriteLine("Available in shops:");

                foreach (var shop in shops)
                {
                    Console.WriteLine(shop.Name);
                }
            }
        }

        static void PrintCapacities(double[] capacities)
        {
            Console.Write("Capacities: ");
            foreach (var cap in capacities)
            {
                Console.Write(" {0}l", cap);
            }
            Console.WriteLine();
        }

        static Shop GetShopFromFile(string path)
        {
            int lineCount = GetFileLineCount(path);

            var shop = new Shop(lineCount - 2);

            using (var reader = new StreamReader(path))
            {
                shop.Name = reader.ReadLine();
                shop.Address = reader.ReadLine();
                shop.Phone = reader.ReadLine();

                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');

                    var fridge = new Fridge()
                    {
                        Manufacturer = data[0],
                        Model = data[1],
                        EnergyClass = data[2],
                        Color = data[3],
                        Price = double.Parse(data[4]),
                        Capacity = double.Parse(data[5]),
                        InstallationType = data[6],
                        HasFreezer = bool.Parse(data[7]),
                        Width = double.Parse(data[8])
                    };

                    shop.AddFridge(fridge);
                }
            }

            return shop;
        }

        static int GetFileLineCount(string path)
        {
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();

                int lineCount = 0;

                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }

                return lineCount;
            }
        }
    }
}
