using System;
using System.Collections.Generic;
using System.Text;

namespace _2021_Alternate_Final_Exam
{
    class Apprentice
    {
        //attr
        protected string _name;
        protected int _trainingHours;
        private int _id;

        //static var to use in unique id creation
        static private int idCounter;

        //props
        public int TrainingHours
        {
            get { return _trainingHours; }
            set { _trainingHours = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //ctors
        public Apprentice()
        {
            _id = idCounter;
            idCounter++;
        }

        public Apprentice(string name, int hours)
        {
            _id = idCounter;
            idCounter++;
            _name = name;
            _trainingHours = hours;
        }

        //methods
        public virtual double GetHourlyRate()
        {
            double rate = 0;

            switch (_trainingHours)
            {
                case int r when _trainingHours >= 700:
                    rate = 14.0;
                    break;
                case int r when _trainingHours >= 600:
                    rate = 12.0;
                    break;
                case int r when _trainingHours >= 400:
                    rate = 10.50;
                    break;
                case int r when _trainingHours < 400:
                    rate = 9.50;
                    break;
                default:
                    Console.WriteLine("Invalid Training Hours");
                    break;
            }
            return rate;   
        }

        public override string ToString()
        {
            return $"{_id,5}{_name,15}{_trainingHours,8}";
        }

    }
}
