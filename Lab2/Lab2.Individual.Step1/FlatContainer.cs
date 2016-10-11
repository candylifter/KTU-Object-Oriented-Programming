using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step1
{
    public class FlatContainer
    {
        public Flat[] Flats { get; set; }

        public int FlatCount { get; private set; }

        public const int MaxFlatCountInFloor = 3;
        public const int MaxFloorCount = 9;
        public const int MaxStairwayCount = 2;

        public void Add(Flat flat)
        {
            
        }
    }
}
