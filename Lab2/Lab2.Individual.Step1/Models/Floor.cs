using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step1.Models
{
    public class Floor
    {
        public const int MaxFlatCount = 3;
        private Flat[] Flats { get; set; }
        public int FlatCount { get; private set; }

        public Floor()
        {
            Flats = new Flat[MaxFlatCount];
        }

        public void Add(Flat flat)
        {
            Flats[FlatCount++] = flat;
        }

        public Flat Get(int index)
        {
            return Flats[index];
        }
    }
}
