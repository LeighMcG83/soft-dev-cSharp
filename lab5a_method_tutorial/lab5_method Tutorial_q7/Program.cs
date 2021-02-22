/* ===================================================================
 * Worksheet: |  Lab5_workseet methods & arrays
 * Program:   |  lab5_method_Tutorial_q7
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  7.Write a method that returns the string str repeated n times:
 *            |     static string Repeat(string str, int n)
 *            |  For example:
 *            |     Repeat(“Joe”,4) returns “JoeJoeJoeJoe
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * BUGS:      |  
 * ===================================================================*/

using System;
using System.Text;

namespace lab5_method_Tutorial_q7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a word: ");
            string str = Console.ReadLine();
            Console.WriteLine("Enter a number of times to repeat: ");
            int repeats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine(ParrotString(str, repeats));

        } // END: Main()

        // Method takes a string and a numberas args and repeats the string, 'number' times
        static string ParrotString(string str, int repeats)
        {
            string repeatedString = "";
            for (int i = 0; i < repeats; i++)
            {
                repeatedString += str;
            }
            return repeatedString;
        }
        /*
         * Q1. OUTPUT: 25, 5. 25, 25
         * 
         * Q2. OUTPUT: 10 8 6 4 2(space)
         * 
         * Q3. OUTPUT: 15 226 3375
         * 
         * Q4. OUTPUT: 100 70.7 100 70.7(space)
         * 
         * Q5. OUTPUT: 35
         * 
         * Q6. OUTPUT: ERROR - " missing from 2nd element of array in declaration
         */
    }
}