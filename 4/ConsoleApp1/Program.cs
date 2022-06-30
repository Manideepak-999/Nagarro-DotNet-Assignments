using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entry Required: Press m for mobile equipments and i for immobile equipments");
            string input = Console.ReadLine();
            if (input == "m")
            {
                var eqm = new Mobile();
                Console.WriteLine("Name of Equipment : ");
                eqm.Name = Console.ReadLine();
                Console.WriteLine("Description of Equipment");
                eqm.Description = Console.ReadLine();
                Console.WriteLine("Distance Travelled by Equipment");
                eqm.Distance = Double.Parse(Console.ReadLine());
                Console.WriteLine("Number of Wheels: ");
                eqm.numberofWheels = int.Parse(Console.ReadLine());
                double maintenance = eqm.MoveBy();
                Console.WriteLine("Maintenance cost is {0}", maintenance);
                eqm.Details();
            }
            else if (input == "i")
            {
                var eqim = new Immobile();
                Console.WriteLine("Name of Equipment : ");

                eqim.Name = Console.ReadLine();
                Console.WriteLine("Description of Equipment");

                eqim.Description = Console.ReadLine();
                Console.WriteLine("Distance travelled by Equipment");

                eqim.Distance = Double.Parse(Console.ReadLine());
                Console.WriteLine("Weight of Equipment");
                eqim.weight = Double.Parse(Console.ReadLine());
                double maintain = eqim.MoveBy();
                Console.WriteLine("Maintenance cost is {0}", maintain);
                eqim.Details();
            }
        }
    }

    internal class Mobile
    {
        internal int numberofWheels;

        public Mobile()
        {
        }

        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public double Distance { get; internal set; }

        internal void Details()
        {
            throw new NotImplementedException();
        }

        internal double MoveBy()
        {
            throw new NotImplementedException();
        }
    }
}
