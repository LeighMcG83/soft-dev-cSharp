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
 * BUGS:      | AddMatchResults() in GetScores():  stores match details for every team as if they 
 *            |                                    are the away team
 *            |  Error messaf=ge not printing id home goals is alpha
 *            |  Fix AddTeam()
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
            string leagueAge = "", leagueType = "";
            Team[] teams = new Team[5];
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                leagueAge = DecideLeagueAge(ref validChoice);
                if (validChoice)                
                    leagueType = DecideDefaultOrCustomTeams(ref validChoice);                               
                                
                if (leagueType != QUIT && validChoice)
                {
                    BuildLeagueTable(teams, leagueType);
                    //BuildLeagueTable(teams, leagueType, leagueAge);

                    //main loop
                    while (menuChoice.ToUpper() != QUIT && !validChoice)
                    {
                        menuChoice = PrintMainMenu();

                        switch (menuChoice)
                        {
                            case "1":
                                int selectedTeam = GetTeamIndex(teams);  //return an index for the selected team
                                GetScore(ref goalFor, ref goalAgainst, selectedTeam, teams);
                                validChoice = false;    //reset to loop back into menu
                                break;
                            case "2":
                                PrintLeagueTable(teams);
                                validChoice = false;
                                break;
                            case "3":
                                DisplayTeamNames(teams);
                                leagueType = DecideDefaultOrCustomTeams(ref validChoice);
                                BuildLeagueTable(teams, leagueType);
                                break;
                            case "4":
                                Console.WriteLine("You chose to Exit");
                                validChoice = true;
                                break;
                            default:
                                menuChoice = PrintMainMenu();
                                break;

                        }//END: switch(menuChoice)

                    }//END: while(!Quit && !valid)            
                }//END: if(  )

            } while (leagueAge != "3");

           

            }//END: Main()


        /// <summary>
        /// Method prompts the user to enter teams to compete in the league
        /// </summary>
        /// <returns>A validated string for league choice</returns>
        private static string DecideLeagueAge(ref bool validChoice)
        {
            bool isValid = false;
            string input = "";
            do
            {
                Console.WriteLine(DIVIDER);
                Console.WriteLine("What type of League do you want to create?");
                Console.WriteLine(DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Senior League");
                Console.WriteLine(INDENTED_TAB, "", "2. Junior League");
                Console.WriteLine(INDENTED_TAB, "", "3. Exit\n");
                Console.Write(INDENTED_TAB, "", "Choice: ");
                input = Console.ReadLine();
                isValid = IsPresent(input, "Choice") && IsPostiveInt(input, "Choice") && IsInRange(input, "Choice", 1, 3);
            } while (!isValid);

            return input;
        }//END: DecideLeagueAge()



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
        /// Prints a message that the action was successful. Takes a message string as param 
        /// </summary>
        /// <param name="msg"></param>
        private static void PrintSuccessMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            Console.Clear();
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
        }

        /// <summary>
        /// Method ask the user to use default teams or enter customised team names
        /// </summary>
        /// <returns>A validated string of users' choice/returns>
        private static string DecideDefaultOrCustomTeams(ref bool isValid)
        {
            string input;
            do
            {
                Console.WriteLine(DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "League Teams Setup");
                Console.WriteLine(DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Use Default League");
                Console.WriteLine(INDENTED_TAB, "", "2. Create Custom League");
                Console.WriteLine(INDENTED_TAB, "", "3. Back\n");
                Console.Write(INDENTED_TAB, "", "Choice:");
                input = Console.ReadLine();
                isValid = IsPresent(input, "Choice") && IsPostiveInt(input, "Choice") && IsInRange(input, "Choice", 1, 3);
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
            Console.WriteLine("\n" + DIVIDER);
            Console.WriteLine(INDENTED_TAB, "", "League Table");
            Console.WriteLine(DIVIDER);
            Console.WriteLine(DISPLAY_TAB, "ID", "Team Name", "Pld", "Won", "Drawn", "Lost", "For", "Agst", "+/-", "Pts");

            foreach (var team in teams)            
                Console.WriteLine(team.ToString());

            Console.WriteLine(INDENTED_TAB, "", "\nPress Enter key to return to Main Menu");
            Console.Read();
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
                        Console.Write(INDENTED_TAB, "", "Home: ");
                        string input = Console.ReadLine();
                        isValid = IsPresent(input, "Goals") && IsPostiveInt(input, "Goals");
                        if (isValid)
                        {
                            goalFor = Convert.ToInt32(input);
                            do
                            {
                                Console.Write(INDENTED_TAB, "", "Away: ");
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


                        /* below stores match details for every team as if they are the away team*/

                        //for (int j = 0; j < teams.Length; j++)
                        //{
                        //    if (teams[j] != null && j != (selected - 1) && j != selected)
                        //    {
                        //        teams[j].AddMatchResult(goalAgainst, goalFor);
                        //    }
                            
                        //}
                        

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
            Console.Clear();
            Console.WriteLine(DIVIDER);
            Console.WriteLine(INDENTED_TAB, "", "Currently entered teams");
            Console.WriteLine(DIVIDER);
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
                Console.WriteLine("\n" + DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "MAIN MENU");
                Console.WriteLine(DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Add Results");
                Console.WriteLine(INDENTED_TAB, "", "2. View League Table");
                Console.WriteLine(INDENTED_TAB, "", "3. Modify Entered Teams");
                Console.WriteLine(INDENTED_TAB, "", "4. Exit");
                Console.WriteLine("\n");
                Console.Write(INDENTED_TAB, "", "Select option: ");
                choice = Console.ReadLine();
                isValid = IsPresent(choice, "Menu Choice") && IsPostiveInt(choice, "Menu Choice") && IsInRange(choice, "Menu Choice", 1, 4);

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



    }//END: class Program
}
