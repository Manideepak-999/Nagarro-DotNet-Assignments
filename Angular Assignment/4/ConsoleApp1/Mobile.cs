using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Mobile : Equipment
    {
        public int numberOfWheels;
        public override double MoveBy()
        {

            double maintainance = numberOfWheels * Distance;
            this.MaintainanceCost = maintainance;
            return maintainance;
        }
        public override void Details()
        {
            Console.WriteLine("Name : {0} ", Name);
            Console.WriteLine("Description : {0}", Description);
            Console.WriteLine(" Distance Moved Till Date : {0}", Distance);
            Console.WriteLine("Maintainance Cost : {0}", MaintainanceCost);
            Console.WriteLine("Type of Equipment : Mobile");
        }
    }
}