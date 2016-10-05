using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step1.Models
{
    public class Stairway
    {
        public const int MaxFloorCount = 9;
        public Floor[] Floors { get; set; }
        public int FloorCount { get; private set; }

        public Stairway()
        {
            Floors = new Floor[MaxFloorCount];
        }

        public void Add(Floor floor)
        {
            Floors[FloorCount++] = floor;
        }

        public Floor Get(int index)
        {
            return Floors[index];
        }
    }
}
