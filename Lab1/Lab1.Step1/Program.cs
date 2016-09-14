using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog(
                "Bimas", 
                1234, 
                24, 
                5,
                "taksas",
                "Antanas Kavaliauskas",
                "+37061485555",
                new DateTime(2015, 7, 24),
                true
                );

            Dog dog2 = new Dog() 
            {
                Name = "Reksas",
                ChipId = 1235,
                Weight = 20,
                Age = 8,
                Breed = "Buldogas",
                Owner = "Petras Petrauskas",
                Phone = "+37061485556",
                VaccinationDate = new DateTime(2015, 8, 24),
                Aggressive = true
            };

            var dog3 = new
            {
                Name = "Haris",
                ChipId = 1236,
                Weight = 10,
                Age = 3,
                Breed = "Taksas",
                Owner = "Simas Simaitis",
                Phone = "+37045785445",
                VaccinationData = new DateTime(2016, 8, 4),
                Aggressive = true
            };

            Console.WriteLine("{0, -10} {1, 5:d} {2, 5:f} {3, 5:d} {4, -16} {5, -12} {6, 8:Y} {7}", 
                dog.Name, dog.ChipId, dog.Weight, dog.Age, dog.Owner, dog.Phone, dog.VaccinationDate, dog.Aggressive);

            Console.ReadKey();
        }
    }
}
