/* ==============================================================================================
 * Worksheet: |  CA3 Example 2
 * Program:   |  eurostat.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  22/4/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a program to use the data in this file to write two reports 
 *            |  
 *            |  Trend Report(): Enables a user to enter a country and get the figures for the four years 
 *            |  
 *            |  Comparative  Poverty Risk Report for the three countries. 
 *            |  This should calculate the average poverty risk for each country over the four years
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/

using System;
using System.Collections.Generic;
using System.IO;
//using static DataValidationLibrary;

namespace eurostat
{
    class Program
    {
        static readonly string[] countries = { "Denmark", "Ireland", "Greece" };
        static readonly string MENU_TAB = "{0,10}{1,5}";
        static readonly string DIVIDER = "-------------";
        const string PATH = @"./eurostat.csv";
        //static FileStream sr;
        static bool isValid = false;


        static void Main(string[] args)
        {         
            int count = 0;
            bool validInput = false;
            string menuChoice = "";
            List<RiskStat> risksList = new List<RiskStat>();

            //open file and read fields to object[]
            try
            {
                CreateStreamAndReader(PATH, out StreamReader sr, out string lineFromFile);
                CreateObjListFromFile(ref count, risksList, sr, ref lineFromFile);
                sr.Close();

                //testprint
                Console.WriteLine("Objects read from file");
                TestPrintObjList(risksList);

            }//END: try{} 

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //get valid menu choice and use switch to call correct method()
            do
            {
                menuChoice = GetValidMainMenuChoice(MENU_TAB, ref validInput); //pass validInput by ref to evaluate next if()
                if (validInput)
                {
                    //ActivateMenuChoice(menuChoice, risksList, ref isValid);  
                    //contains same code as switch(menuChoice)
                    switch (menuChoice)
                    {
                        case "1":
                            do
                            {
                                menuChoice = GetValidCountryChoice(MENU_TAB, ref isValid);
                            } while (!isValid && menuChoice != "4");

                            int countryIndex = GetCountryChoice(menuChoice, countries);
                            DisplayTrendTable(countryIndex, countries, risksList);
                            break;
                        case "2":
                            Console.WriteLine($"Option {menuChoice} chosen - 2");
                            double averageRisk = 0;

                            try
                            {
                                Console.WriteLine($"{"Country",-10}{"Average Poverty Risk",20}");
                                for (int i = 0; i < risksList.Count; i++)
                                {
                                    for (int j = 0; j < countries.Length; i++)
                                    {
                                        if (risksList[i] != null)
                                        {
                                            if (risksList[i].Country == countries[j])

                                                averageRisk += risksList[j].RiskLevel;
                                        }
                                    }

                                    Console.WriteLine($"{risksList[i].Country,-10}{(double)0,20}");
                                }
                               
                                averageRisk /= risksList.Count;
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        case "3":
                            Console.WriteLine($"Option {menuChoice} chosen - 3 To Quit");
                            break;
                        default:
                            Console.WriteLine($"Option {menuChoice} not found");
                            break;
                    }
                }//END: if(!valid)

            } while (!validInput && menuChoice != "3");






        }//END: Main()


        /// <summary>
        /// Method creates FileStream and StreamReader objects to a passed in file path
        /// </summary>
        /// <param name="PATH"></param>
        /// <param name="sr"></param>
        /// <param name="lineFromFile"></param>
        private static void CreateStreamAndReader(string PATH, out StreamReader sr, out string lineFromFile)
        {
            FileStream fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            lineFromFile = sr.ReadLine();
        }


        /// <summary>
        /// Method displays the menu until useer enters valid choice
        /// </summary>
        /// <param name="TAB"></param>
        /// <param name="OPTIONS"></param>
        /// <param name="isValid"></param>
        /// <returns>true a calidated string menu choice </returns>
        private static string GetValidMenuChoice(string TAB, ref bool isValid)
        {
            isValid = false;
            string menuChoice;
            do
            {
                GetValidMainMenuChoice(TAB, ref isValid);
                menuChoice = Console.ReadLine();
                isValid = ValidateMainMenuChoice(menuChoice, 1, 3);
            } while (!isValid);
            return menuChoice;
        }


        /// <summary>
        /// Method switches on a menu choice and calls chosen method
        /// </summary>
        /// <param name="menuChoice"></param>
        private static void ActivateMenuChoice(string menuChoice, List<RiskStat> risks, ref bool isValid)
        {
            switch (menuChoice)
            {
                case "1":
                    menuChoice = "";
                    int countryIndex = 0;
                    do
                    {
                        do
                        {
                            menuChoice = GetValidCountryChoice(MENU_TAB, ref isValid);
                        } while (!isValid && menuChoice != "4");

                        if (isValid && menuChoice != "4")
                        {
                            countryIndex = GetCountryChoice(menuChoice, countries);
                            DisplayTrendTable(countryIndex, countries, risks);
                        }
                    } while (menuChoice != "4");

                    break;
                case "2":
                    Console.WriteLine($"Option {menuChoice} chose - 2");
                    break;
                case "3":
                    Console.WriteLine($"Option {menuChoice} chosen - 3 To Quit");
                    break;
                default:
                    Console.WriteLine($"Option {menuChoice} not found");
                    break;
            }
        }



        private static void GetValidCountryPrintTrend(List<RiskStat> risks, ref bool isValid)
        {
            string menuChoice;
            int countryIndex = 0;
            do
            {
                menuChoice = GetValidCountryChoice(MENU_TAB, ref isValid);
            } while (!isValid && menuChoice != "4");

            if (isValid && menuChoice != "4")
            {
                countryIndex = GetCountryChoice(menuChoice, countries);
                DisplayTrendTable(countryIndex, countries, risks);
            }
            //testprint
            //Console.WriteLine("Country Index: {0}", countryIndex);
        }

        /// <summary>
        /// Method searches an object list for the name os a passed string name
        /// </summary>
        /// <param name="countries"></param>
        /// <param name="risks"></param>
        /// <returns>The index of the name in the list of objs, else returns -1</returns>
        private static int GetCountryChoice(string input, string[] countries)
        {
            for (int i = 0; i < countries.Length; i++)
            {
                if (countries[i] == countries[Convert.ToInt32(input) - 1])
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// Method displays the trends for all years for a given country
        /// </summary>
        /// <param name="countryIndex"></param>
        /// <param name="countries"></param>
        /// <param name="risks"></param>
        private static void DisplayTrendTable(int countryIndex, string[] countries, List<RiskStat> risks)
        {
            string country = countries[countryIndex];

            try
            {
                for (int i = 0; i < risks.Count; i++)
                {
                    if (risks[i].Country == country)
                    {
                        //add pele to pele
                        Console.WriteLine($"{risks[i].Year,15}{risks[i].RiskLevel,15}");
                    }
                }
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range when looping through values List<RiskStat> risks. Block: line 178");
            }

            //try
            //{
            //    Console.WriteLine("{0, 15}{1, 15}", ctry, "Trend Report");
            //    CreateStreamAndReader(PATH, out StreamReader sr, out string line);
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine(ex.Message + "\n{ERROR: file not found in DisplayTrendTable");
            //}

        }//END: Main()


        /// <summary>
        /// Method calls validation methods to validate the passed menu choice. 
        /// Takes param for the string input to validate.
        /// Takes int params for the lower and upper range of acceptable menu choice
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <returns></returns>
        private static bool ValidateMainMenuChoice(string menuChoice, int minRange, int maxRange)
        {
            return IsPresent(menuChoice, "[MENU CHOICE]") && IsInteger(menuChoice, "[MENU CHOICE]") && IsWithInRange(menuChoice, "[MENU CHOICE]", minRange, maxRange);
        }


        /// <summary>
        /// Method gets a validated choice for a country to view from the user
        /// </summary>
        /// <param name="MENU_TAB"></param>
        /// <returns>A validated string input</returns>
        private static string GetValidCountryChoice(string MENU_TAB, ref bool isValid)
        {
            string input;
            do
            {
                Console.WriteLine(MENU_TAB, "", DIVIDER);
                Console.WriteLine(MENU_TAB, "", "CHOOSE COUNTRY");
                Console.WriteLine(MENU_TAB, "", DIVIDER);
                Console.WriteLine(MENU_TAB, "", "1. DENMARK");
                Console.WriteLine(MENU_TAB, "", "2. IRELAND");
                Console.WriteLine(MENU_TAB, "", "3. GREECE");
                Console.WriteLine(MENU_TAB, "", "4. BACK");
                Console.WriteLine();
                Console.Write(MENU_TAB, "", "Choice: ");
                input = Console.ReadLine();
                isValid = ValidateMainMenuChoice(input, 1, 4);
            } while (!isValid);

            return input;

        }

        /// <summary>
        /// Method gets a valid menu choice from the user, loops until valid input received
        /// </summary>
        /// <param name="MENU_TAB"></param>
        /// <returns>A validated string input</returns>
        private static string GetValidMainMenuChoice(string MENU_TAB, ref bool isValid)
        {
            string input;
            do
            {
                Console.WriteLine(MENU_TAB, "", DIVIDER);
                Console.WriteLine(MENU_TAB, "", "MAIN MENU");
                Console.WriteLine(MENU_TAB, "", DIVIDER);
                Console.WriteLine(MENU_TAB, "", "1. VIEW TREND REPORT");
                Console.WriteLine(MENU_TAB, "", "2. CPR REPORT");
                Console.WriteLine(MENU_TAB, "", "3. EXIT\n");
                Console.Write(MENU_TAB, "", "Choice: ");
                input = Console.ReadLine();
                isValid = ValidateMainMenuChoice(input, 1, 3);
            } while (!isValid);
            return input;
        }

        /// <summary>
        /// Method creates an object from each line of a file passed to it and adds that obj to a List of type RiskStat
        /// </summary>
        /// <param name="count"></param>
        /// <param name="risksList"></param>
        /// <param name="sr"></param>
        /// <param name="lineFromFile"></param>
        private static void CreateObjListFromFile(ref int count, List<RiskStat> risksList, StreamReader sr, ref string lineFromFile)
        {
            while (lineFromFile != null)
            {
                string[] fields = lineFromFile.Split(',');
                if (fields.Length == 3)
                {
                    count++;    //used to count number of lines in file
                    if (int.TryParse(fields[0], out int year) && double.TryParse(fields[2], out double stat))
                    {
                        RiskStat risk = new RiskStat(year, fields[1], stat);
                        risksList.Add(risk);
                    }
                }
                else
                {
                    Console.WriteLine("Error - reading line from file line{0}: {1}", count, lineFromFile);
                }

                lineFromFile = sr.ReadLine();
            }//END: while(line !null)
        }//END: CreateObjListFromFile()


        /// <summary>
        /// Method prints all objects in the list passed to it
        /// </summary>
        /// <param name="risksList"></param>
        private static void TestPrintObjList(List<RiskStat> risksList)
        {
            foreach (var risk in risksList)
                Console.WriteLine(risk.ToString());

        }

        /// <summary>
        /// Method opens and reads all lines of a text file at a filepath passed as param
        /// </summary>
        /// <param name="path"></param>
        private static void ReadAllLines(string path, FileStream fs, StreamReader sr, string[] lines)
        {
            CreateStreamAndReader(path, out sr, out string line);
            string lineIn = sr.ReadLine(); // read in first line from file

            while (lineIn != null) // null signals we are end of the file
            {
                for (int i = 0; i < lines.Length; i++)
                    lines[i] = sr.ReadLine();
            }
            sr.Close();
        }


        /// <summary>
        /// Method takes a string as a param and searches an object[] for the string. 
        /// </summary>
        /// <param name="myField"></param>
        /// <param name="teams"></param>
        /// <returns>The index if the name was found in the array, else returns -1</returns>
        private static int FindIndex(string name, Object[] objArr)
        {
            for (int i = 0; i < objArr.Length; i++)
            {
                //if (name == objArr[i].Name)
                //{
                //    return i;
                //}
            }
            return -1;
        }


        static public bool IsInteger(string textIn, string name)
        {
            //int num;

            if (int.TryParse(textIn, out int num))
                return true;
            else
            {
                Console.WriteLine("{0} must be of type integer", name);

                return false;
            }


        }


        /// Method takes a string and checks if it is of a valid len, which is also passedas an arg.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="len"></param>
        /// <returns>True id length is correct, or else prints appropriate message to user and returns false</returns>
        private static bool IsValidLen(string input, int len)
        {
            if (input.Length == len)
                return true;
            else
            {
                Console.WriteLine($"{input} should be {len} chars long.");
                return false;
            }
        }//END: ISValidLen()


        static public bool IsPresent(string textIn, string name)
        {
            if (textIn == "")
            {
                Console.WriteLine("{0} must be present", name);
                return false;
            }
            else
                return true;

        }


        static public bool IsWithInRange(string textIn, string name, int min, int max)
        {
            int number = int.Parse(textIn);
            if (number < min || number > max)
            {
                Console.WriteLine("{0} must be within range {1} and{2}", name, min, max);
                return false;
            }
            else
                return true;
        }

    }//END: class Program
}
