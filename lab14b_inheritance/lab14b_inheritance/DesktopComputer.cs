using System;
using System.Collections.Generic;
using System.Text;

namespace lab14b_inheritance
{
    class DesktopComputer : Computer
    {
        //attributes
        private int _screenSize;
        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    _price = 0;
                else
                    _price = value;
            }
        }

        public int ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = value; }
        }

        //ctors
        public DesktopComputer()
        {

        }

        public DesktopComputer(string manufacturer, string country, double price, int screenSize) : base(manufacturer, country)
        {
            Price = price;
            ScreenSize = screenSize;
        }       


        //methods
        public override string ToString()
        {
            return base.ToString() + $"Screen Size: {ScreenSize}\nPrice: {Price}\n";
        }

    }
}
