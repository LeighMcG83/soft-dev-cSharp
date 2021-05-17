using System;
using System.Collections.Generic;
using System.Text;

namespace _2021_Alternate_Final_Exam
{
    class Certified : Apprentice
    {
        //attr
        private string _specialism;

        //props
        public string Specialism
        {
            get { return _specialism; }
            set { _specialism = value; }
        }

        //ctors
        public Certified()
        {

        }

        public Certified(string specialism)
        {
            _specialism = specialism.ToLower();
        }

        //methods
        public override double GetHourlyRate()
        {
            switch (_specialism)
            {
                case "electricity":
                    return 18.50;
                case "plumbing":
                    return 19.50;
                case "carpentry":
                    return 17.00;
                case "electronics":
                    return 20.00;
                default:
                    Console.WriteLine("Invalid Specialism");
                    return -1;
            }            
        }

        public override string ToString()
        {
            return base.ToString() + $"{_specialism, 12}";
        }
    }
}
