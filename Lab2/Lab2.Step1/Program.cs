using System;
using System.IO;
using System.Linq;

namespace Lab2.Step1
{
    class Program
    {
        public const int NumberOfBranches = 3;
        public const int MaxNumberOfBreeds = 10;

        static void Main(string[] args)
        {
            Branch[] branches = new Branch[3];

            branches[0] = new Branch("Kaunas");
            branches[1] = new Branch("Vilnius");
            branches[2] = new Branch("Šiauliai");

            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

            foreach (string path in filePaths)
            {
                ReadDogData(path, branches);
            }

            Console.WriteLine("Vilniuje užregistruoti šunys:");
            PrintDogsToConsole(branches[1].Dogs);

            int breedCount;
            string[] breeds;
            GetBreeds(branches[2].Dogs, out breeds, out breedCount);

            Console.WriteLine("Šiauliuose užregistruotos šunų veislės:");
            for (int i = 0; i < breedCount; i++)
            {
                Console.WriteLine(breeds[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Agresyviausi Kauno šunys: {0}", CountAggressive(branches[0].Dogs));

            Console.WriteLine("Populiariausia veislė Vilniuje: {0}", GetMostPopularBreed(branches[1].Dogs));

            Console.WriteLine();
            Console.WriteLine("Dvigubai užregistruoti šunys");

            Console.WriteLine();
            Console.WriteLine("Vilniuje ir Kaune:");

            DogsContainer doublePlacedDogs = GetDoublePlacedDogs(branches[1], branches[0]);
            PrintDogsToConsole(doublePlacedDogs);

            Console.WriteLine();
            Console.WriteLine("Sąrašas, iš Vilniaus registro pašalinus besikartojančius:");

            Console.WriteLine();
            RemoveDoublePlacedDogs(branches[1], doublePlacedDogs);
            PrintDogsToConsole(branches[1].Dogs);

            Console.WriteLine();
            Console.WriteLine("Surūšiuotas Kauno šunų sąrašas:");

            Console.WriteLine();
            branches[0].Dogs.SortDogs();
            PrintDogsToConsole(branches[0].Dogs);

            Console.Read();
        }

        /// <summary>
        /// Show dog data in the Console
        /// </summary>
        static void PrintDogsToConsole(DogsContainer dogs)
        {
            for (int i = 0; i < dogs.Count; i++)
            {
                Console.WriteLine("Nr {0}: {1}", (i+1), dogs.GetDog(i).ToString()); //metodo ToString() kviesti nebūtina, jis iškviečiamas automatiškai
            }
        }

        private static Branch GetBranchByTown(Branch[] branches, string town)
        {
            for (int i = 0; i < NumberOfBranches; i++)
            {
                if(branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            return null;
        }

        private static void ReadDogData(string file, Branch[] branches)
        {

            string town = null;

            using (StreamReader reader = new StreamReader(@file))
            {
                string line = null;
                line = reader.ReadLine();
                if (line != null)
                {
                    town = line;
                }
                Branch branch = GetBranchByTown(branches, town);
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(',');
                    string name = values[0];
                    int chipId = int.Parse(values[1]);
                    string breed = values[2];
                    string owner = values[3];
                    string phone = values[4];
                    DateTime vd = DateTime.Parse(values[5]);
                    bool aggressive = bool.Parse(values[6]);

                    Dog dog = new Dog(name, chipId, breed, owner, phone, vd, aggressive);
                    
                    branch.Dogs.AddDog(dog);

                }
            }

        }

        private static void GetBreeds(DogsContainer dogs, out string[] breeds, out int breedCount)
        {
            breeds = new string[MaxNumberOfBreeds];
            breedCount = 0;

            for (int i = 0; i < dogs.Count; i++)
            {
                if (!breeds.Contains(dogs.GetDog(i).Breed))
                {
                    breeds[breedCount++] = dogs.GetDog(i).Breed;
                }
            }
        }


        private static DogsContainer FilterByBreed(DogsContainer dogs,string breed)
        {
            DogsContainer filteredDogs = new DogsContainer(Branch.MaxNumberOfDogs);

            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs.GetDog(i).Breed == breed)
                {
                    filteredDogs.AddDog(dogs.GetDog(i));
                }
            }
            return filteredDogs;
        }

        private static int CountAggressive(DogsContainer dogs)
        {
            int counter = 0;
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs.GetDog(i).Aggressive)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static string GetMostPopularBreed(DogsContainer dogs)
        {
            String popular = "not found";
            int count = 0;

            int breedCount;
            string[] breeds;
            GetBreeds(dogs, out breeds, out breedCount);

            for (int i = 0; i < breedCount; i++)
            {
                DogsContainer filtered = FilterByBreed(dogs, breeds[i]);
                if (filtered.Count > count)
                {
                    popular = breeds[i];
                    count = breedCount;
                }
            }
            return popular;
        }

        //prieš realizuojant šį metodą, realizuoti Equals
        private static DogsContainer GetDoublePlacedDogs(Branch branch1, Branch branch2)
        {
            DogsContainer doublePlacedDogs = new DogsContainer(Branch.MaxNumberOfDogs);

            for (int i = 0; i < branch1.Dogs.Count; i++)
            {
                if (branch2.Dogs.Contains(branch1.Dogs.GetDog(i)))
                {
                    doublePlacedDogs.AddDog(branch1.Dogs.GetDog(i));
                }
            }

            return doublePlacedDogs;
        }

        private static void RemoveDoublePlacedDogs(Branch branch, DogsContainer doublePlacedDogs)
        {
            for (int i = 0; i < doublePlacedDogs.Count; i++)
            {
                branch.Dogs.RemoveDog(doublePlacedDogs.GetDog(i));
            }
        }

    }
}
