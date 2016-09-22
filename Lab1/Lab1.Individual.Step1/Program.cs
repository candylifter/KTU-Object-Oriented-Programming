using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Individual.Step1
{
    class Program
    {
        private static List<Tourist> _tourists;
        private static double _gatheredMoney = 0;
        private static double _highestPayment = 0;
        private static List<Tourist> _mostGenorousTourists;

        public static List<Tourist> ReadTourists ()
        {
            _tourists = new List<Tourist>();

            using (StreamReader reader  = new StreamReader(@"L1Data.csv"))
            {
                string line = null;

                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');

                    string name = values[0];
                    string lastName = values[1];
                    double money = double.Parse(values[2]);

                    Tourist tourist = new Tourist(name, lastName, money);

                    _tourists.Add(tourist);
                }
            }


            return _tourists;
        }

        static void PrintTourists(List<Tourist> tourists)
        {
            Console.WriteLine("Turistai:");

            foreach (var tourist in tourists)
            {
                Console.WriteLine("Vardas: {0}, Pavardė: {1}, Turimi pinigai: {2}", tourist.Name, tourist.LastName, tourist.Money);
            }
        }

        static List<Tourist> GatherMoney(List<Tourist> tourists)
        {
            foreach(var tourist in tourists)
            {
                double payment = tourist.PayQuarter();

                _gatheredMoney += payment;

                if (payment > _highestPayment)
                {
                    _highestPayment = payment;
                    //_mostGenorousTourist = tourist;
                    _mostGenorousTourists = new List<Tourist>();
                    _mostGenorousTourists.Add(tourist);

                }
                else if (payment == _highestPayment)
                {
                    _mostGenorousTourists.Add(tourist);
                }

            }

            return tourists;
        }



        static void Main(string[] args)
        {

            _tourists = ReadTourists();

            PrintTourists(_tourists);

            Console.WriteLine("\nTuristai sumoka ketvirtadalį savo pinigų\n");

            _tourists = GatherMoney(_tourists);

            PrintTourists(_tourists);

            Console.WriteLine("\nViso surinkta: {0}", _gatheredMoney);
            Console.WriteLine("Daugiausiai buvo sumokėta: {0}", _highestPayment);

            foreach (var tourist in _mostGenorousTourists)
            {
                Console.WriteLine("Dosniausias turistas: {0} {1}", tourist.Name, tourist.LastName);
            }


            Console.ReadKey();

        }
    }
}
