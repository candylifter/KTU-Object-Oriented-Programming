using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Individual.Step1.Models;
using System.IO;

namespace Lab2.Individual.Step1
{
    /*
     * Pateikiamas 9 aukštų namo parduodamų butų sąrašas. Kiekviename laiptinės aukšte yra po 3 butus. Namo
        laiptinių skaičius yra mažesnis, nei 20. Duomenys tokie: buto numeris, bendras plotas, kambarių skaičius,
        pardavimo kaina, telefono Nr. Suraskite butus, kurie turi nurodytą kambarių skaičių, yra nurodytame aukšte
        ir kurių kaina neviršija nurodytos kainos, ir juos surašykite į tinkamų butų konteinerį. Aukšto numeris
        nurodomas intervalu [nuo, iki]. Aukšto numeris išskaičiuojamas iš buto numerio. Butų numeriai yra iš aibės
        [1, laiptinių skaičius daugintas iš 27].    */

    class Program
    {
        private static Helper _helper = new Helper();

        static void Main(string[] args)
        {
            var flats = _helper.GetFlatsFromFile("../../Flats-540.csv");

            var house = new House(flats);

            Console.WriteLine("How many rooms should your flat have?");
            int roomCount = int.Parse(Console.ReadLine());

            Console.WriteLine("On which floor should your flat be? (Minimum)");
            int minFloor = int.Parse(Console.ReadLine());

            Console.WriteLine("On which floor should your flat be? (Maximum)");
            int maxFloor = int.Parse(Console.ReadLine());

            Console.WriteLine("Maximum price you are willing to pay for your flat:");
            double maxPrice = double.Parse(Console.ReadLine());


            var flatsByRoomCount = house.FilterByRoomCount(roomCount);
            var houseByRoomCount = new House(flatsByRoomCount);

            var flatsByRoomCountAndFloor = houseByRoomCount.FilterByFloorInterval(minFloor, maxFloor);
            var houseByRoomCountAndFloor = new House(flatsByRoomCountAndFloor);

            var flatsByFloorAndRoomCountAndPrice = houseByRoomCountAndFloor.FilterByPrice(maxPrice);
            var houseByRoomCountAndFloorAndPrice = new House(flatsByFloorAndRoomCountAndPrice);

            Console.ReadKey();
        }
    }
}
