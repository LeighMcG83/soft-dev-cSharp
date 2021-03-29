using System;
using System.Collections.Generic;
using System.Text;

namespace CA3
{
    class Team
    {
        //attributes
        string _name = "";

        int _scored;

        int _conceeded;

        int _pts;

        int _pld;

        int _teamID;


        //properties
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public int Scored
        {
            get { return _scored; }

            set { _scored = value; }
        }

        public int Conceeded { get; set; }

        public int Pts { get; set; }

        public int Pld { get; set; }

        public int TeamID { get; private set; }


        //ctors
        public Team()
        {
            _teamID += 1;
        }

        public Team(string name)
        {
            _teamID += 1;
            Name = name;
        }


        //methods
        public void AddMatchResult(int scored, int conceeded)
        {
            _pld++;
            _scored += scored;
            _conceeded += conceeded;

            if(scored > conceeded)
            {
                _pts += 2;
            }

            if(scored == conceeded)
            {
                _pts += 1;
            }

        }//END: AddMatchResult()

        public override string ToString()       //virtual???
        {
            return String.Format($"{_teamID}", $" {this.Name}", $" {_pld}", $" {_scored}", $" {_conceeded}", $" {this.Pts}" );
        }

    }//END: Team class 
}
