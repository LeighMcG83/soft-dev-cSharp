/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Write a program that determined if a user-inputted year
 *            |  is a leap year
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

using System;

namespace Part2_q1_leapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goAgain = true;

            while (goAgain)
            {
                Console.Write("Enter a year  :  ");
                int year = Convert.ToInt32(Console.ReadLine());

                if (year < 1582 && year % 4 == 0)
                {
                    Console.WriteLine($"\n{year} was a leap year");
                }

                else if (year % 100 == 0 &&
                         year % 400 == 0 &&
                         year % 4 == 0)
                { 
                    Console.WriteLine($"\n{year} was a leap year");
                }
                                
                else                 
                    Console.WriteLine($"\n{year} was not a leap year");
                
                Console.Write("\nWould you like to ask again?    : ");
                string response = Console.ReadLine().ToUpper();

                //if(response == "N") { goAgain = false; }
                goAgain = (response == "N") ? false : true;
            }
           

        }
    }
}
