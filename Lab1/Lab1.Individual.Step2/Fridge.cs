using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Individual.Step2
{
    // gamintojas, modelis, talpa, energijos klasė, montavimo tipas, spalva, požymis „turi šaldiklį“, kaina
    class Fridge
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        public string EnergyClass { get; set; }
        public string InstallationType { get; set; }
        public string Color { get; set; }
        public bool HasFreezer { get; set; }
        public double Price { get; set; }
        public int Width { get; set; }

        public Fridge() { }


    }
}
