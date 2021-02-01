/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Q5. Write a program to read in 5 integer values and output 
 *            |      their average, the smallest number entered and the largest 
 *            |      number entered.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/



using System;

using System.Linq;

namespace q5_avg_min_max
{
    class Program
    {

        // declare class level(public) array
        static public int[] NumberArray = new int[5];
        static public int len = NumberArray.Length;

        static void Main(string[] args)
        {
            // Get user to populate the array with 5 numbers
            PopulateArray();

            /*   -  implemented using user defined methods
            int min = NumberArray.Min();
            int max = NumberArray.Max();
            double avg = NumberArray.Average();
            */

            // find the minimun value in the array
            int minValue = CalculateMin();

            // find the Max value in the array
            int maxValue = CalculateMax();

            // find the average of values in the array
            double avgValue = CalculateAvg();

            // display min, max and average values in the array
            DisplayArrayStats(minValue, maxValue, avgValue);

        } // end of Main()



        /********** User Defined Methods *************/

        // Method to populate the array
        static public void PopulateArray()
        {
            int num = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter a number : ");
                num = int.Parse(Console.ReadLine());
                NumberArray[i] = num;                
            }
        }
       

        // methid to Calculate min value in array
        static public int CalculateMin()
        {
            int min = NumberArray[0];
            for (int i = 0; i < len; i++)
            {
                if (NumberArray[i] < min) 
                {                    
                    min = NumberArray[i]; 
                }
            }
            return min;
        } // end of CalculateMin()
        

        // method to Calculate max value in array
        static public int CalculateMax()
        {
            int max = 0;
            // find the Max value in the array
            for (int i = 0; i < len; i++)
            {
                if (NumberArray[i] > max) { max = NumberArray[i]; }
            }
            return max;
        }  // end of CalculateMax()


        // methid to Calculate average of values in array
        static public double CalculateAvg()
        {
            // find the average of values in the array
            int total = 0;
            double avg = 0;
            for (int i = 0; i < len; i++) 
            { 
                total += NumberArray[i];
            }
            avg = total / len;

            return avg;
        } // end of CalculateAvg()


        // method to diplay array stats
        static public void DisplayArrayStats(int minValue, int maxValue, double avgValue)
        {
            // display the min, max and avg values in the array
            Console.WriteLine($"\nMinimum : {minValue}");
            Console.WriteLine($"Maximum : {maxValue}");
            Console.WriteLine($"Average : {avgValue}");
        } // end of DisplayArrayStats()

    }
}
