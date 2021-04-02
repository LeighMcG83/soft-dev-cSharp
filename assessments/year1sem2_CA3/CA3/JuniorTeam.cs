using System;
using System.Collections.Generic;
using System.Text;

namespace CA3
{
    class JuniorTeam : Team
    {
        //attributes
        private string _ageRange;

   

        //constructors
        public JuniorTeam():base()
        {

        }

        public JuniorTeam(string name,int scored,int conceeded, string ageRange):base(name, scored, conceeded )
        {
            _ageRange = ageRange;
        }



        //methods
        public override void AddMatchResult(int scored, int conceeded)
        {
            scored += scored;
            conceeded += conceeded;

            if (scored > conceeded)
            {
                Pts += 2;
                Won++;
            }

            else if (scored == conceeded)
            {
                Pts += 1;
                Draw++;
            }

            else
                Lost++;

            GamesPlayed++;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format($"{_ageRange}");
        }
    }
}
