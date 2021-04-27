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
 *            |  Add: print league table in descending order (pts, then goal diff)
 * -----------|-----------------------------------------------------------------------------------*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace CA3
{
    class Program
    {
        const string DIVIDER = "---------------------------------------------------------------";
        const string INPUT_TAB = "{0, -35}{1, 5}";
        const string INDENTED_TAB = "{0, 10}{1, -20}";
        const string DISPLAY_TAB = "{0, -5}{1, -20}{2, -5}{3, -5}{4, -5}{5, -5}{6, -5}{7, -5}{8, -5}{9, -5}";
        //static string[] teamNames = { "Rep. of Ireland", "Oman", "Brazil", "Scotland", "England" };  //use file instead
        static JuniorTeam[] juniorTeams = new JuniorTeam[5];
        static Team[] teams = new Team[5];

        const string QUIT = "3";
        const string SENIOR = "1";                 //menu option for senior team league
        const string JUNIOR = "2";

        private const string PATH_TEAM_NAMES = @"./teams.txt";
        private const string PATH_RESULTS = @"./results.txt";

        static void Main(string[] args)
        {
            //setup
            string menuChoice = "";
            bool validChoice = false;
            int goalFor = 0, goalAgainst = 0;       //will take values for each game's score (pass by ref to GetScore())
            string leagueAge = "", leagueType = "";
            FileStream fs;
            StreamReader fileInput;
            string[] teamNames = File.ReadAllLines(PATH_TEAM_NAMES);
            
            for (int i = 0; i < teamNames.Length; i++)
                teams[i] = new Team();

            leagueAge = DecideLeagueAge(ref validChoice);

            if (leagueAge != QUIT)
            {
                try
                {
                    ReadTeamsData(out fs, out fileInput, out teamNames, leagueAge);
                    fileInput.Close();
                    fs.Close();
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"{ex.FileName} not found when attempting to open file");
                }

                do
                {
                    if (leagueAge != QUIT)
                    {
                        leagueType = ChooseDefaultOrCustomTeams(ref validChoice);
                        try
                        {
                            BuildLeagueTable(leagueType, leagueAge, teamNames);
                        }
                        catch (InvalidCastException ex)
                        {
                            //tried an illegal cast with team/juniorteam
                            Console.WriteLine(ex.Message);
                        }
                        catch (NullReferenceException ex)
                        {
                            //tried to access a null object
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            MainMenu(ref menuChoice, ref goalFor, ref goalAgainst);
                        }
                    }//END: if(leagueAge != QUIT)            
                    else
                    {
                        PrintExitMsg();
                        break;
                    }

                } while (leagueAge != QUIT);
            }
            
        }//END: Main()


        /*---------------   FILE HANDLING METHODS    ---------------*/

        /// <summary>
        /// Method opens the names file and creates a Team[] or JuniorTeam[] of objects with the names from the file
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="fileInput"></param>
        /// <param name="teamNames"></param>
        /// <param name="leagueAge"></param>
        private static void ReadTeamsData(out FileStream fs, out StreamReader fileInput, out string[] teamNames, string leagueAge)
        {           
            fs = new FileStream(PATH_TEAM_NAMES, FileMode.Open, FileAccess.Read);
            fileInput = new StreamReader(fs);
            teamNames = File.ReadAllLines(PATH_TEAM_NAMES);

            if (leagueAge == JUNIOR)
            {
                string age = GetAgeGroup();

                for (int i = 0; i < teams.Length; i++)
                    teams[i] = new JuniorTeam(teamNames[i], age);
            }
            else if (leagueAge == SENIOR)
            {
                for (int i = 0; i < teams.Length; i++)
                    teams[i] = new Team(teamNames[i], 0, 0);
            }                   

        }//END: ReadTeamsData()



        /*---------------   LEAGUE SETUP METHODS    ---------------*/

        /// </summary>
        /// <param name="teams"></param>
        /// <param name="leagueType"></param>
        private static void BuildLeagueTable(string leagueType, string leagueAge, string[] names)
        {            
            switch (leagueType)
            {
                case "1":
                    CreateDefaultLeague(leagueAge, names);
                    break;
                case "2":
                    CreateCustomLeague(leagueAge);
                    break;
                default:
                    PrintErrorMsg("\n[ERROR]: Teams setup error.\n");
                    //Console.WriteLine("Closing Program");
                    Thread.Sleep(3000);
                    break;
            }
           
        }//END: BuildLeagueTable()

        /// <summary>
        /// Method ceates a leagefrom predetermind array of teams
        /// </summary>
        /// <param name="teams"></param>
        private static void CreateDefaultLeague(string leagueAge, string[] names)
        {
            //string[] teamNames = { "Rep. of Ireland", "Oman", "Brazil", "Scotland", "England" };

            if (leagueAge == SENIOR)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    teams[i] = new Team();
                    teams[i].Name = names[i];
                }
            }
            else
            {
                for (int i = 0; i < juniorTeams.Length; i++)
                {
                    juniorTeams[i] = new JuniorTeam();
                    juniorTeams[i].Name = names[i];
                }
            }

            PrintSuccessMessage("\n[SUCCESS]: All teams entered in league\n");
        }//END: CreateDefaultLeague()

        /// <summary>
        /// Method creates a league made of user entered teams
        /// </summary>
        /// <param name="teams"></param>
        private static void CreateCustomLeague(string leagueAge)
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
        /// Method prompts user to enter a type of league until a valid input is entered
        /// </summary>
        /// <param name="validChoice"></param>
        /// <param name="type"></param>
        /// <param name="leagueAge"></param>
        private static string ChooseDefaultOrCustomTeams(ref bool validChoice)
        {
            string input;
            bool isValid;
            Console.Clear();
            do
            {
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "League Teams Setup");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Use Default Teams");
                Console.WriteLine(INDENTED_TAB, "", "2. Create Custom League");
                Console.WriteLine(INDENTED_TAB, "", "3. Back\n");
                Console.Write(INDENTED_TAB, "", "Choice: ");
                input = Console.ReadLine();
                isValid = ValidateInput(input, 1, 3);
                
            } while (!isValid && input != QUIT); 
            
            validChoice = isValid;

            return input;
        }


        /// <summary>
        /// Method displays age group menu and gets a valid input
        /// </summary>
        /// <param name="i"></param>
        private static string GetAgeGroup()
        {
            bool isValid;
            string ageGroup;
            string[] ranges = { "", "U10", "U12", "U15", "U18" };        //1st elem empty -> index will == menu choice
            do
            {
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "Select Age Group:");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Under 10's");
                Console.WriteLine(INDENTED_TAB, "", "2. Under 12's");
                Console.WriteLine(INDENTED_TAB, "", "3. Under 15's");
                Console.WriteLine(INDENTED_TAB, "", "4 .Under 18's");
                Console.WriteLine(INDENTED_TAB, "", "5. Back");
                Console.Write(INPUT_TAB, "", "Choice: ");
                ageGroup = Console.ReadLine();
                isValid = ValidateInput(ageGroup, 1, 5);
            } while (!isValid);
            return ranges[Convert.ToInt32(ageGroup)];
        }//END: EnterAgeRange()


        /*---------------   MENU AND PROGRAM FUNCTIONALITY METHODS    ---------------*/

        /// <summary>
        /// Method calls the main Menu, validates menuChoice and calls the chosen menu option.
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <param name="goalFor"></param>
        /// <param name="goalAgainst"></param>
        private static void MainMenu(ref string menuChoice, ref int goalFor, ref int goalAgainst)
        {
            while (menuChoice != QUIT)//REFACTOR ThIS CODE BLOCK INTO METHOD
            {
                menuChoice = PrintMainMenu();

                switch (menuChoice)
                {
                    case "1":
                        GetScores(ref goalFor, ref goalAgainst, teams);
                        break;
                    case "2":
                        PrintLeagueTable(teams);
                        break;
                    case "3":
                        PrintExitMsg("Returning to League Setup");
                        break;
                    default:
                        menuChoice = PrintMainMenu();   //change to an error message???
                        break;

                }//END: switch(menuChoice)

            }//END: while(menuchoice != Quit)   
        }

        /// <summary>
        /// Method gets the score form the user
        /// </summary>
        /// <param name="goalFor"></param>
        /// <param name="goalAgainst"></param>
        /// <param name="teams"></param>
        private static void GetScores(ref int goalFor, ref int goalAgainst, Team[] teams)
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
                            teams[j].AddMatchResult(goalAgainst, goalFor);  //use to add both home and away stats (may not need this
                            FileStream fs = new FileStream(PATH_RESULTS, FileMode.Open, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.WriteLine($"{homeTeam}, {awayTeam}, {goalFor}, {goalAgainst}");

                            /*test print file contents here */


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



        private static void PrintOutTable(Team[] teams)
        {
            FileStream fs = new FileStream(@"D:\DemoFolder\newDirectory\results.csv", FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);
            string lineIn;
            lineIn = inputStream.ReadLine();

            while (lineIn != null)
            {
                string[] myfield = lineIn.Split(',');
                int homeTeamIndex = 0, awayTeamIndex = 0;


                //find home and away index
                for (int i = 0; i < teams.Length; i++)
                {
                    if (teams[i].Name == myfield[0])
                    {
                        homeTeamIndex = i;
                    }
                    if (teams[i].Name == myfield[1])
                    {
                        awayTeamIndex = i;
                    }
                }

                //find home and away index
                int homeIndex = FindIndex(teams, myfield[0]); //home
                int awayIndex = FindIndex(teams, myfield[1]);//away

                teams[homeTeamIndex].Scored = teams[homeTeamIndex].Scored + int.Parse(myfield[2]);
                teams[homeTeamIndex].Conceeded = teams[homeTeamIndex].Conceeded + int.Parse(myfield[3]);
                teams[awayTeamIndex].Scored = teams[awayTeamIndex].Scored + int.Parse(myfield[3]);
                teams[awayTeamIndex].Conceeded = teams[awayTeamIndex].Conceeded + int.Parse(myfield[2]);

                lineIn = inputStream.ReadLine();
            }
        } //End of PrintOutTable



        /// <summary>
        /// Method displays the main menu options
        /// </summary>
        /// <returns>A string of valid menu choice</returns>
        private static string PrintMainMenu()
        {
            bool isValid;
            string choice = " "; 
            do
            {
                Console.Clear();
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "MAIN MENU");
                Console.WriteLine(INDENTED_TAB, "", DIVIDER);
                Console.WriteLine(INDENTED_TAB, "", "1. Add Results");
                Console.WriteLine(INDENTED_TAB, "", "2. View League Table");
                //Console.WriteLine(INDENTED_TAB, "", "3. Modify Entered Teams");
                Console.WriteLine(INDENTED_TAB, "", "3. Back");
                Console.WriteLine("\n");
                Console.Write(INDENTED_TAB, "", "Select option: ");
                choice = Console.ReadLine();
                isValid = ValidateInput(choice, 1, 3);
            } while (!isValid);

            return choice;
        }//END: PrintMainMenu()

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

            for (int i = 0; i < teams.Length; i++)
            {
                Console.WriteLine(teams[i].ToString());
            }

            Console.Write(INDENTED_TAB, "", "\nPress Enter key to return to Main Menu...");
            Console.Read();
        }

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
                Console.WriteLine(INDENTED_TAB, "", "START MENU");
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

        /// <summary>
        /// Method searches the name fields of the arr 
        /// </summary>
        /// <param name=" of teams for a specified namerate"></param>
        /// <param name="taxBands"></param>
        /// <returns>The index of the team in the array if found, else returns -1</returns>
        private static int FindIndex(Team[] teams, string name)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] != null)
                {
                    if (name == teams[i].Name)
                        return i;
                    else
                        PrintErrorMsg($"[ERROR]: {teams[i].Name} was not found in the league");                    
                }
            }
            return -1;
        }//END: FindIndex()



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
        /// Method checks if a string input can be converted to an integer,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// <param name="textIn"></param>
        /// <param name="inputLabel"></param>
        /// <returns>True if the input can be arsed as int, else returns false</returns>
        /// </summary>
        static bool IsInt(string textIn, string inputLabel)
        {
            bool isInt = false;

            if (int.TryParse(textIn, out int num) == true)
            {
                isInt = true;                
            }
            if (!isInt)
                PrintErrorMsg($"\n[ERROR]: {inputLabel} must be a number.\n");

            return isInt;
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
