/* ==============================================================================================
 * Worksheet: |  Year 1 Semester 2 CA3
 * Program:   |  CA3.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  26/03/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a class to represent a Team in a football league. 
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | x Add: goal difference to table
 *            | x Add: track number wins draws, losses and add to table
 *            |  Add: print league table in descending order (pts, then goal diff_
 *            |  Add: 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      | 
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
        const string DIVIDER = "---------------------------------------------------------------";
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
            Console.ForegroundColor = ConsoleColor.White;

            Team[] teams = new Team[5];
            //{
            //    teams[0].Name = "Manchester United";
            //    teams[1].Name = "Oman";
            //    teams[2].Name = "Brazil";
            //    teams[3].Name = "Ireland";
            //    teams[4].Name = "Cruzeiro";
            //};


            GetTeams(teams);

            //main loop
            while (menuChoice != QUIT && !validChoice)
            {
                menuChoice = GetValidMenuChoice();

                switch (menuChoice)
                {
                    case "1":
                        int selectedTeam = GetTeamToEnterResultsFor(teams);  //return an index for the selected team
                        GetScore(ref goalFor, ref goalAgainst, selectedTeam, teams);
                        validChoice = false;    //reset to loop back into menu
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n" + DIVIDER);
                        PrintLeagueTable(teams);
                        validChoice = false;
                        break;
                    case "3":
                        Console.WriteLine("You chose to Exit");
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
            Console.WriteLine(DISPLAY_TAB, "ID", "Team Name", "Pld", "Won", "Drawn", "Lost", "For", "Agt", "+/-", "Pts");

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
            bool isValid;
            Console.WriteLine("Initial League Setup");
            Console.WriteLine(DIVIDER);
            Console.WriteLine("Enter team names....\n");

            for (int i = 0; i < teams.Length; i++)  //initialise objs -> team[i] will not point to ull obj when asssigning to Name
            {
                teams[i] = new Team();
                Console.Write(INPUT_TAB, $"Enter Team {i + 1}'s name", ": ");
                string input = Console.ReadLine();
                isValid = IsPresent(input, "Team Name");
                if (isValid)
                {
                    teams[i].Name = input;

                    for (int j = 0; j < teams.Length; j++)
                    {

                    }
                
                }//END: if)input valid)

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n[SUCCESS]: All teams entered in league");
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
            bool isValid;
            string homeTeam = teams[selected - 1].Name;   //selected team's index == 1 less than the number entered by the user(option1 == teams[0])

            for (int i = 0; i < teams.Length; i++)
            {
                string awayTeam = teams[i].Name;          //away team is the nest team in the list(teams[i] as the number selected by the user will 
                                                          //be the index of the next team on the list due to zero indexing

                if (teams[i].Name != teams[selected - 1].Name)
                {
                    Console.WriteLine($"\n{homeTeam} vs {awayTeam}");
                    Console.WriteLine(DIVIDER);
                    Console.WriteLine("Enter Score:");
                    
                    do
                    {
                        Console.Write(MENU_TAB, "", "Home: ");
                        string input = Console.ReadLine();
                        isValid = IsPresent(input, "Goals") && IsPostiveInt(input, "Goals");
                        if (isValid)
                        {
                            goalFor = Convert.ToInt32(input);
                            do
                            {
                                Console.Write(MENU_TAB, "", "Away: ");
                                input = Console.ReadLine();
                                isValid = IsPresent(input, "Goals") && IsPostiveInt(input, "Goals");

                                if (isValid)
                                {
                                    goalAgainst = Convert.ToInt32(input);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n[SUCCESS]: Result Added successfully\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                            } while (!isValid);
                            //while (away score !valid)

                        }//END: if(home == valid)

                        teams[selected - 1].AddMatchResult(goalFor, goalAgainst);

                    } while (!isValid);
                    //while (home score !valid)

                }//END: if(teams to compare are not same)                   

            }//END: for(all teams in league)

            Thread.Sleep(1500);
            Console.Clear();

        }//END: GetScore()


        /// <summary>
        /// Method displays the list oof teams in the league and asks user to select one
        /// </summary>
        /// <returns>The team number of a team in the league</returns>
        private static int GetTeamToEnterResultsFor(Team[] teams)
        {
            Console.Clear();
            DisplayTeamNames(teams);

            bool validChoice;
            int teamNum = 0;
            string input;

            do
            {
                Console.Write(INPUT_TAB, "Select a team to enter results for", ": ");
                input = Console.ReadLine();
                validChoice = IsPresent(input, "Team Number") && IsPostiveInt(input, "Selection") && IsInRange(input, "Team Number", 1, 5) && int.TryParse(input, out teamNum);
                if (validChoice)
                {
                    teamNum = Convert.ToInt32(input);
                }
            } while (!validChoice);

            return teamNum;
        }//END: GetTeamToEnterResultsFor()



        /// <summary>
        /// Display all the teams in the league
        /// </summary>
        /// <param name="teams"></param>
        private static void DisplayTeamNames(Team[] teams)
        {
            Console.WriteLine();
            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine($"{i + 1}. " +  teams[i].Name);
            }
            Console.WriteLine();
        }





        /// <summary>
        /// Method displays the main menu options
        /// </summary>
        /// <returns>A string of valid menu choice</returns>
        private static string GetValidMenuChoice()
        {
            bool isValid;
            string choice; 
            do
            {
                Console.WriteLine("\n" + DIVIDER);
                Console.WriteLine(MENU_TAB, "", "MAIN MENU");
                Console.WriteLine(DIVIDER);
                Console.WriteLine(MENU_TAB, "", "1. Add Results");
                Console.WriteLine(MENU_TAB, "", "2. View League Table");
                Console.WriteLine(MENU_TAB, "", "3. Exit");
                Console.WriteLine("\n");
                Console.Write(MENU_TAB, "", "Select option: ");
                choice = Console.ReadLine();
                isValid = IsPresent(choice, "Menu Choice") && IsPostiveInt(choice, "Menu Choice") && IsInRange(choice, "Menu Choice", 1, 3);

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR]: {inputLabel} cannot be blank\n");
                Console.ForegroundColor = ConsoleColor.White;

                return false;
            }
        }//END: IsPresent();


        /// <summary>
        /// Method validates a user input by checking it is between a min and max value (inclusive)
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="inputLabel"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR]: {inputLabel} must be a number between {minValue} & {maxValue}\n");
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
        static bool IsPostiveInt(string textIn, string inputLabel)
        {
            if (int.TryParse(textIn, out int num) == true)
            {
                if (num >= 0)                
                    return true;
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ERROR]: " + inputLabel + " must be a number.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return false;
        }//END:  IsInt()


       

    }//END: class Program
}
