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
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  - Error message not printing if home goals is alpha
 *            |  - IsPositveInt(): not printing error message when neg value entered in DecideDefaultOrCustomTeams()
 * -----------|-----------------------------------------------------------------------------------*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

namespace CA3
{
    class Program
    {
        const string DIVIDER = "---------------------------------------------------------------";
        const string INPUT_TAB = "{0, -35}{1, 5}";
        const string INDENTED_TAB = "{0, 10}{1, -20}";
        const string DISPLAY_TAB = "{0, -5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}";

        static void Main(string[] args)
        {
            //setup
            const string QUIT = "3";
            const string BACK = "4";
            string menuChoice = "";
            bool validChoice = false;
            int goalFor = 0, goalAgainst = 0;       //will take values for each game's score (pass by ref to GetScore())
            string leagueAge  = "1", leagueType;
            Team[] teams = new Team[5];
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                leagueAge = DecideLeagueAge(ref validChoice);

                if (leagueAge != QUIT)
                {
                    leagueType = DecideDefaultOrCustomTeams(ref validChoice);

                    if (leagueType != QUIT)
                    {
                        BuildLeagueTable(teams, leagueType);
                        //BuildLeagueTable(teams, leagueType, leagueAge);

                        while (menuChoice != BACK)
                        {
                            menuChoice = PrintMainMenu();

                            switch (menuChoice)
                            {
                                case "1":
                                    GetScore(ref goalFor, ref goalAgainst, teams);
                                    //validChoice = false;    //reset boolean state to false so control will re-enter loop
                                    break;
                                case "2":
                                    PrintLeagueTable(teams);
                                    //validChoice = false;
                                    break;
                                case "3":
                                    leagueType = ModifyTeams(ref validChoice, teams);
                                    break;
                                case "4":
                                    PrintExitMsg("Returning to League Setup");
                                    //validChoice = true;
                                    break;
                                default:
                                    menuChoice = PrintMainMenu();
                                    break;

                            }//END: switch(menuChoice)

                        }//END: while(!Quit && !valid)      

                    }//END: if(!valid leagueType selection)


                    else
                        continue; //reload mainMenu
                    

                }//END: if(!valid leagueAge selection)            
                else
                    PrintExitMsg();

            } while (leagueAge != QUIT);

        }//END: Main()


        /*---------------   LEAGUE TABLE METHODS    ---------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validChoice"></param>
        /// <param name="teams"></param>
        /// <returns></returns>
        private static string ModifyTeams(ref bool validChoice, Team[] teams)
        {
            string leagueType;
            DisplayTeamNames(teams);
            leagueType = DecideDefaultOrCustomTeams(ref validChoice);
            BuildLeagueTable(teams, leagueType);
            return leagueType;
        }

        /// <summary>
        /// Method creates a league table. Takes parameters for the teams to enter and league type, default or custom
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="leagueType"></param>
        private static void BuildLeagueTable(Team[] teams, string leagueType)
        {
            switch (leagueType)
            {
                case "1":
                    CreateDefaultLeague(teams);
                    break;
                case "2":
                    CreateCustomLeague(teams);
                    break;
                default:
                    PrintErrorMsg("\n[ERROR]: Teams setup error.\n");
                    Console.WriteLine("Closing Program");
                    Thread.Sleep(3000);
                    break;
            }
        }//END:BuildLeagueTable()

        /// <summary>
        /// Method ceates a leagefrom predetermind array of teams
        /// </summary>
        /// <param name="teams"></param>
        private static void CreateDefaultLeague(Team[] teams)
        {
            string[] teamNames = { "Rep. of Ireland", "Oman", "Brazil", "Scotland", "England" };

            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new Team();
                teams[i].Name = teamNames[i];
            }
            PrintSuccessMessage("\n[SUCCESS]: All teams entered in league\n");
        }

        /// <summary>
        /// Method creates a league made of user entered teams
        /// </summary>
        /// <param name="teams"></param>
        private static void CreateCustomLeague(Team[] teams)
        {
            for (int i = 0; i < teams.Length; i++)            
                teams[i] = new Team();            

            bool isValid;
            Console.WriteLine("Initial League Setup");
            Console.WriteLine(DIVIDER);
            Console.WriteLine("Enter team names....\n");

            for (int i = 0; i < teams.Length; i++)
            {
                do
                {
                    teams[i] = new Team();      //initialise objs -> team[i] will not point to ull obj when asssigning to Name
                    Console.Write(INPUT_TAB, $"Enter Team {i + 1}'s name", ": ");
                    string input = Console.ReadLine();
                    isValid = IsPresent(input, "Team Name") && IsAlpha(input, "Team Name");
                    if (isValid)                    
                        teams[i].Name = input;                        
                    
                } while (!isValid);
                
            }//END: for(all teams)

            PrintSuccessMessage("\n[SUCCESS]: All teams entered in league\n");

        }//END: CreateCustomLeague()

        /// <summary>
        /// Method ask the user to use default teams or enter customised team names
        /// </summary>
        /// <returns>A validated string of users' choice/returns>
        private static string DecideDefaultOrCustomTeams(ref bool isValid)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "League Teams Setup");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Use Default Teams");
                Console.WriteLine(INDENTED_TAB, "", "2. Create Custom League");
                Console.WriteLine(INDENTED_TAB, "", "3. Back\n");
                Console.Write(INDENTED_TAB, "", "Choice:");
                input = Console.ReadLine();
                isValid = ValidateInput(input, 1, 3);
            } while (!isValid);

            return input;
        }//END: DecideCustomOrDefault()

        /// <summary>
        /// Method displays the league table
        /// </summary>
        /// <param name="teams"></param>
        private static void PrintLeagueTable(Team[] teams)
        {
            Console.Clear();
            Console.WriteLine(DIVIDER);
            Console.WriteLine("League Table");
            Console.WriteLine(DIVIDER);
            Console.Write(DISPLAY_TAB, "ID", "Team Name", "Pld", "Won", "Drawn", "Lost", "For", "Agst", "+/-", "Pts");
            Console.WriteLine();

            foreach (var team in teams)
                Console.WriteLine(team.ToString());

            Console.Write(INDENTED_TAB, "", "\nPress Enter key to return to Main Menu...");
            Console.Read();
        }


        /*---------------   MENU AND PROGRAM FUNCTIONALITY METHODS    ---------------*/

        /// <summary>
        /// Method gets the score form the user
        /// </summary>
        /// <param name="goalFor"></param>
        /// <param name="goalAgainst"></param>
        /// <param name="teams"></param>
        private static void GetScore(ref int goalFor, ref int goalAgainst, Team[] teams)
        {
            bool isValid;
            
            for (int i = 0; i < teams.Length; i++)
            {
                string homeTeam = teams[i].Name;

                for (int j = 0; j < teams.Length; j++)
                {
                    string awayTeam = teams[j].Name;

                    if (teams[i].Name != teams[j].Name)
                    {
                        DisplayCurrenFixture(homeTeam, awayTeam);
                        do
                        {
                            Console.Write(INDENTED_TAB, "", $"{homeTeam}: ");
                            string input = Console.ReadLine();
                            isValid = IsPresent(input, "Goals") && IsPostiveInt(input, "Goals");
                            if (isValid)
                            {
                                goalFor = Convert.ToInt32(input);
                                do
                                {
                                    Console.Write(INDENTED_TAB, "", $"{awayTeam}: ");
                                    input = Console.ReadLine();
                                    isValid = IsPresent(input, "Goals") && IsPostiveInt(input, "Goals");
                                    if (isValid)
                                    {
                                        goalAgainst = Convert.ToInt32(input);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n[SUCCESS]: Result Added\n");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                } while (!isValid);
                                //while (away score !valid)
                            }//END: if(home == valid)

                            teams[i].AddMatchResult(goalFor, goalAgainst);
                            //teams[j].AddMatchResult(goalAgainst, goalFor);  //use to add both home and away stats (may not need this

                        } while (!isValid);

                    }//END: if(teams not the same)
                }//END: (for awayteams)                
            }//END: for(homeTeams
        }//END: GetScore()

        /// <summary>
        /// Method displays the current fixture being entered.
        /// </summary>
        /// <param name="homeTeam"></param>
        /// <param name="awayTeam"></param>
        private static void DisplayCurrenFixture(string homeTeam, string awayTeam)
        {
            Console.WriteLine(INDENTED_TAB, "", $"\n{homeTeam} vs {awayTeam}");
            Console.WriteLine(INDENTED_TAB, "", DIVIDER);
            Console.WriteLine(INDENTED_TAB, "", "Enter Score:");
        }

        /// <summary>
        /// Method displays the list oof teams in the league and asks user to select one
        /// </summary>
        /// <returns>The team number of a team in the league</returns>
        private static int GetTeamIndex(Team[] teams)
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
                validChoice = IsPresent(input, "Team Name") && int.TryParse(input, out teamNum);
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
            Console.Clear();
            Console.WriteLine(INDENTED_TAB, "", DIVIDER);
            Console.WriteLine(INDENTED_TAB, "", "Currently entered teams");
            Console.WriteLine(INDENTED_TAB, "",DIVIDER);
            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine(INDENTED_TAB, "", $"{i + 1}. " +  teams[i].Name);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method displays the main menu options
        /// </summary>
        /// <returns>A string of valid menu choice</returns>
        private static string PrintMainMenu()
        {
            bool isValid;
            string choice; 
            do
            {
                Console.Clear();
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "MAIN MENU");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Add Results");
                Console.WriteLine(INDENTED_TAB, "", "2. View League Table");
                Console.WriteLine(INDENTED_TAB, "", "3. Modify Entered Teams");
                Console.WriteLine(INDENTED_TAB, "", "4. Back to League Type Selection ");
                Console.WriteLine("\n");
                Console.Write(INDENTED_TAB, "", "Select option: ");
                choice = Console.ReadLine();
                isValid = ValidateInput(choice, 1, 4);
            } while (!isValid);

            return choice;
        }//END: PrintMainMenu()

        /// <summary>
        /// Method prompts the user to enter teams to compete in the league
        /// </summary>
        /// <returns>A validated string for league choice</returns>
        private static string DecideLeagueAge(ref bool validChoice)
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "What type of League do you want to create?");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Senior League");
                Console.WriteLine(INDENTED_TAB, "", "2. Junior League");
                Console.WriteLine(INDENTED_TAB, "", "3. Exit\n");
                Console.Write(INDENTED_TAB, "", "Choice: ");
                input = Console.ReadLine();
                validChoice = ValidateInput(input, 1, 3);
            } while (!validChoice);

            return input;
        }//END: DecideLeagueAge()


        /*---------------   NOTIFICATION METHODS    ---------------*/

        /// <summary>
        /// Prints a message that the action was successful. Takes a message string as param 
        /// </summary>
        /// <param name="msg"></param>
        private static void PrintSuccessMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            SleepAndClear(2000);
        }

        /// <summary>
        /// Prints a color-coded error message to console window. Takes the string to display as message as param.
        /// </summary>
        /// <param name="msg"></param>
        private static void PrintErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            SleepAndClear(3000);
        }

        /// <summary>
        /// Sleeps for a given time in milliseconds, then clears the console window
        /// </summary>
        /// <param name="time"></param>
        private static void SleepAndClear(int time)
        {
            Thread.Sleep(time);
            Console.Clear();
        }


        /// <summary>
        /// Method prints a message informing user that application is closing
        /// </summary>
        private static void PrintExitMsg()
        {
            Console.WriteLine("\n" + DIVIDER);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Closing program");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + DIVIDER);
        }//END: PrintExitMsg()

        /// <summary>
        /// Method prints a message informing user that application is returning to start menu
        /// </summary>
        private static void PrintExitMsg(string msg)
        {
            Console.WriteLine("\n" + DIVIDER);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(msg);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n" + DIVIDER);
        }//END: PrintExitMsg()


        /*---------------   VALIDATION METHODS  ---------------*/

        /// <summary>
        /// Method check if the passed string argument id an empty string
        /// Takes 1 parameter no overloads
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if string is not empty, or false if it is</returns>
        private static bool IsPresent(string input, string inputLabel)
        {
            if (input != String.Empty)
                return true;            
            else
            { 
                PrintErrorMsg($"\n[ERROR]: {inputLabel} cannot be blank\n");
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

            bool isValid = intChoice >= minValue && intChoice <= maxValue ? true : false;
            
            if(!isValid)
                PrintErrorMsg($"\n[ERROR]: {inputLabel} must be a number between {minValue} & {maxValue}\n");

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
            bool isPositive = false;

            if (int.TryParse(textIn, out int num) == true)
            {
                isPositive = num >= 0 ? true : false;
                if(!isPositive)
                    PrintErrorMsg($"\n[ERROR]: {inputLabel} must be a number greater than zero.\n");
            }

            else
                PrintErrorMsg($"\n[ERROR]: {inputLabel} must be a number.\n");

            return isPositive;
        }//END:  IsInt()

        /// <summary>
        /// Method checks if a string is numeric only
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputLabel"></param>
        /// <returns>Returns true if string contains only numeric chars, else returns false</returns>
        private static bool IsAlpha(string input, string inputLabel)
        {
            string letter = "";
 
            for (int i = 0; i < input.Length; i++)
            {
                letter = Convert.ToString(input[i]);
                if (int.TryParse(letter, out int result))
                {
                    PrintErrorMsg($"\n{inputLabel} must not be only numeric.\n");
                    return false;
                }
            }

            return true;

        }//END: IsNumeric()

        /// <summary>
        /// Method calls validation methods that check that an input string is not null / empty & is a positve number & is within a given range
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if all tsts are passes, else returns false</returns>
        private static bool ValidateInput(string input, int minRange, int maxRange)
        {
            return IsPresent(input, "Choice") && IsPostiveInt(input, "Choice") && IsInRange(input, "Choice", minRange, maxRange);
        }


    }//END: class Program
}
