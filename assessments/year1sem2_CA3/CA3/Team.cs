<<<<<<< HEAD
﻿
/* ===============================================================================================
 * Structure  :  Class:     | Team                        JuniorTeam            Notes            
 *            :  --------   | ----------                  ------------          ----------
 *            :  Attribute: |  name                       inherit               <string> initialise with paramaterized constructor
 *            :             |  scored                     inherit               <int> 
 *            :             |  conceeded                  inherit               <int> 
 *            :             |  pld                        inherit               <int> 
 *            :             |  pts                        inherit               <int> 
 *            :             |  teamID                     inherit               <int> initialised by defaul ctor or param ctor    
 *            :             |                             ageRange              <string>
 *            : ---------   | ---------- ---- -           ----------        ----------------------------------------------------------------------
 *            :  Property:  |  Name                       inherit         
 *            :             |  Scored                     inherit               getter / setter 
 *            :             |  Conceeded                  inherit               getter / setter
 *            :             |  Pld                        inherit               getter / setter
 *            :             |  Pts                        inherit               getter / setter
 *            :             |  TeamID                     inherit               getter / private setter
 *            :  --------   |  ----------                 -----------------------------------------------------------------------------------
 *            :  Method:    |  AddMatchResult()           AddMatchResult()      <param> int scored, int conceeded, overload: 2pts for a draw
 *            :             |  CalculateGoalPerformance() inherit               <param> int totalGoals, int totalConceeded
 *            :             |  ToString()                 ToString()            <override> name, played, scored, conceded and total points.
 *            :             |                                                   <overload> name, played, scored, conceded, total points and ageRange.
 * -----------------------------------------------------------------------------------------------------------------------------------------*/

using System;
=======
﻿using System;
>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8
using System.Collections.Generic;
using System.Text;

namespace CA3
{
    class Team
    {
        //attributes
<<<<<<< HEAD
        private string _name;

        private int _scored;

        private int _conceeded;

        private int _pts;

        private int _pld;

        private int _teamID;

        private int _won;

        private int _draw;

        private int _loss;

        //static variable used to generae unique team ID's
        static int teamCounter = 0;


        //properties
        public int Won
        {
            get { return _won; }

            set { _won = value; }
        }

        public int Draw
        {
            get { return _draw; }

            set { _draw = value; }
        }

        public int Loss
        {
            get { return _loss; }

            set { _loss = value; }
        }

        public int Pld
        {
            get { return _pld; }

            set { _pld = value; }
        }

        public int Pts
        {
            get { return _pts; }

            set { _pts = value; }
        }


        public int Conceeded
        {
            get { return _conceeded; }

            set { _conceeded = value; }
        }


=======
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

>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8
        public int Scored
        {
            get { return _scored; }

            set { _scored = value; }
        }

<<<<<<< HEAD
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public int TeamID
        {
            get { return _teamID; }

            private set { _teamID = value; }
        }
=======
        public int Conceeded { get; set; }

        public int Pts { get; set; }

        public int Pld { get; set; }

        public int TeamID { get; private set; }
>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8


        //ctors
        public Team()
<<<<<<< HEAD
        {            
            _teamID = teamCounter;
            teamCounter++;
        }

        public Team(string name)
        {
            _name = name;
            _teamID = teamCounter;
            teamCounter++;            
        }

        public Team(string name, int scored, int conceeded)
        {
            _name = name;
            _scored = scored;
            _conceeded = conceeded;
            _teamID = teamCounter;
            teamCounter++;
=======
        {
            _teamID += 1;
        }

        public Team(string name)
        {
            _teamID += 1;
            Name = name;
>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8
        }


        //methods
        public void AddMatchResult(int scored, int conceeded)
<<<<<<< HEAD
        {            
            _scored += scored;
            _conceeded += conceeded;

            if (scored > conceeded)
            {
                _pts += 2;
                _won++;
            }

            else if (scored == conceeded)
            {
                _pts += 1;
                _draw++;
            }

            else
                _loss++;

            _pld++;

        }//END: AddMatchResult()

        /// <summary>
        /// Calculates a teams' total goal difference
        /// </summary>
        /// <returns>An int of a team-type objects' goal difference</returns>
        public int GoalDifference()
        {
            return _scored - _conceeded;
        }

        public override string ToString()       
        {
            const string DISPLAY_TAB = "{0,-5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}";
            return String.Format(DISPLAY_TAB, $"[{_teamID}]", $" {_name}", $" {_pld}", $" {_won}", $" {_draw}", $" {_loss}", 
                $" {_scored}", $" {_conceeded}", $" {GoalDifference()}", $" {_pts}");
=======
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
>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8
        }

    }//END: Team class 
}
