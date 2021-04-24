using System;
using System.Collections.Generic;
using System.Text;

namespace lab14b_inheritance
{
    class LaptopComputer : DesktopComputer
    {
        //attributes
        private double _batteryLife;
        private double _batteryPercent;
        private string _mouse;


        //props
        public double BatteryPercent
        {
            get { return _batteryPercent; }
            set { _batteryPercent = value; }
        }

        public string Mouse
        {
            get { return _mouse; }
            set {
                if (value == "Corded")
                    _mouse = "TouchPad";
                else
                    _mouse = value; }
        }

        public double BatteryLife
        { 
            get { return _batteryLife; }
            set { _batteryLife = value; }
        }


        //ctors
        public LaptopComputer()
        {

        }

        public LaptopComputer(string country, string manufacturer, double price, int screenSize, double battery, double currentBattery, string mouse) : base(country, manufacturer, price, screenSize)
        {            
            BatteryLife = battery;
            BatteryPercent = currentBattery;
            Mouse = mouse;
        }

        //methods
        public double CalcBatteryTimeRemaining()
        {
            return _batteryLife * (_batteryPercent / 100);
        }

        public override string ToString()
        {
            return base.ToString() + $"Total Battery Life: {_batteryLife}\nCurrent Battery Life: {CalcBatteryTimeRemaining()}\nMouse: {_mouse}\n";
        }


    }
}
