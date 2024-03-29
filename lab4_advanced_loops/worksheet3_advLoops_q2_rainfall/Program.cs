﻿/* =======================================================================
 * Worksheet: |  worksheet3_AdvancedLoops
 * Program:   |  worksheet3_advLoops_q2_rainfall
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  03/2/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Program that uses nested loops to:
 *            |     - collect rainfall data
 *            |     - calculate the average rainfall over a period of years. 
 *            |  The program will:
 *            |     - ask for the number of years.
 *            |     - The outer loop will iterate once for each year.
 *            |     - The inner loop will iterate 12 times, once for each month.
 *            |  Each iteration of the inner loop will ask the user for
 *            |  the inches of rainfall for that month. 
 *            |
 *            |  After all iteration, the program should display:
 *            |     - the number of months
 *            |     - the total inches of rainfall
 *            |     - the average rainfall per month for the entire period.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/

using System;

namespace worksheet3_advLoops_q2_rainfall
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare and initialise constants for format tables 
            const string INPUTTAB = "{0, 25}{1, -5}";

            // declare and initialize constant for program title.
            const string PROG_TITLE = "--------- Monthly & Annual Rainfall Calculator ----------";

            // declare variables
            double subtotalRain = 0;
            int years;

            Console.WriteLine(PROG_TITLE);
            
            do
            {
                Console.Write(INPUTTAB, "Enter number of years to enter rainfall for", ": ");
                string input = Console.ReadLine();
                years = int.TryParse(input, out years) ? years = int.Parse(input) : -1;
            } while (years == -1);

            // Test- check datatype of years
            //Console.WriteLine(years.GetType());                   

            int months = years * 12;                                    // calculate the number of months           

            for (int i = 1; i <= years; i++)
            {
                // inner for-loop loops while < number of months
                for (int monthNumber = 1; monthNumber <= months; monthNumber++)
                {
                    double monthlyRain;
                    do
                    {
                        Console.Write(INPUTTAB, $"Enter {GetMonthName(monthNumber, years)}'s rainfall in inches", ": ");
                        string input = Console.ReadLine();
                        monthlyRain = double.TryParse(input, out monthlyRain) ? monthlyRain = double.Parse(input) : -1;
                    } while (monthlyRain == -1);

                    // accumulate monthly rainfall
                    subtotalRain += monthlyRain;

                    // display monthly rainfall
                    Console.WriteLine($"\nThe rainfall for {GetMonthName(monthNumber, years)} is {monthlyRain}");

                    // display the cuurent month number and get the name from method
                    Console.WriteLine($"The month number is {monthNumber}\n");

                } // END: inner for()

            } // END: outer for()

            double avgRain = subtotalRain / months;
            double yearlyRain = subtotalRain / years;

            DisplayResults(months, yearlyRain, avgRain, subtotalRain);

        }// END: Main()

        private static void DisplayResults(int months, double yearlyRain, double avgRain, double subtotalRain)
        {
            Console.WriteLine($"The number of months was {months}");                            
            Console.WriteLine($"Tha average rainfall per month was {avgRain:f2} inches");      
            Console.WriteLine($"Tha average rainfall per year was {yearlyRain:f2} inches");     
            Console.WriteLine($"The total rainfall over {months} months was {subtotalRain} inches");
        }

        // Method to get the name of the month
        static public string GetMonthName(int monthNumber, int years)
        {            
            string month = "";               

            if (monthNumber > 12)            // if the month number passed is in 2nd, 3rd, 4th etc. year             
                monthNumber -= (12 * years); // will reset to a number < 12. i.e month 13 == January            
           
            // checj the number of the month and assign its name to 'month'
            switch (monthNumber)
            {
                case 1: month = "January"; break;
                case 2: month = "February"; break;
                case 3: month = "March";break;
                case 4: month = "April"; break;
                case 5: month = "May"; break;
                case 6: month = "June"; break;
                case 7: month = "July";break;
                case 8: month = "August"; break;
                case 9: month = "September";break;
                case 10: month = "October"; break;
                case 11: month = "November";break;
                case 12: month = "December";break;
                default:
                    Console.WriteLine("Error getting month name");
                    break;
            } //END: switch(monthNumber)

            return month;  

        }// END: GetNameMonth()

    } // END: class Program

} // END: namespace
