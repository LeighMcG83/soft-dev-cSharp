/* =======================================================================
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
            const string OUTPUTTAB = "{0, 10]{1, -20}{2, 20}";

            // declare and initialize constant for program title.
            const string PROG_TITLE = "--------- Monthly & Annual Rainfall Calculator ----------";

            // declare variables
            int years = 0, months = 0;
            double monthlyRain = 0, yearlyRain = 0, avgRain = 0, subtotalRain = 0;
            string input;
                        
            Console.WriteLine(PROG_TITLE);                          // write program title to console

            Console.Write(INPUTTAB, "Enter number of years", ": "); // ask user to input number of years
           input = Console.ReadLine();

            // validate user input for years
            int.TryParse(input, out years);                         // try to parse 'input' and assign to years if success                                                              //Console.WriteLine(years.GetType());                     // Test- chect datatype of years

            // calculate the number of months
            months = years * 12;

            // outer for-loop loops while < number of years
            for (int i = 1; i <= years; i++)
            {
                // inner for-loop loops while < number of months
                for (int monthNumber = 1; monthNumber <= months; monthNumber++)
                {
                    // ask for this months rainfall
                    Console.Write(INPUTTAB, "Enter this months rainfall in inches", ": ");
                    input = Console.ReadLine();

                    // validate rainfall
                    double.TryParse(input, out monthlyRain);

                    // accumulate monthly rainfall
                    subtotalRain += monthlyRain;

                    // display monthly rainfall
                    Console.WriteLine($"\nThe rainfall for this month is {monthlyRain}");

                    // display the cuurent month number and get the name from method
                    //Console.WriteLine($"The month number is {monthNumber} ({GetMonthName(monthNumber, years)})");

                    // display the cuurent month number and get the name from method
                    Console.WriteLine($"The month number is {monthNumber}\n");

                } // END: inner for()

            } // END: outer for()
            
            avgRain = subtotalRain / months;                                                 // Calculate the average rainfall            
            yearlyRain = subtotalRain / years;                                               // calculate the avg rain per year

            Console.WriteLine($"The number of months was {months}");                         // Display total number of months
            Console.WriteLine($"Tha average rainfall per month was {avgRain} inches");       // Display the average rainfall per month
            Console.WriteLine($"Tha average rainfall per year was {yearlyRain} inches");     // Display the average rainfall per year
            Console.WriteLine($"The total rainfall over {months} months was {subtotalRain}");// Display the total rainfall

        }// END: Main()

        //*********** USER DEFINED METHODS ************/

        // Method to get the name of the month
        static public string GetMonthName(int monthNumber, int years)
        {            
            string month = "";               // declare and initial ize local variable for month

            if (monthNumber > 12)            // if the month number passed is in 2nd, 3rd, 4th etc. year 
            {
                monthNumber -= (12 * years); // will reset to a number < 12. 
            }
            
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
                    month = "Oops, there was an error calculating the name of the month";
                    break;
            } //END: switch(monthNumber)
            return month;   // returns the name of the month, or a error msg of month number was out of range

        }// END: GetNameMonth()

    } // END: class Program

} // END: namespace
