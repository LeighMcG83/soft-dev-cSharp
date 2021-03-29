/* ==============================================================================================
 * Worksheet: |  Year 1 Semester 2 CA3
 * Program:   |  CA3.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  26/03/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a class to represent a Team in a football league. 
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ===============================================================================================
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

// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace CA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("United");
            Console.WriteLine(team.ToString());
        }
    }
}
