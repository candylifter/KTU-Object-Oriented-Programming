using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Individual.Step2.Models;

namespace Lab2.Individual.Step2
{
    class Helper
    {
        private string Path { get; set; }

        public Helper(string path)
        {
            Path = path;
        }

        public string GetFacultyName()
        {
            using (var reader = new StreamReader(Path))
            {
                string facultyName = reader.ReadLine();
                return facultyName;
            }
        }

        public Student[] GetStudentsFromFile()
        {
            using (var reader = new StreamReader(Path))
            {
                reader.ReadLine();
                string line = null;

                var students = new Student[54]; 

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');

                    var student = new Student()
                    {
                        LastName = data[0],
                        FirstName = data[1],
                        Grades = Array.ConvertAll(data[3].Split(','), int.Parse)
                    };
                }
            }

            return new Student[5];
        }

        public int GetStudentCount()
        {
            using (var reader = new StreamReader(Path))
            {
                reader.ReadLine();

                int studentCount = 0;

                while (reader.ReadLine() != null)
                {
                    studentCount++;
                }

                return studentCount;
            }
        }
    }
}
