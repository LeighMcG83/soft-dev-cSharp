using System;
using System.Collections.Generic;
using System.Text;

namespace lab14b_inheritance
{
    class Computer
    {
        //attributes
        string _manufacturer;

        private string _country;


        //properties
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }


        //ctors
        public Computer()
        {

        }

        public Computer(string manufacturer, string country)
        {
            _manufacturer = manufacturer;
            _country = country;
        }


        //methods
        public string TurnOn()
        {
            return "Computer Powered ON";
        }

        public string TurnOff()
        {
            return "Computer powered OFF";
        }

        public override string ToString()
        {
            return $"Country of Origin: {_country}\nManufacturer: {_manufacturer}\n";
        }

    }
}
