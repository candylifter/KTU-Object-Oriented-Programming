using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Individual.Step2.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public Student[] Students { get; set; }
        public int StudentCount { get; private set; }

        public Group(string groupName, int studentCount)
        {
            GroupName = groupName;
            Students = new Student[studentCount];
            StudentCount = 0;
        }

        public void Add(Student student)
        {
            Students[StudentCount++] = student;
        }
    }
}
