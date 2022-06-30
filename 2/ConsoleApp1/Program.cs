//Equals() is an instance method that takes one parameter which can be null
//Since it is an instance method must be invoked on an actual object, it can't be invoked on null reference
//ReferenceEquals() is a static method that takes two parameters, either/both of which can be null.it wont throw a NullReferenceException
//"==" is an operator so in this case behaves identically to ReferenceEquals.
//It will not throw a NullReferenceException either.


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

            int x = 50, y = 60, z = 50;
            //== operator
            Console.WriteLine(x == x);
            Console.WriteLine(x == y);
            Console.WriteLine(x == z);

            //Equals() operator
            Console.WriteLine(x.Equals(x));
            Console.WriteLine(x.Equals(y));
            Console.WriteLine(x.Equals(z));

            //Object.Referenceequals
            Console.WriteLine(object.ReferenceEquals(x, z));
            Console.WriteLine(object.ReferenceEquals(x, y));
            Console.WriteLine(object.ReferenceEquals(x, x));
            Console.ReadLine();

        }
    }
}