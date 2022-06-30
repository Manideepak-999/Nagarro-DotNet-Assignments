using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Equipment
    {
        public string Name;
        public string Description;
        public double Distance;
        public double MaintainanceCost;
        public string typeOfEquipment;

        public Equipment()
        {
            Distance = 0;
            MaintainanceCost = 0;

        }
        public virtual double MoveBy()
        {
            return MaintainanceCost;
        }
        public virtual void Details()
        {
            Console.WriteLine("Name : {0}, Description : {1}, Distance Moved Till Date : {2}, Maintainance Cost{3}", Name, Description, Distance, MaintainanceCost);
        }

    }
}