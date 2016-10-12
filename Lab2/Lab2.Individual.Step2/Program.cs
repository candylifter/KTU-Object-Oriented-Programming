using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Individual.Step2.Models;

namespace Lab2.Individual.Step2
{
    class Program
    {
        private static Helper _helper = new Helper("../../ivertinimai.csv");

        static void Main(string[] args)
        {
            string facultyName = _helper.GetFacultyName();
            var students = _helper.GetStudentsFromFile();

            var student = new Student()
            {
                FirstName = "Petras"
            };

            var group = new Group("IF-6/2", 3);
            group.Add(student);

            Console.ReadKey();

        }
    }
}
