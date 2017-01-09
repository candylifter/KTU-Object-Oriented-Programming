using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step3
{
    public class City
    {
        public Shop[] Shops { get; private set; }
        public int ShopCount { get; private set; }

        public City(int shopCount)
        {
            Shops = new Shop[shopCount];
            shopCount = 0;
        }

        public void AddShop(Shop shop)
        {
            Shops[ShopCount++] = shop;
        }

        public Fridge[] GetFridgesInAllShops()
        {
            int fridgeCount = 0;
            foreach (var shop in Shops) { fridgeCount += shop.FridgeCount; }

            var fridges = new Fridge[fridgeCount];
            var fridgesIndex = 0;

            // Get all fridges
            foreach (var shop in Shops)
            {
                foreach (var fridge in shop.Fridges)
                {
                    fridges[fridgesIndex++] = fridge;
                }
            }

            // Remove dupes
            var dedupedFridges = new Fridge[fridgesIndex];
            var dedupedFridgesIndex = 0;

            for (int i = 0; i < fridgesIndex; i++)
            {
                if (!dedupedFridges.Contains(fridges[i]))
                {
                    dedupedFridges[dedupedFridgesIndex++] = fridges[i];
                }
            }

            var filteredFridges = new Fridge[dedupedFridgesIndex];
            int filteredFridgesIndex = 0;

            foreach (var fridge in dedupedFridges)
            {
                bool isEverywhere = true;

                foreach (var shop in Shops)
                {
                    if (!shop.Fridges.Contains(fridge))
                    {
                        isEverywhere = false;
                        break;
                    }
                }

                if (isEverywhere)
                {
                    filteredFridges[filteredFridgesIndex++] = fridge;
                }
            }

            var denulledFridges = new Fridge[filteredFridgesIndex];
            int index = 0;

            for (int i = 0; i < filteredFridgesIndex; i++)
            {
                denulledFridges[index++] = filteredFridges[i];
            }

            return denulledFridges;
        }

        public Fridge[] GetFridgesByWidthRange(double minWidth, double maxWidth)
        {
            int fridgeCount = 0;
            foreach (var shop in Shops) { fridgeCount += shop.FridgeCount; }

            var fridges = new Fridge[fridgeCount];
            int fridgesIndex = 0;

            foreach (var shop in Shops)
            {
                var rangeFridges = shop.GetFridgesByWidthRange(minWidth, maxWidth);

                if (!Object.Equals(rangeFridges, null))
                {
                    foreach (var fridge in rangeFridges)
                    {
                        fridges[fridgesIndex++] = fridge;
                    }
                }
            }

            if (fridgesIndex == 0) return null;

            // Remove dupes
            var dedupedFridges = new Fridge[fridgesIndex];
            var dedupedFridgesIndex = 0;

            for (int i = 0; i < fridgesIndex; i++)
            {
                if (!dedupedFridges.Contains(fridges[i]))
                {
                    dedupedFridges[dedupedFridgesIndex++] = fridges[i];
                }
            }

            // Remove nulls
            var filteredFridges = new Fridge[dedupedFridgesIndex];
            int index = 0;

            for (int i = 0; i < dedupedFridgesIndex; i++)
            {
                filteredFridges[index++] = dedupedFridges[i];
            }

            return filteredFridges;
        }

        public Shop[] FilterShopsByFridge(Fridge fridge)
        {
            var shops = new Shop[ShopCount];
            int shopIndex = 0;

            foreach (var shop in Shops)
            {
                if (shop.HasFridge(fridge))
                {
                    shops[shopIndex++] = shop;
                }
            }

            if (shopIndex == 0)
            {
                return null;
            }

            var filteredShops = new Shop[shopIndex];
            int filteredShopsIndex = 0;

            for (int i = 0; i < shopIndex; i++)
            {
                filteredShops[filteredShopsIndex++] = shops[i];
            }

            return filteredShops;
        }

        public Fridge GetCheapestFridge()
        {

            var cheapestFridge = Shops[0].GetCheapestFridge();

            foreach (var shop in Shops)
            {
                var currentCheapestFridge = shop.GetCheapestFridge();

                if (!Object.Equals(currentCheapestFridge, null))
                {
                    if (Object.Equals(cheapestFridge, null))
                    {
                        cheapestFridge = currentCheapestFridge;
                    }

                    if (currentCheapestFridge < cheapestFridge)
                    {
                        cheapestFridge = currentCheapestFridge;
                    }
                }
            }

            return cheapestFridge;
        }

        public double[] FilterFridgesByDistinctCapacities()
        {
            int fridgeCount = 0;

            foreach (var shop in Shops)
            {
                fridgeCount += shop.FridgeCount;
            }

            var capacities = new double[fridgeCount];
            int capIndex = 0;

            foreach (var shop in Shops)
            {
                foreach (var fridge in shop.Fridges)
                {
                    capacities[capIndex++] = fridge.Capacity;
                }
            }

            var deduped = new double[capIndex];
            int dedupedIndex = 0;

            for (int i = 0; i < capIndex; i++)
            {
                if (!deduped.Contains(capacities[i]))
                {
                    deduped[dedupedIndex++] = capacities[i];
                }
            }

            // Remove nulls
            var filtered = new double[dedupedIndex];
            int index = 0;

            for (int i = 0; i < dedupedIndex; i++)
            {
                filtered[index++] = deduped[i];
            }

            return filtered;
        }
    }
}
