using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Step2
{
    class Program
    {
        public const int MaxNumberOfDogs = 50;
        private static int dogCount = 0;
        private static Dog[] dogs = new Dog[MaxNumberOfDogs];

        private static void ReadDogData(out Dog[] dogs, out int dogCount)
        {
            dogCount = 0;
            dogs = new Dog[MaxNumberOfDogs];

            using (StreamReader reader = new StreamReader(@"L1Data.csv"))
            {
                string line = null;

                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');
                    string name = values[0];
                    int chipId = int.Parse(values[1]);
                    double weight = Convert.ToDouble(values[2]);
                    int age = int.Parse(values[3]);
                    string breed = values[4];
                    string owner = values[5];
                    string phone = values[6];
                    DateTime vaccinationDate = DateTime.Parse(values[7]);
                    bool aggressive = bool.Parse(values[8]);

                    Dog dog = new Dog(name, chipId, weight, age, breed, owner, phone, vaccinationDate, aggressive);

                    dogs[dogCount++] = dog;
                }
            }
        }

        static void SaveReportToFile(Dog[] dogs, int count)
        {
            using (StreamWriter writer = new StreamWriter(@"L1Results.csv"))
            {
                writer.WriteLine("Vardas;MikroId;Svoris;Amžius;Savininkas;Tel. Nr.;Vakcinacija;Agresyvumas");

                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}",
                        dogs[i].Name,
                        dogs[i].ChipId,
                        dogs[i].Weight,
                        dogs[i].Age,
                        dogs[i].Owner,
                        dogs[i].Phone,
                        dogs[i].VaccinationDate,
                        dogs[i].Aggressive);
                }
            }
        }

        static void PrintDogsToConsole(Dog[] dogs, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(@"Vardas: {0}\nMikroschemos ID: {1}\nSvoris: {2}\nŪgis: {3}\nSavininka: {4}\nTelefonas: {5}\nVakcinacijos data: {6}\nAgrsyvus: {7}\n", 
                    dogs[i].Name, dogs[i].ChipId, dogs[i].Weight, dogs[i].Age, dogs[i].Owner, dogs[i].Phone, dogs[i].VaccinationDate, dogs[i].Aggressive);
            }
        }

        static void Main(string[] args)
        {
            Dog[] dogs;
            int dogCount;

            ReadDogData(out dogs, out dogCount);
            SaveReportToFile(dogs, dogCount);
        }
    }
}
