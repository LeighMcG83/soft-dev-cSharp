/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Write a program to print the pattern. Printing one ‘#’ at a time
 *            |   #
 *            |   # #
 *            |   # # #
 *            |   # # # # 
 *            |   # # # # #
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  Print upside down
 * ===================================================================*/

using System;

namespace Part2_q2_printPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // set number of rows
            int rows = 5;

            /* Print:
             * #
             * ##
             * ###
             * ####
             * #####
            */
        
            // start loop at line 1, i.e. i=1
            for (int i = 1; i <= rows; i++)
            {
                // start loop at column 1, i.e. j=1
                // loop while column no.  <= row no.
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine("\n");
            } // end of forLoop 1


            Console.WriteLine("\n\n\n");

            /* Print:
             * #####
             * ####
             * ###
             * ##
             * #
            */

            // start loop at line 1, i.e. i=1
            for (int i = 1; i <= rows; i++)
            {
                // start loop with columns = 5, will print '#' 5 times before '\n'
                // loop while column no. >= num of rows specified
                for (int j = rows; j >= i; j--)
                {
                    Console.Write("#");
                }
                Console.WriteLine("\n");
            } // end of forLoop 2

        } // end of Main()

    } // end of class Program

} // end of namespace
