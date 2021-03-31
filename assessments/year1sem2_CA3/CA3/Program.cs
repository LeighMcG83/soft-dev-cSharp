/* ==============================================================================================
 * Worksheet: |  Year 1 Semester 2 CA3
 * Program:   |  CA3.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  26/03/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a class to represent a Team in a football league. 
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      |  Add: goal difference to table
 *            |  Add: track number wins draws, losses and add to table
 *            |  Add: print league table in descending order
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  GetScores() prints same away team foe each fixture
 * -----------|-----------------------------------------------------------------------------------*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using System.Text;

namespace CA3
{
    class Program
    {
        const string DIVIDER = "--------------------------------------";
        const string INPUT_TAB = "{0, -35}{1, 5}";
        const string MENU_TAB = "{0, 10}{1, -20}";
        const string DISPLAY_TAB = "{0, -5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}";
        

        static void Main(string[] args)
        {
            //setup
            const string QUIT = "3";
            string menuChoice = "";
            bool validChoice = false;
            int goalFor = 0, goalAgainst = 0;       //will taake values for each game's score (pass by ref to GetScore())


            Team[] teams = new Team[5];
            GetTeams(teams);


            //main loop
            while (menuChoice != QUIT && !validChoice)            {
                menuChoice = GetValidMenuChoice();

                switch (menuChoice)
                {
                    case "1":
                        int selectedTeam = GetTeamToEnterResultsFor(teams);  //return an index for the selected team
                        GetScore(ref goalFor, ref goalAgainst, selectedTeam, teams);

                        //test
                        Console.WriteLine(teams[selectedTeam - 1].ToString());
                        validChoice = false;    //reset to loop back into menu
                        break;
                    case "2":
                        PrintLeagueTable(teams);
                        validChoice = false;
                        break;
                    case "3":
                        Console.WriteLine("option 3 chosen");
                        validChoice = true;
                        break;
                    default:
                        menuChoice = GetValidMenuChoice();
                        break;

                }//END: switch(menuChoice)

            }//END: while(!Quit)

        }//END: Main()


        /// <summary>
        /// Method displays the league table
        /// </summary>
        /// <param name="teams"></param>
        private static void PrintLeagueTable(Team[] teams)
        {
            Console.WriteLine(DISPLAY_TAB, "ID", "Team Name", "Pld", "Won", "Draw", "Loss", "For", "Agt", "+/-", "Pts");

            foreach (var team in teams)
            {
                Console.WriteLine(team.ToString());
            }
        }


        /// <summary>
        /// Method prompts user to enter all teams in the league
        /// </summary>
        /// <param name="teams"></param>
        private static void GetTeams(Team[] teams)
        {
            Console.WriteLine("Initial League setup");
            Console.WriteLine(DIVIDER);
            Console.WriteLine("Enter team names....\n");

            for (int i = 0; i < teams.Length; i++)  //initialise objs -> team[i] will not point to ull obj when asssigning to Name
            {
                teams[i] = new Team();
                Console.Write(INPUT_TAB, $"Enter Team {i + 1}'s name", ": ");
                teams[i].Name = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAll teams entered in league");
            Console.ForegroundColor = ConsoleColor.White;


        }


        /// <summary>
        /// Method gets validated scores for the home and away team
        /// </summary>
        /// <param name="goalFor"></param>
        /// <param name="goalAgainst"></param>
        /// <param name="homeTeam"></param>
        /// <param name="awayTeam"></param>
        private static void GetScore(ref int goalFor, ref int goalAgainst, int selected, Team[] teams)
        {
            bool isValid = false;
            string homeTeam = teams[selected - 1].Name;
            string awayTeam = teams[selected].Name;


            for (int i = 0; i < teams.Length; i++)
            {

                if (teams[i].Name != teams[selected - 1].Name)
                {
                    Console.WriteLine($"\n{homeTeam} vs {awayTeam}");
                    Console.WriteLine(DIVIDER);
                    Console.WriteLine("Goals:");

                    do
                    {
                        Console.Write(MENU_TAB, "", "Home: ");
                        string input = Console.ReadLine();
                        isValid = IsPresent(input, "Goals") && IsInt(input, "Goals");
                        if (isValid)
                        {
                            goalFor = Convert.ToInt32(input);
                            do
                            {
                                Console.Write(MENU_TAB, "", "Away: ");
                                input = Console.ReadLine();
                                isValid = IsPresent(input, "Goals") && IsInt(input, "Goals");
                                if (isValid)
                                    goalAgainst = Convert.ToInt32(input);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Result Added successfully");
                                Console.ForegroundColor = ConsoleColor.White;

                            } while (!isValid); 
                            //while (away score !valid)

                        }//END: if(home == valid)
                        
                        teams[selected - 1].AddMatchResult(goalFor, goalAgainst);

                    } while (!isValid); 
                    //while (home score !valid)
                
                }//END: if(teams to compare are not same)               

            }//END: for(all teams in league)

        }//END: GetScore()


        /// <summary>
        /// Method displays the list oof teams in the league and asks user to select one
        /// </summary>
        /// <returns>The team number of a team in the league</returns>
        private static int GetTeamToEnterResultsFor(Team[] teams)
        {
            DisplayTeamNames(teams);

            bool validChoice;
            int teamNum;

            do
            {
                Console.Write(INPUT_TAB, "Select a team to enter results for", ": ");
                validChoice = int.TryParse(Console.ReadLine(), out teamNum);
            } while (!validChoice);

            return teamNum;
        }





        /// <summary>
        /// Display all the teams in the league
        /// </summary>
        /// <param name="teams"></param>
        private static void DisplayTeamNames(Team[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine($"{i + 1}. " +  teams[i].Name);
            }
        }


        /// <summary>
        /// Method displays the main menu options
        /// </summary>
        /// <returns>A string of valid menu choice</returns>
        private static string GetValidMenuChoice()
        {
            bool isValid = false;
            string choice = "";
            
            do
            {
                Console.WriteLine("\n" + DIVIDER);
                Console.WriteLine("MAIN MENU");
                Console.WriteLine(DIVIDER);
                Console.WriteLine(MENU_TAB, "", "1. Add Results");
                Console.WriteLine(MENU_TAB, "", "2. view League Table");
                Console.WriteLine(MENU_TAB, "", "3. Exit");
                Console.WriteLine("\n");
                Console.Write(MENU_TAB, "", "Select option: ");
                choice = Console.ReadLine();
                isValid = IsPresent(choice, "Menu Choice") && IsInt(choice, "Menu Choice") && IsInRange(choice, "Menu Choice", 1, 3);

            } while (!isValid);

            return choice;
           
        }




        /// <summary>
        /// Method check if the passed string argument id an empty string
        /// Takes 1 parameter no overloads
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <returns>True if string is not empty, or false if it is</returns>
        private static bool IsPresent(string menuChoice, string inputLabel)
        {
            if (menuChoice != String.Empty)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nERROR: {inputLabel} cannot be blank");
                Console.ForegroundColor = ConsoleColor.White;

                return false;
            }
        }//END: IsPresent();


        /// <summary>
        /// Method validates a user input by checking it is between a min and max value (inclusive)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is between min and mas range allowed</returns>
        private static bool IsInRange(string choice, string inputLabel, int minValue, int maxValue)
        {
            int intChoice = Convert.ToInt32(choice);
            bool isValid = false;

            if (intChoice >= minValue && intChoice <= maxValue)
            {
                isValid = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nERROR: " + inputLabel + " must be a number between " + minValue + " and " + maxValue);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return isValid;
        }//END: IsInRange()


        /// <summary>
        /// Method checks if a string input can be converted to an integer,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="inputLabel"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsInt(string textIn, string inputLabel)
        {
            int num;
            if (int.TryParse(textIn, out num) == true) // all went ok
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nERROR: " + inputLabel + " must be a number.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return false;
        }//END:  IsInt()


        /// <summary>
        /// Method checks if an int input isgreater than zero
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="inputLabel"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsValidGoals(int textIn, string inputLabel)
        {
            
            if (textIn > 0) 
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nERROR: " + inputLabel + " must be greater than ZERO.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return false;
        }//END:  IsInt()

        //amend if condition  before using
        private static int FindIndex(Team[] teams, string teamNum)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].Name == teamNum)
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
