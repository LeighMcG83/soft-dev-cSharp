﻿/* ===================================================================
 * Worksheet: |  worksheet3_AdvancedLoops
 * Program:   |  worksheet3_advLoops_q1_speed
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  01/2/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Program that asks for:
 *            |     - the speed of a vehicle
 *            |     - the number of hours it has travelled.
 *            |  It uses a loop to display the distance the vehicle has 
 *            |  travelled for each hour of the time period specified by
 *            |  the user. 
 *            |  Sample Output:
 *            |     Hour	Distance Travelled
 *            |     1   	40
 *            |     2   	80
 *            |     3   	120
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace worksheet3_advLoops_q1_speed
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INPUTTAB = "{0, -35}{1, 10}";
            const string OUTPUTTAB = "{0, -10}{1, -15}";

            // declare variables
            bool isValid = true;
            int speed = 0, distance = 0;
            int distPerHr = 0, hours = 0;

            do
            {
                try
                {
                    Console.Write(INPUTTAB, $"Enter the vehicle speed", ": ");     // ask user for the speed and convert to an int
                    speed = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    isValid = false;                                         // set isValid to false when the speed input is invalid
                    Console.WriteLine("Invalid Entry. Speed must be a number greater than 0");
                } // END: try-catch - speed input
            } while (!isValid);

            do
            {
                try
                {
                    Console.Write(INPUTTAB, $"Enter the time travelled in hours", ": ");
                    hours = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    isValid = false;
                    Console.WriteLine("Invalid Entry. Speed must be a number greater than 0;");
                } // END; try-catch - time input
            } while (!isValid);
            
            distPerHr = CalculateDistance(speed, distance, distPerHr, hours);
            Console.WriteLine(OUTPUTTAB, "Hour", "Distance Travelled");

            /* for will loop while the counter is less than the number of hours.
             * increment distPerHr to accumulate the distance on each iteration
             * */
            for (int i = 1; i <= hours; i++)            
                distance += distPerHr;
            
            Console.WriteLine(OUTPUTTAB, $"{hours}", $"{distance}"); 
                
        } // END: Main()

        private static int CalculateDistance(int speed, int distance, int distPerHr, int hours)
        {
            distance = speed * hours;                                    // calculate total distance
            distPerHr = Convert.ToInt32(distance / hours);               // calculate distance travelled per hour            
            return distPerHr;
        }

    } // End: class Program
}
