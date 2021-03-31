using System;
using System.Collections.Generic;
using System.Text;

namespace oopCar
{
    class Car
    {
        //attributes
        static int regCounter;

        string _regNo;

        string _make;

        string _model;

        string _color;

        //int _fuelLevel;


        //properties
        public string RegNo { get { return _regNo; } private set { RegNo = _regNo; } }

        public string Make
        {
            get { return _make; }

            set
            {
                if (value.ToLower() == "vw" || value.ToLower() == "audi" || value.ToLower() == "bmw")
                    _make = value;
                else
                    throw new Exception("Invalid Brand Name, must be Volkwagon, BMV or Audi");
            }
        }


        public string  Model { get { return _model; } set { Model = _model; } }

        public string Color { get { return _color; } set { Color = _color; } }

        //public int FuelLevel { get { return _fuelLevel; } set { FuelLevel = _fuelLevel; } }


        //ctors
        public Car()
        {
            _regNo = "DL " + regCounter.ToString();
            regCounter++;
        }

        public Car(string make)
        {
            _make = make;
            _regNo = "DL " + regCounter.ToString();
            regCounter++;
        }

        public Car(string make, string model)
        {
            _make = make;
            _model = model;
            _regNo = "DL " + regCounter.ToString();
            regCounter++;
        }


        public Car(string make, string model, string color)
        {
            _make = make;
            _model = model;
            _color = color;
            _regNo = "DL " + regCounter.ToString();
            regCounter++;
        }

        //methods
        public override string ToString()
        {
            const string DISPLAY_TAB = "{0, -10}{1, -10}{2, -10}{3, -10}";
            return String.Format(DISPLAY_TAB, $"{Make}", $"{Model}", $"{Color}", $"{this.RegNo}");
        }


    }
}
