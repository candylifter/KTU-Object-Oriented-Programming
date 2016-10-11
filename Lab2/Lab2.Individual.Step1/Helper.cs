using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Individual.Step1.Models;

namespace Lab2.Individual.Step1
{
    public class Helper
    {
        public Flat[] GetFlatsFromFile(string path)
        {
            int lineCount = GetLineCount(path);
            var flats = new Flat[lineCount];

            using (var reader = new StreamReader(path))
            {
                string line;
                int currentIndex = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    var flat = new Flat()
                    {
                        Id = int.Parse(data[0]),
                        Area = double.Parse(data[1]),
                        RoomCount = int.Parse(data[2]),
                        Price = double.Parse(data[3]),
                        Phone = data[4]
                    };

                    flats[currentIndex++] = flat;
                }
            }

            return flats;
        }

        public int GetLineCount(string path)
        {
            using (var reader = new StreamReader(path))
            {
                int lineCount = 0;

                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }

                return lineCount;
            }
        }
    }
}
