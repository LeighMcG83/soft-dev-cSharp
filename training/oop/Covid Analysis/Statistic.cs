using System;
using System.Collections.Generic;
using System.Text;
using static Covid_Analysis.Validation;

namespace Covid_Analysis
{
    class Statistic
    {
        //attrs
        private int _day;
        private int _month;
        private int _year;
        private DateTime _date;
        private int _casesOnGivenDay;
        private int _deaths;
        private string _countryName;
        private string _countryCode;
        private int _population;
        private string _continent;
        private double _14dayMovingAvg;

        //props
        public double MovingAverage
        {
            get { return _14dayMovingAvg; }
            set 
            {
                if (value == double.NaN)
                    _14dayMovingAvg = 0;
            }
        }

        public string Continent
        {
            get { return _continent; }
            set
            {
                if (value == null)
                    _continent = string.Empty;
            }
        }

        public int Population
        {
            get { return _population; }
            set
            {
                if((string)value != "")
                {

                }

                if (Convert.ToString(value).Length != 0)    //if value's Length when converted to a string is 0, the data is missing
                    _population = value;
                else
                    _population = 0;
            }
        }

        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (value == null)
                    _countryCode = string.Empty;
            }
        }

        public string CountryName
        {
            get { return _countryName; }
            set
            {
                if (value == null)
                    _countryName = string.Empty;
            }
        }

        public int Deaths
        {
            get { return _deaths; }
            set
            {
                if (value == null)
                    _deaths = 0;
            }
        }

        public int CasesOnGivenDay
        {
            get { return _casesOnGivenDay; }
            set
            {
                if (value == null)
                    _casesOnGivenDay = 0;
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value == null)
                    _year = 0;
            }
        }

        public int Month
        {
            get { return _month; }
            set
            {
                if (value == null)
                    _month = 0;
            }
        }

        public int Day
        {
            get { return _day; }
            set
            {
                if (value == null)
                    _day = 0;
            }
        }

        //ctors
        public Statistic()
        {
            
        }

        public Statistic(
            int day, int month, int year, int cases, int deaths,
            string country, string code, string pop, string continent, double movingAvg)
        {
            _day = day; _month = month; _year = year; _casesOnGivenDay = cases;
            _deaths = deaths; _countryName = country; _countryCode = code; _population = Convert.ToInt32(pop);
            _continent = continent; _14dayMovingAvg = movingAvg;

            _date = new DateTime(_year, _month, _day);

        }

        //methods
        public override string ToString()
        {
            return $"{Date,-8}{_countryName,-15}{_casesOnGivenDay,-10}{_deaths,-10}{_14dayMovingAvg,-20}{_population,-12}";
        }

    }
}
