using System;
using System.Collections.Generic;
using System.Text;

namespace year1_sem2_CA4
{
    class HonoursGraduate : Graduate
    {
        //attr
        private string _topic;

        //props
        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }

        //ctors
        public HonoursGraduate():base()
        {
            
        }

        public HonoursGraduate(string name, int mark, string topic):base(name, mark)
        { 
            _topic = topic;
        }

        //methods
        public override string GetDegreeClassification()
        {
            string classification = "";

            if (_mark >= 70)
            {
                classification = "1st";
            }
            else if (_mark >= 60)
            {
                classification = "2-1";
            }
            else if (_mark >= 50)
            {
                classification = "2-2";
            }
            else if (_mark >= 40)
            {
                classification = "Pass";
            }
            else
            {
                classification = "None";
            }
            return classification;
        }

        public override string ToString()
        {
            return base.ToString() + $"{ _topic, -10}";
        }

    }
}
