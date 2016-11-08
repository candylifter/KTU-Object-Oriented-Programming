using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab4.Containers;

/*
 U4_22. Buitinės technikos parduotuvė. Turite informaciją apie skirtingose buitinės technikos parduotuvėse
esančius šaldytuvus. Keičiasi duomenų formatas. Pirmoje eilutėje pavadinimas, antroje – adresas, trečioje –
telefonas. Parduotuvėje be šaldytuvų galima įsigyti mikrobangų krosnelių ir elektrinis virdulys. Sukurkite
klasę „Prietaisas“ (laukai - gamintojas, modelis, energijos klasė, spalva, kaina), kurią paveldės “Šaldytuvas”
(papildomi laukai - talpa, montavimo tipas, požymis „turi šaldiklį“, aukštis, plotis, gylis),
“MikrobangųKrosnelė” (papildomi laukai – galingumas, programų skaičius) ir “ElektrinisVirdulys”
(papildomi laukai – galia, tūris).
 Raskite, kokių skirtingų spalvų šaldytuvus galima įsigyti, spalvų sąrašą atspausdinkite ekrane.
Raskite, kokių skirtingų spalvų elektrinius virdulius galima įsigyti, spalvų sąrašą
atspausdinkite ekrane.
 Raskite pigiausią A+ klasės šaldytuvą, mikrobangų krosnelę ir virdulį, kiekvieno jų visą
informaciją atspausdinkite ekrane.
 Sudarykite šaldytuvų, kurių plotis nuo 52 iki 56 cm, sąrašą, išrikiuokite pagal kainą ir
įrašykite visus duomenis apie šiuos šaldytuvus į failą „Tilps.csv“.
 Ar yra tokių buitinių prietaisų, kuriuos galima įsigyti visose parduotuvėje? Atspausdinkite jų
sąrašą faile „Visur.csv“. */

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = new[] {"Data1.csv", "Data2.csv", "Data3.csv"};
            var shops = GetShopsFromFiles(paths);

            var fridgeColors = GetDistinctFridgeColors(shops);
            var microwaveOvenColors = GetDistinctMicrowaveOvenColors(shops);
            var electricKettleColors = GetDistinctElectricKettleColors(shops);

            Console.WriteLine("Fridge distinct colors:");
            PrintColorsToConsole(fridgeColors);
            Console.WriteLine("\nMicrowave oven distinct colors:");
            PrintColorsToConsole(microwaveOvenColors);
            Console.WriteLine("\nElectric kettle distinct colors:");
            PrintColorsToConsole(electricKettleColors);

            var cheapestFridge = GetCheapestAPlusFridge(shops);
            var cheapestMicrowaveOven = GetCheapestAPlusMicrowaveOven(shops);
            var cheapestElectricKettle = GetCheapestAPlusElectricKettle(shops);

            Console.WriteLine("\nCheapest A+ fridge:");
            PrintFridgeToConsole(cheapestFridge);
            Console.WriteLine("\nCheapest A+ microwave oven:");
            PrintMicrowaveOvenToConsole(cheapestMicrowaveOven);
            Console.WriteLine("\nCheapest A+ electric kettle:");
            PrintElectricKettleToConsole(cheapestElectricKettle);

            var filteredByWidthFridges = GetFridgesByWidthRange(shops, 52, 56);
            var sortedFridges = SortFridgesByPrice(filteredByWidthFridges);

            PrintFridgesToFile(sortedFridges, "../../Tilps.csv", false);

            var duplicatesShop = GetDuplicatesShop(shops);
            PrintDuplicatesToFile(duplicatesShop, "../../Visur.csv");

            Console.ReadKey();
        }

        static void PrintDuplicatesToFile(Shop shop, string path)
        {
            PrintFridgesToFile(shop.Fridges, path, false);
            PrintMicrowaveOvensToFile(shop.MicrowaveOvens, path, true);
            PrintElectricKettlesToFile(shop.ElectricKettles, path, true);
        }

        static void PrintElectricKettlesToFile(List<ElectricKettle> electricKettles, string path, bool append)
        {
            using (var writer = new StreamWriter(path, append))
            {
                foreach (var electricKettle in electricKettles)
                {
                    writer.WriteLine(
                        "{0};{1};{2};{3};{4};{5};{6}",
                        electricKettle.Manufacturer, electricKettle.Model, electricKettle.EnergyClass, electricKettle.Color, electricKettle.Price,
                        electricKettle.Power, electricKettle.Capacity
                    );
                }
            }
        }

        static void PrintMicrowaveOvensToFile(List<MicrowaveOven> microwaveOvens, string path, bool append)
        {
            using (var writer = new StreamWriter(path, append))
            {
                foreach (var microwaveOven in microwaveOvens)
                {
                    writer.WriteLine(
                        "{0};{1};{2};{3};{4};{5};{6}",
                        microwaveOven.Manufacturer, microwaveOven.Model, microwaveOven.EnergyClass, microwaveOven.Color, microwaveOven.Price,
                        microwaveOven.Power, microwaveOven.ProgramCount
                    );
                }
            }
        }

        static void PrintFridgesToFile(List<Fridge> fridges, string path, bool append)
        {
            using (var writer = new StreamWriter(path, append))
            {
                foreach (var fridge in fridges)
                {
                    writer.WriteLine(
                        "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", 
                        fridge.Manufacturer, fridge.Model, fridge.EnergyClass, fridge.Color, fridge.Price,
                        fridge.Capacity, fridge.InstallationType, fridge.HasFreezer, fridge.Height, 
                        fridge.Width, fridge.Depth
                    );
                }
            }
        }

        static void PrintFridgeToConsole(Fridge fridge)
        {
            Console.WriteLine(fridge != null ? fridge.ToString() : "No fridge found!");
        }

        static void PrintMicrowaveOvenToConsole(MicrowaveOven microwaveOven)
        {
            Console.WriteLine(microwaveOven != null ? microwaveOven.ToString() : "No microwave oven found!");
        }

        static void PrintElectricKettleToConsole(ElectricKettle electricKettle)
        {
            Console.WriteLine(electricKettle != null ? electricKettle.ToString() : "No electric kettle found!");
        }

        static void PrintColorsToConsole(ArrayList colors)
        {
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
        }

        static List<Fridge> SortFridgesByPrice(List<Fridge> fridges)
        {
            var sortedFridges = fridges.OrderBy(fridge => fridge.Price).ToList();

            return sortedFridges;
        }

        static Shop GetDuplicatesShop(List<Shop> shops)
        {
            var duplicatesShop = new Shop();

            // Taking list only from first item because it's unnecessary to loop through all items
            var fridges = shops[0].Fridges;

            foreach (var fridge in fridges)
            {
                if (ShopsHaveFridge(shops, fridge) && !duplicatesShop.HasFridge(fridge))
                {
                    duplicatesShop.Fridges.Add(fridge);
                }
            }

            var microwaveOvens = shops[0].MicrowaveOvens;

            foreach (var microwaveOven in microwaveOvens)
            {
                if (ShopsHaveMicrowaveOven(shops, microwaveOven) && !duplicatesShop.HasMicrowaveOven(microwaveOven))
                {
                    duplicatesShop.MicrowaveOvens.Add(microwaveOven);
                }
            }

            var electricKettles = shops[0].ElectricKettles;

            foreach (var electricKettle in electricKettles)
            {
                if (ShopsHaveElectricKettle(shops, electricKettle) && !duplicatesShop.HasElectricKettle(electricKettle))
                {
                    duplicatesShop.ElectricKettles.Add(electricKettle);
                }
            }

            return duplicatesShop;
        }

        static bool ShopsHaveElectricKettle(List<Shop> shops, ElectricKettle electricKettle)
        {
            bool shopsContainElectricKettle = true;

            foreach (var shop in shops)
            {
                if (!shop.HasElectricKettle(electricKettle))
                {
                    shopsContainElectricKettle = false;
                }
            }

            return shopsContainElectricKettle;
        }

        static bool ShopsHaveMicrowaveOven(List<Shop> shops, MicrowaveOven microwaveOven)
        {
            bool shopsContainMicrowaveOven = true;

            foreach (var shop in shops)
            {
                if (!shop.HasMicrowaveOven(microwaveOven))
                {
                    shopsContainMicrowaveOven = false;
                }
            }

            return shopsContainMicrowaveOven;
        }

        static bool ShopsHaveFridge(List<Shop> shops, Fridge fridge)
        {
            bool shopsContainFridge = true;

            foreach (var shop in shops)
            {
                if (!shop.HasFridge(fridge))
                {
                    shopsContainFridge = false;
                }
            }

            return shopsContainFridge;
        }

        static List<Fridge> GetFridgesByWidthRange(List<Shop> shops, double minWidth, double maxWidth)
        {
            var filteredFridges = new List<Fridge>();

            foreach (var shop in shops)
            {
                var fridges = shop.GetFridgesByWidthRange(minWidth, maxWidth);

                foreach (var fridge in fridges)
                {
                    if (!filteredFridges.Contains(fridge))
                    {
                        filteredFridges.Add(fridge);
                    }
                }
            }

            return filteredFridges;
        }

        static Fridge GetCheapestAPlusFridge(List<Shop> shops)
        {
            var cheapestFridge = new Fridge();

            foreach (var shop in shops)
            {
                var fridge = shop.GetCheapestAPlusFridge();

                if (fridge != null)
                {
                    if (cheapestFridge.Price == 0)
                    {
                        cheapestFridge = fridge;
                    }
                    else if (fridge.Price < cheapestFridge.Price)
                    {
                        cheapestFridge = fridge;
                    }
                } 
            }

            return cheapestFridge.Price == 0 ? null : cheapestFridge;
        }

        static MicrowaveOven GetCheapestAPlusMicrowaveOven(List<Shop> shops)
        {
            var cheapestMicrowaveOven = new MicrowaveOven();

            foreach (var shop in shops)
            {
                var microwaveOven = shop.GetCheapestAPlusMicrowaveOven();

                if (microwaveOven != null)
                {
                    if (cheapestMicrowaveOven.Price == 0)
                    {
                        cheapestMicrowaveOven = microwaveOven;
                    }
                    else if (microwaveOven.Price < cheapestMicrowaveOven.Price)
                    {
                        cheapestMicrowaveOven = microwaveOven;
                    }
                }
            }

            return cheapestMicrowaveOven.Price == 0 ? null : cheapestMicrowaveOven;
        }

        static ElectricKettle GetCheapestAPlusElectricKettle(List<Shop> shops)
        {
            var cheapestElectricKettle = new ElectricKettle();

            foreach (var shop in shops)
            {
                var electricKettle = shop.GetCheapestAPlusElectricKettle();

                if (electricKettle != null)
                {
                    if (cheapestElectricKettle.Price == 0)
                    {
                        cheapestElectricKettle = electricKettle;
                    }
                    else if (electricKettle.Price < cheapestElectricKettle.Price)
                    {
                        cheapestElectricKettle = electricKettle;
                    }
                }
            }

            return cheapestElectricKettle.Price == 0 ? null : cheapestElectricKettle;
        }

        static ArrayList GetDistinctFridgeColors(List<Shop> shops)
        {
            var distinctColors = new ArrayList();

            foreach (var shop in shops)
            {
                var colors = shop.GetDistinctFridgeColors();

                foreach (string color in colors)
                {
                    if (!distinctColors.Contains(color))
                    {
                        distinctColors.Add(color);
                    }
                }
            }

            return distinctColors;
        }

        static ArrayList GetDistinctMicrowaveOvenColors(List<Shop> shops)
        {
            var distinctColors = new ArrayList();

            foreach (var shop in shops)
            {
                var colors = shop.GetDistinctMicrowaveOvenColors();

                foreach (string color in colors)
                {
                    if (!distinctColors.Contains(color))
                    {
                        distinctColors.Add(color);
                    }
                }
            }

            return distinctColors;
        }

        static ArrayList GetDistinctElectricKettleColors(List<Shop> shops)
        {
            var distinctColors = new ArrayList();

            foreach (var shop in shops)
            {
                var colors = shop.GetDistinctElectricKettleColors();

                foreach (string color in colors)
                {
                    if (!distinctColors.Contains(color))
                    {
                        distinctColors.Add(color);
                    }
                }
            }

            return distinctColors;
        }

        static List<Shop> GetShopsFromFiles(string[] paths)
        {
            var shops = new List<Shop>();

            foreach (var path in paths)
            {
                var shop = GetShopFromFile(path);

                shops.Add(shop);
            }

            return shops;
        }

        static Shop GetShopFromFile(string path)
        {
            var shop = new Shop();

            using (var reader = new StreamReader(path))
            {
                shop.Name = reader.ReadLine();
                shop.Address = reader.ReadLine();
                shop.Phone = reader.ReadLine();

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(';');

                    if (IsFridge(data))
                    {
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
                            Height = double.Parse(data[8]),
                            Width = double.Parse(data[9]),
                            Depth = double.Parse(data[10])
                        };

                        shop.Fridges.Add(fridge);
                    }

                    if (IsMicrowaveOven(data))
                    {
                        var microwaveOven = new MicrowaveOven()
                        {
                            Manufacturer = data[0],
                            Model = data[1],
                            EnergyClass = data[2],
                            Color = data[3],
                            Price = double.Parse(data[4]),
                            Power = double.Parse(data[5]),
                            ProgramCount = int.Parse(data[6])
                        };

                        shop.MicrowaveOvens.Add(microwaveOven);
                    }

                    if (IsElectricKettle(data))
                    {
                        var electricKettle = new ElectricKettle()
                        {
                            Manufacturer = data[0],
                            Model = data[1],
                            EnergyClass = data[2],
                            Color = data[3],
                            Price = double.Parse(data[4]),
                            Power = double.Parse(data[5]),
                            Capacity = double.Parse(data[6])
                        };

                        shop.ElectricKettles.Add(electricKettle);
                    }
                }
            }


            return shop;
        }

        static bool IsFridge(string[] data)
        {
            return data.Length == 11;
        }

        static bool IsMicrowaveOven(string[] data)
        {
            if (data.Length == 7)
            {
                return data[6].All(char.IsDigit);
            }

            return false;
        }

        static bool IsElectricKettle(string[] data)
        {
            if (data.Length == 7)
            {
                return !data[6].All(char.IsDigit);
            }

            return false;
        }
    }
}
