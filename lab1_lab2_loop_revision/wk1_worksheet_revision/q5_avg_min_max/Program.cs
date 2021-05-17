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
        static void Main(string[] args)
        {
            int[] NumberArray = new int[5];            

            // Get user to populate the array with 5 numbers
            PopulateArray(NumberArray);           

            // display min, max and average values in the array
            DisplayArrayStats(NumberArray);

        } // end of Main()


        /********** User Defined Methods *************/

        // Method to populate the array
        static public void PopulateArray(int[] NumberArray)
        {
            int num;
            string input;

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter a number : ");
                input = Console.ReadLine();
                if (int.TryParse(input, out num))                
                    NumberArray[i] = num;                
            }
        }
       

        // methid to Calculate min value in array
        static public int CalculateMin(int[] NumberArray)
        {
            int min = NumberArray[0];
            int len = NumberArray.Length;

            for (int i = 0; i < len; i++)
            {
                if (NumberArray[i] < min)                    
                    min = NumberArray[i];                 
            }
            return min;
        } // end of CalculateMin()
        

        // method to Calculate max value in array
        static public int CalculateMax(int[] NumberArray)
        {
            int max = 0;
            int len = NumberArray.Length;

            // find the Max value in the array
            for (int i = 0; i < len; i++)
            {
                if (NumberArray[i] > max) 
                    max = NumberArray[i];
            }
            return max;
        }  // end of CalculateMax()


        // methid to Calculate average of values in array
        static public double CalculateAvg(int[] NumberArray)
        {
            // find the average of values in the array
            int total = 0;
            int len = NumberArray.Length;

            for (int i = 0; i < len; i++)              
                total += NumberArray[i];            

            return total / len; 
        } // end of CalculateAvg()


        // method to diplay array stats
        static public void DisplayArrayStats(int[] NumberArray)
        {
            // display the min, max and avg values in the array
            Console.WriteLine($"\nMinimum : {CalculateMin(NumberArray)}");
            Console.WriteLine($"Maximum : {CalculateMax(NumberArray)}");
            Console.WriteLine($"Average : {CalculateAvg(NumberArray)}");
        } // end of DisplayArrayStats()

    }
}
