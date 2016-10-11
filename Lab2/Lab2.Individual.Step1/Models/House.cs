using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step1.Models
{
    public class House
    {
        public const int MAX_STAIRWAY_COUNT = 20;
        public const int MAX_FLOOR_COUNT = 9;
        public const int MAX_FLOOR_FLAT_COUNT = 3;
        public const int MAX_FLAT_COUNT = MAX_FLOOR_FLAT_COUNT * MAX_FLOOR_COUNT * MAX_STAIRWAY_COUNT;

        public Flat[] Flats { get; private set; }
        public int FlatCount { get; private set; }

        public House(int flatCount)
        {
            if (flatCount <= MAX_FLAT_COUNT)
            {
                Flats = new Flat[flatCount];
                FlatCount = 0;
            }
            else
            {
                throw new Exception($"Cannot create a house with more than {MAX_FLAT_COUNT} flats");
            }
        }

        public House(Flat[] flats)
        {
            if (flats.Length <= MAX_FLAT_COUNT)
            {
                Flats = new Flat[flats.Length];
                FlatCount = 0;

                foreach (var flat in flats)
                {
                    AddFlat(flat);
                }
            }
            else
            {
                throw new Exception($"Cannot create a house with more than {MAX_FLAT_COUNT} flats");
            }
        }

        public void AddFlat(Flat flat)
        {
            int stairway = GetStairway(flat.Id);
            int floor = GetFloor(stairway, flat.Id);

            flat.Stairway = stairway;
            flat.Floor = floor;

            Flats[FlatCount++] = flat;
        }

        private int GetFloor(int stairway, int id)
        {

            int floor = id - 27 * (stairway - 1);

            floor = floor / 3 + 1;

            if (id % 3 == 0)
            {
                floor--;
            }

            return floor;
        }

        private int GetStairway(int id)
        {
            int stairway = (id / 27) + 1;

            // If it's the last room, assign it to previous floor
            if (id % 27 == 0)
            {
                stairway--;
            }

            return stairway;
        }

        public Flat[] FilterByRoomCount(int roomCount)
        {
            var filteredFlats = new Flat[FlatCount];

            for (int i = 0; i < FlatCount; i++)
            {
                if (Flats[i].RoomCount == roomCount)
                {
                    filteredFlats[i] = Flats[i];
                }
            }

            return RemoveDuplicates(filteredFlats);
        }

        public Flat[] FilterByFloorInterval(int minFloor, int maxFloor)
        {
            var filteredFlats = new Flat[FlatCount];

            for (int i = 0; i < FlatCount; i++)
            {
                if (Flats[i].Floor >= minFloor && Flats[i].Floor <= maxFloor)
                {
                    filteredFlats[i] = Flats[i];
                }
            }

            return RemoveDuplicates(filteredFlats);
        }

        public Flat[] FilterByPrice(double price)
        {
            var filteredFlats = new Flat[FlatCount];

            for (int i = 0; i < FlatCount; i++)
            {
                if (Flats[i].Price <= price)
                {
                    filteredFlats[i] = Flats[i];
                }
            }

            return RemoveDuplicates(filteredFlats);
        }

        private Flat[] RemoveDuplicates(Flat[] flats)
        {
            int nonNullFlatCount = 0;

            foreach (var flat in flats)
            {
                if (flat != null)
                {
                    nonNullFlatCount++;
                }
            }

            var filteredFlats = new Flat[nonNullFlatCount];
            var currentIndex = 0;

            foreach (var flat in flats)
            {
                if (flat != null)
                {
                    filteredFlats[currentIndex++] = flat;
                }
            }

            return filteredFlats;
        }
    }
}
