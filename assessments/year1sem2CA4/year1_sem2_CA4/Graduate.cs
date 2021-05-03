using System;
using System.Collections.Generic;
using System.Text;

namespace year1_sem2_CA4
{
    class Graduate
    {
        //attr
        protected string _name;
        protected int _mark;
        protected int _id;

        protected static int idCounter = 1;


        //props
        public int ID
        {
            get { return _id; }
            protected set { _id = value; }
        }

        public int Mark
        {
            get { return _mark; }
            set 
            {
                if (value < 0)
                    _mark = 0;
                else
                    _mark = value; 
            }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //ctors
        public Graduate()
        {
            _id = idCounter;
            idCounter++;
        }

        public Graduate(string name, int mark)
        {
            _id = idCounter;
            idCounter++;
            _name = name;
            _mark = mark;
        }

        //methods
        public virtual string GetDegreeClassification()
        {
            string classification = "";

            if (_mark >= 70)
            {
                classification = "Distrinction";
            }
            else if (_mark >= 60)
            {
                classification = "Merit";
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
            return $"{_id,-10}{_name,-15}{GetDegreeClassification(), -15}{_mark,-6}";
        }

    }
}
