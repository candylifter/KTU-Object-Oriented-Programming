using System;

namespace Lab2.Individual.Step3
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Fridge[] Fridges { get; private set; }
        public int FridgeCount { get; private set; }

        public Shop(int fridgeCount)
        {
            Fridges = new Fridge[fridgeCount];
            FridgeCount = 0;
        }

        public void AddFridge(Fridge fridge)
        {
            Fridges[FridgeCount++] = fridge;
        }

        public bool HasFridge(Fridge fridge)
        {
            bool hasFridge = false;

            foreach (var f in Fridges)
            {
                if (f.Equals(fridge))
                {
                    hasFridge = true;
                }
            }

            return hasFridge;
        }

        public Fridge[] GetFridgesByWidthRange(double minWidth, double maxWidth)
        {
            var fridges = new Fridge[FridgeCount];
            int fridgesIndex = 0;

            foreach (var fridge in Fridges)
            {
                if (fridge.Width >= minWidth && fridge.Width <= maxWidth)
                {
                    fridges[fridgesIndex++] = fridge;
                }
            }

            if (fridgesIndex == 0) return null;

            // Remove nulls

            var filteredFridges = new Fridge[fridgesIndex];
            int index = 0;

            for (int i = 0; i < fridgesIndex; i++)
            {
                filteredFridges[index++] = fridges[i];
            }

            return filteredFridges;
        }

        public Fridge GetCheapestFridge()
        {
            // Filter by freezer

            var f = new Fridge[FridgeCount];
            int fIndex = 0;

            foreach (var fridge in Fridges)
            {
                if (fridge.HasFreezer && fridge.InstallationType == "Placeable")
                {
                    f[fIndex++] = fridge;
                }
            }

            if (fIndex == 0)
            {
                return null;
            }

            // Remove nulls
            var filteredFridges = new Fridge[fIndex];
            int filterenedFridgesIndex = 0;

            for (int i = 0; i < fIndex; i++)
            {
                var fridge = f[i];
                filteredFridges[filterenedFridgesIndex++] = fridge;
            }


            var cheapestFridgeIndex = 0;

            for (int i = 0; i < filteredFridges.Length; i++)
            {
                var fridge = filteredFridges[i];
                if (fridge < filteredFridges[cheapestFridgeIndex])
                {
                    cheapestFridgeIndex = i;
                }
            }

            return filteredFridges[cheapestFridgeIndex];
        }
    }
}
