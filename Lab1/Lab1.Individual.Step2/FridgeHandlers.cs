using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Individual.Step2
{
    class FridgeHandlers
    {
        public List<Fridge> GetFridgesFromFile(string path) 
        {
            var fridges = new List<Fridge>();

            using (var reader = new StreamReader(path)) 
            {
                string line = null;

                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');

                    string manufacturer = values[0];
                    string model = values[1];
                    double capacity = Double.Parse(values[2]);
                    string energyClass = values[3];
                    string installationType = values[4];
                    string color = values[5];
                    bool hasFreezer = bool.Parse(values[6]);
                    double price = Double.Parse(values[7]);

                    var fridge = new Fridge()
                    {
                        Manufacturer = manufacturer,
                        Model = model,
                        Capacity = capacity,
                        EnergyClass = energyClass,
                        InstallationType = installationType,
                        Color = color,
                        HasFreezer = hasFreezer,
                        Price = price
                    };

                    fridges.Add(fridge);
                }
            }

            return fridges;
        }

        public void PrintToFile(List<Fridge> fridges, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Gamintojas;Modelis;Talpa;Energijos klase;Montavimo tipas;Spalva;Ar turi saldikli?;Kaina;Plotis");

                foreach (var fridge in fridges)
                {
                    writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                        fridge.Manufacturer,
                        fridge.Model,
                        fridge.Capacity,
                        fridge.EnergyClass,
                        fridge.InstallationType,
                        fridge.Color,
                        fridge.HasFreezer,
                        fridge.Price,
                        fridge.Width
                    );
                }
            }
        }

        public double[] GetCapacities(List<Fridge> fridges)
        {
            var capacities = fridges.Select(x => x.Capacity).Distinct().ToArray();

            return capacities;
        }

        public Fridge GetCheapestPlacableWithFreezerFridge(List<Fridge> fridges)
        {
            var fridge = fridges.Where(x => x.InstallationType == "Laisvai pastatomas" && x.HasFreezer).OrderBy(x => x.Price).First();

            return fridge;
        }

        public void PrintCheapest(Fridge fridge)
        {
            Console.WriteLine("{0} {1} {2} {3}", fridge.Manufacturer, fridge.Model, fridge.Capacity, fridge.Price);
        }

        public List<Fridge> FilteryByWidth(List<Fridge> fridges, int min, int max)
        {
            var filteredFridges = fridges.Where(x => x.Width >= min && x.Width <= max).ToList();

            return filteredFridges;
        }

        public void PrintArray(double[] array)
        {
            foreach(var item in array)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        public string GenerateRandomEnergyClass(Random rnd)
        {
            int num = rnd.Next(0, 5);
            char energyClassLetter = (char)('a' + num);

            string energyClass = energyClassLetter.ToString();

            int count = rnd.Next(0, 3);

            for (int i = 0; i < count; i++)
            {
                energyClass += "+";
            }

            return energyClass;
            
        }

        public void PrintFridges(List<Fridge> fridges) 
        {

            Console.WriteLine("Saldytuvai:");
            foreach (var fridge in fridges) 
            {
                Console.WriteLine(
                    @"Gamintojas: {0}, Modelis: {1}, Talpa: {2}l, Energijos klase: {3}, Montavimo tipas: {4}, Spalva: {5}, Ar turi saldikli? {6}, Kaina: {7}Eur",
                    fridge.Manufacturer, 
                    fridge.Model, 
                    fridge.Capacity, 
                    fridge.EnergyClass, 
                    fridge.InstallationType, 
                    fridge.Color,
                    fridge.HasFreezer ? "Taip" : "Ne", 
                    fridge.Price
                );
            }
        }
    }
}
