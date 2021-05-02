using System;
using System.Collections.Generic;
using System.Text;

namespace CA3
{
    class JuniorTeam : Team
    {
        //attributes
        private string _ageRange;


        //property
        public string AgeRange
        {
            get { return _ageRange; }
            set { _ageRange = value; }
        }

        //constructors
        public JuniorTeam():base()
        {

        }

        public JuniorTeam(string name, string range):base(name)
        {
            _ageRange = range;
        }

        //public JuniorTeam(string name, int scored, int conceeded, string ageRange):base(name, scored, conceeded)
        //{

        //    _ageRange = ageRange;
        //}



        //methods
        public override void AddMatchResult(int scored, int conceeded)
        {
            scored += scored;
            conceeded += conceeded;

            if (scored > conceeded)
            {
                Pts += 4;
                Won++;
            }

            else if (scored == conceeded)
            {
                Pts += 2;
                Draw++;
            }

            else
                Lost++;

            GamesPlayed++;
        }

        public override string ToString()
        {
            //const string DISPLAY_TAB = "{0,-5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}{10,-5}";
            return string.Format("{0}{1,25}", base.ToString(), $"Age Group:  {_ageRange}");
        }
    }
}
