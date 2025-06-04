using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal interface IDrivable
    {
        void GoForward(int speed);
    }

    public class Truck : IDrivable
    {
        public void GoForward(int speed)
        {
            Console.WriteLine("Normal method call");
        }

        /// <summary>
        /// When you write a method with fully qualified interface name, it can only be
        /// accessed when the object is cased as interface. Access modifier is not required
        /// </summary>
        /// <param name="speed">The speed.</param>
        void IDrivable.GoForward(int speed)
        {
            Console.WriteLine("Interface method called");
        }
    }
}
