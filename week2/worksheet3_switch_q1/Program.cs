/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  worksheet3_switch_q1
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  28/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a program using a switch statement to:
 *            |     - determine the day of the week given a day number
 *            |  The user will enter:
 *            |     - number in the range 1-7 
 *            |  Program will output:
 *            |     - the name of the day
 *            |   (1 = Monday, 2 = Tuesday etc)
 *            |  If an invalid day number is entered , signal this with 
 *            |  an error message.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/
using System;

namespace worksheet3_switch_q1
{
    class Program
    {
        static void Main(string[] args)
        {          
            string dayNumber = RequestDayNumber();      // Call method to request number for day of the week
            Console.WriteLine(CheckDay(dayNumber));     // Call method to check the users choice and return the day
            
        } //END: Main()

        
        /********* USER DEFINED METHODS *********/


        //method to request number for day of the week
        static public string RequestDayNumber()
        {            
            Console.Write("Enter a day number  :  ");
            string day = Console.ReadLine();
            return day;            
        }

        // method that checks the day of week and returns appropriate string
        static public string CheckDay(string dayNumber)
        {
            string msg;
            switch (dayNumber)
            {
                case "1": msg = "\nIt is Monday"; break;
                case "2": msg = "\nIt is Tuesday"; break;
                case "3": msg = "\nIt is Wednesday"; break;
                case "4": msg = "\nIt is Thursday"; break;
                case "5": msg = "\nYiipeee!!! It is Friday"; break;
                case "6": msg = "\nIt is Saturday"; break;
                case "7": msg = "\nIt is Sunday"; break;
                default: msg = "\nInvalid day number entered"; break;
            }
            return msg;
        }
    }
}
