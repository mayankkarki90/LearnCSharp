using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    public abstract class Vehicle
    {
        public abstract int NoOfCylinders();

        public string FuelType()
        {
            return "Petrol";
        }
    }

    public class Car : Vehicle
    {
        public override int NoOfCylinders()
        {
            return 4;
        }

        public new string FuelType()
        {
            return "Diesel";
        }
    }

    public class Byke : Vehicle
    {
        public override int NoOfCylinders()
        {
            return 2;
        }

        public string FuelType()
        {
            return "Petrol";
        }
    }
}
