using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step1.Models
{
    public class House
    {
        public const int MaxStairwayCount = 20;
        public Stairway[] Stairways { get; set; }
        public int StairwayCount { get; private set; }

        public House()
        {
            Stairways = new Stairway[MaxStairwayCount];
        }

        public void Add(Stairway stairway)
        {
            Stairways[StairwayCount++] = stairway;
        }

        public Stairway Get(int index)
        {
            return Stairways[index];
        }
    }
}
