using System;
using System.Collections.Generic;
using System.Text;

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
            set { _14dayMovingAvg = value; }
        }

        public string Continent
        {
            get { return _continent; }
            set { _continent = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value.ToUpper(); }
        }

        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        public int Deaths
        {
            get { return _deaths; }
            set { _deaths = value; }
        }

        public int CasesOnGivenDay
        {
            get { return _casesOnGivenDay; }
            set { _casesOnGivenDay = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = new DateTime(_year, _month, _day);
            }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        //ctors
        public Statistic()
        {

        }

        public Statistic(
            int day, int month, int year, int cases, int deaths,
            string country, string code, int pop, string continent, double movingAvg)
        {
            _day = day; _month = month; _year = year; _casesOnGivenDay = cases;
            _deaths = deaths; _countryName = country; _countryCode = code; _population = pop;
            _continent = continent; _14dayMovingAvg = movingAvg;

        }

        //methods
        public override string ToString()
        {
            return $"{_date.Date,-8}{_countryName,-15}{_casesOnGivenDay,-10}{_deaths,-10}{_14dayMovingAvg,-20}{_population,-12}";
        }

    }
}
