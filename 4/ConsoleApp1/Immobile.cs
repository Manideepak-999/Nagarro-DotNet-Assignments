using System;

namespace ConsoleApp1
{
    internal class Immobile
    {
        internal double weight;

        public Immobile()
        {
        }

        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public double Distance { get; internal set; }

        internal double MoveBy()
        {
            throw new NotImplementedException();
        }

        internal void Details()
        {
            throw new NotImplementedException();
        }
    }
}