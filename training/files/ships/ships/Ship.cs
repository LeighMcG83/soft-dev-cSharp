using System;
using System.Collections.Generic;
using System.Text;

namespace ships
{
    class Ship
    {
        //attr
        private string _name;
        private int _type;
        private int _tonnage;
        private int _crew;
        private int _location;

        private static readonly int[] vesselCosts = { 2610, 2359, 2050, 999, 2550, 2510 };
        private static readonly string[] vesselFunctions = { 
            "Aircraft carrier",
            "Cruiser/Battleship", 
            "Destroyer", 
            "Frigate", 
            "Nuclear Submarine", 
            "Minelayer/Sweeper" 
        };
        private static readonly string[] locations = {
            "The Pacific",
            "The Atlantic",
            "The Mediterranean",
            "The Indian Ocean",
            "The Other Seas"
        };

        
        //props

        /*can these properties have private setters?? */

        public int Location
        {
            get { return _location; }
            set { _location = value; }
        }


        public int Crew
        {
            get { return _crew; }
            set { _crew = value; }
        }


        public int Tonnage
        {
            get { return _tonnage; }
            set { _tonnage = value; }
        }


        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        //ctors
        public Ship()
        {

        }

        public Ship(string name, int type, int tonnage, int crew, int location)
        {
            _name = name;
            _type = type;
            _tonnage = tonnage;
            _crew = crew;
            _location = location;
        }


        //methods
        public decimal CalculateCost()
        {
            return _crew * vesselCosts[_type - 1];           
        }

        public override string ToString()
        {
            return $"{locations[_location - 1], -20}{vesselFunctions[_type - 1], -20}{_name, -15}{_tonnage, -10}{_crew, -10}{CalculateCost(), -10}";
        }

    }
}
