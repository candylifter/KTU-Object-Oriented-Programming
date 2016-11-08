using System.Collections;
using System.Collections.Generic;

namespace Lab4.Containers
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public List<Fridge> Fridges { get; set; }
        public List<MicrowaveOven> MicrowaveOvens { get; set; }
        public List<ElectricKettle> ElectricKettles { get; set; }

        public Shop()
        {
            Fridges = new List<Fridge>();
            MicrowaveOvens = new List<MicrowaveOven>();
            ElectricKettles =new List<ElectricKettle>();
        }

        public bool HasFridge(Fridge compareFridge)
        {
            //bool hasFridge = false;

            //foreach (Fridge fridge in Fridges)
            //{
            //    if (fridge.Equals(compareFridge))
            //    {
            //        hasFridge = true;
            //    }
            //}

            //return hasFridge;

            return Fridges.Contains(compareFridge);
        }

        public bool HasMicrowaveOven(MicrowaveOven MicrowaveOven)
        {
            return MicrowaveOvens.Contains(MicrowaveOven);
        }

        public bool HasElectricKettle(ElectricKettle electricKettle)
        {
            return ElectricKettles.Contains(electricKettle);
        }

        public List<Fridge> GetFridgesByWidthRange(double minWidth, double maxWidth)
        {
            var filteredFridges = new List<Fridge>();

            foreach (var fridge in Fridges)
            {
                if (fridge.Width >= minWidth && fridge.Width <= maxWidth)
                {
                    filteredFridges.Add(fridge);
                }
            }

            return filteredFridges;
        }

        public Fridge GetCheapestAPlusFridge()
        {
            var cheapestFridge = new Fridge();

            foreach (var fridge in Fridges)
            {
                if (fridge.EnergyClass == "A+")
                {
                    cheapestFridge = fridge;
                    break;
                }
            }

            if (cheapestFridge.Price == 0)
            {
                return null;
            }

            foreach (var fridge in Fridges)
            {
                if (fridge.EnergyClass == "A+" && fridge.Price < cheapestFridge.Price)
                {
                    cheapestFridge = fridge;
                }   
            }

            return cheapestFridge;
        }

        public MicrowaveOven GetCheapestAPlusMicrowaveOven()
        {
            var cheapestMicrowaveOven = new MicrowaveOven();

            foreach (var microwaveOven in MicrowaveOvens)
            {
                if (microwaveOven.EnergyClass == "A+")
                {
                    cheapestMicrowaveOven = microwaveOven;
                    break;
                }
            }

            if (cheapestMicrowaveOven.Price == 0)
            {
                return null;
            }

            foreach (var microwaveOven in MicrowaveOvens)
            {
                if (microwaveOven.EnergyClass == "A+" && microwaveOven.Price < cheapestMicrowaveOven.Price)
                {
                    cheapestMicrowaveOven = microwaveOven;
                }
            }

            return cheapestMicrowaveOven;
        }

        public ElectricKettle GetCheapestAPlusElectricKettle()
        {
            var cheapestElectricKettle = new ElectricKettle();

            foreach (var electricKettle in ElectricKettles)
            {
                if (electricKettle.EnergyClass == "A+")
                {
                    cheapestElectricKettle = electricKettle;
                    break;
                }
            }

            if (cheapestElectricKettle.Price == 0)
            {
                return null;
            }

            foreach (var electricKettle in ElectricKettles)
            {
                if (electricKettle.EnergyClass == "A+" && electricKettle.Price < cheapestElectricKettle.Price)
                {
                    cheapestElectricKettle = electricKettle;
                }
            }

            return cheapestElectricKettle;
        }

        public ArrayList GetDistinctFridgeColors()
        {
            var colors = new ArrayList();

            foreach (var fridge in Fridges)
            {
                var newColor = fridge.Color;

                bool hasColor = false;

                foreach (string color in colors)
                {
                    if (newColor == color)
                    {
                        hasColor = true;
                    }
                }

                if (!hasColor)
                {
                    colors.Add(newColor);
                }

            }

            return colors;
        }

        public ArrayList GetDistinctMicrowaveOvenColors()
        {
            var colors = new ArrayList();

            foreach (var microwaveOven in MicrowaveOvens)
            {
                var newColor = microwaveOven.Color;

                bool hasColor = false;

                foreach (string color in colors)
                {
                    if (newColor == color)
                    {
                        hasColor = true;
                    }
                }

                if (!hasColor)
                {
                    colors.Add(newColor);
                }

            }

            return colors;
        }

        public ArrayList GetDistinctElectricKettleColors()
        {
            var colors = new ArrayList();

            foreach (var electricKettle in ElectricKettles)
            {
                var newColor = electricKettle.Color;

                bool hasColor = false;

                foreach (string color in colors)
                {
                    if (newColor == color)
                    {
                        hasColor = true;
                    }
                }

                if (!hasColor)
                {
                    colors.Add(newColor);
                }

            }

            return colors;
        }
    }
}
