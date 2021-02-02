/* ===================================================================
 * Worksheet: |  worksheet3_AdvancedLoops
 * Program:   |  worksheet3_advLoops_q1_speed
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  01/2/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Program that will predict the size of a populations of organisms.
 *            |  The programs should ask for:
 *            |     - the starting number of organisms,
 *            |     - their average daily population increase as a percentage
 *            |     - the number of days they will multiply.  
 *            |  For example a population might begin with two, have a daily
 *            |  increase of 50%, and will be allowed to multiply for 7 days.
 *            |  The program should use a loop to show the size of the
 *            |  population for each day.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/

using System;

namespace workdheet3_advLoops_q3_organisms
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            int initialOrganism = 0, days = 0;            
            double pct = 0, finalOrganisms = 0;
            
            // prompt user for inputs
            Console.Write("Enter a number of organisms  :  ");
            initialOrganism = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the percentage rate of increase  :  ");
            pct = double.Parse(Console.ReadLine());
            pct /= 100; 

            Console.Write("Enter the number of days  :  ");
            days = Convert.ToInt32(Console.ReadLine());

            // llop for number of days entered by user
            for (int i = 1; i < days; i++)
            {
                if (i == 1)
                {
                    // for the first day accumulate from initial organism vaue
                    finalOrganisms += initialOrganism * (1 + pct);
                }
                else if (i > 1)           
                {                   
                    // for all iterations after day1 acuumulate onto subtotalled value
                    finalOrganisms += finalOrganisms * (1 + pct);
                }                    
            }

            // display the final amount of organisms
            Console.WriteLine($"After {days} days, multiplyin at a rate of {pct:p2} " +
                $"there will be {finalOrganisms} organisms");
            
            
        }
    }
}
