
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
using System.Collections.Generic;
using System.Text;

namespace CA3
{
    class Team
    {

        //attributes
        private string _name;

        private int _scored;

        private int _conceeded;

        private int _pts;

        private int _gamesPlayed;

        private int _teamID;

        private int _won;

        private int _draw;

        private int _lost;

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

        public int Lost
        {
            get { return _lost; }

            set { _lost = value; }
        }

        public int GamesPlayed
        {
            get { return _gamesPlayed; }

            set { _gamesPlayed = value; }
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

        public int Scored
        {
            get { return _scored; }

            set { _scored = value; }
        }

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }


        //ctors
        public Team()
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
        }


        //methods
        public virtual void AddMatchResult(int scored, int conceeded)
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
                _lost++;

            _gamesPlayed++;

        }//END: AddMatchResult()


        /// <summary>
        /// Calculates a teams' total goal difference
        /// </summary>
        /// <returns>An int of a team-type objects' goal difference</returns>
        public int Get_GoalDifference()
        {
            return _scored - _conceeded;
        }

        public override string ToString()       
        {
            const string DIVIDER = "---------------------------------------------------------------";
            const string DISPLAY_TAB = "{0,-5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}";

            Console.WriteLine(DIVIDER);
            return String.Format(DISPLAY_TAB, $"[{_teamID}]", $" {_name}", $" {_gamesPlayed}", $" {_won}", $" {_draw}", $" {_lost}", 
                                              $" {_scored}", $" {_conceeded}", $" {Get_GoalDifference()}", $" {_pts}");
        }

    }//END: Team class 
}
