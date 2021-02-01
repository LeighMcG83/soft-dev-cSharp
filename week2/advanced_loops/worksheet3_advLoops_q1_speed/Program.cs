/* ===================================================================
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
        // Declare class level input / output tables
        const string INPUTTAB = "{0, -35}{1, 10}";
        const string OUTPUTTAB = "{0, -10}{1, -15}";


        static void Main(string[] args)
        {
            bool isValid = true;
            double speed = 0, time = 0, distance = 0;
            try
            {
                Console.WriteLine($"Enter the vehicle speed", ": ");
                speed = Convert.ToDouble(Console.ReadLine());                
            }
            catch (Exception)
            {
                isValid = false;
                Console.WriteLine("Invalid Entry. Speed must be a number greater than 0"); 
            }
            
            if (isValid)
            {
                try
                {
                    Console.WriteLine($"Enter the time travelled in hours", ": ");
                    time = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)               
                {
                    Console.WriteLine("Invalid Entry. Speed must be a number greater than 0;"); 
                }
                distance = speed * time;
                    

                //Console.WriteLine($"Travelling at {speed}km/h for {time} hours will het you {distance}kms.");
            }


        }
    }
}
