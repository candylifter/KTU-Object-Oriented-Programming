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

        public double[] GetCapacities(List<Fridge> fridges)
        {
            var capacities = fridges.Select(x => x.Capacity).Distinct().ToArray();

            return capacities;
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
