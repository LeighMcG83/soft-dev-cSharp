using System;
using System.Collections.Generic;
using System.Text;

namespace eurostat
{
    class RiskStat
    {
        //attr
        private int _year;
        private string _country;
        private double _riskLevel;

        
        //props
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }        

        public double RiskLevel
        {
            get { return _riskLevel; }
            set { _riskLevel = value; }
        }


        //ctors
        public RiskStat()
        {

        }

        public RiskStat(int year, string country, double risk)
        {
            _year = year;
            _country = country;
            _riskLevel = risk;
        }


       
        //methods
        public override string ToString()
        {
            Console.WriteLine();
            return $"{_year, 8} {_country, 12} {_riskLevel, 8}";
        }




    }
}
