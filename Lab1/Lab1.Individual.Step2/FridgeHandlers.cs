using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lab1.Individual.Step2
{
    class FridgeHandlers
    {
        /// <summary>
        /// Takes path, reads from .csv file and returns a List
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        ///     This method return a List
        /// </returns>
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
                    double width = Double.Parse(values[8]);

                    var fridge = new Fridge()
                    {
                        Manufacturer = manufacturer,
                        Model = model,
                        Capacity = capacity,
                        EnergyClass = energyClass,
                        InstallationType = installationType,
                        Color = color,
                        HasFreezer = hasFreezer,
                        Price = price,
                        Width = width
                    };

                    fridges.Add(fridge);
                }
            }

            return fridges;
        }


        /// <summary>
        /// Prints List to file
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="path"></param>
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

        /// <summary>
        /// Gets an array of capacities fro Fridge List
        /// </summary>
        /// <param name="fridges"></param>
        /// <returns>
        ///     This method returns a List
        /// </returns>
        public double[] GetCapacities(List<Fridge> fridges)
        {
            var fridgesArray = fridges.ToArray();
            ArrayList capacitiesList = new ArrayList();

            foreach (var fridge in fridges) {
                if (!capacitiesList.Contains(fridge.Capacity))
                {
                    capacitiesList.Add(fridge.Capacity);
                }
            }

            double[] capacities = (double[])capacitiesList.ToArray(typeof(double));

            return capacities;
        }

        /// <summary>
        /// Gets the first cheapest, placeable with freezer fridge 
        /// </summary>
        /// <param name="fridges"></param>
        /// <returns>
        ///     This method returns Fridge object
        /// </returns>
        public Fridge GetCheapestPlacableWithFreezerFridge(List<Fridge> fridges)
        {
            var fridgesArray = fridges.ToArray();
            Fridge cheapestFridge = fridgesArray[0];

            for (int i = 0; i < fridgesArray.Length; i++) 
            {
                if (fridgesArray[i].HasFreezer && fridgesArray[i].InstallationType == "Laisvai pastatomas" && fridgesArray[i].Price < cheapestFridge.Price)
                {
                    cheapestFridge = fridgesArray[i];
                    // TODO: add filter for hasFreezer and InstallationType
                }            
            }

            return cheapestFridge;

            //return fridges.Where(x => x.InstallationType == "Laisvai pastatomas" && x.HasFreezer).OrderBy(x => x.Price).FirstOrDefault();

        }

        /// <summary>
        /// Prints cheapest fridge to console
        /// </summary>
        /// <param name="fridge"></param>
        public void PrintCheapest(Fridge fridge)
        {
            Console.WriteLine("{0} {1} {2}l {3}Eur", fridge.Manufacturer, fridge.Model, fridge.Capacity, fridge.Price);
        }

        /// <summary>
        /// Filters Fridge List by minimum and maximum width
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>
        ///     This method returns a List
        /// </returns>
        public List<Fridge> FilterByWidth(List<Fridge> fridges, int min, int max)
        {
            var fridgesArray = fridges.ToArray();
            List<Fridge> filteredFridges = new List<Fridge>();

            for (int i = 0; i < fridgesArray.Length; i++)
            {
                if (fridgesArray[i].Width >= min && fridgesArray[i].Width <= max)
                {
                    filteredFridges.Add(fridgesArray[i]);
                }
            }

            //var filteredFridges = fridges.Where(x => x.Width >= min && x.Width <= max).ToList();

            return filteredFridges;
        }

        /// <summary>
        /// Prints given array of doubles
        /// </summary>
        /// <param name="array"></param>
        public void PrintArray(double[] array)
        {
            foreach(var item in array)
            {
                Console.Write("{0}l ", item);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Prints List of fridges to console
        /// </summary>
        /// <param name="fridges"></param>
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
                    fridge.Price,
                    fridge.Width
                );
            }
        }
    }
}
