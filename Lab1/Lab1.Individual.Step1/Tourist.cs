using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Individual.Step1
{
    class Tourist
    {
        public string Name { get; set;}
        public string LastName { get; set; }
        public double Money { get; set; }

        public double PayQuarter ()
        {
            double payment = Money / 4;
            Money = Money - payment;

            return payment;
        }

        public Tourist() { }

        public Tourist(string name, string lastName, double money)
        {
            Name = name;
            LastName = lastName;
            Money = money;

        }
    }
}
