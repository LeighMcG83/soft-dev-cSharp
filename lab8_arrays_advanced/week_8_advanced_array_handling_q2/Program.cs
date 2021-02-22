/* ===================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_8_advanced_array_handling_q2
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  17/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Generate an array of 10,000 random numbers from zero to four. 
 *            | 
 *            |  Report the percentage of each of the numbers,
 *            |  zero, one, two, three and four in the array
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |         Refactor into methods
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  2d array approach going out of bounds when ncrementing 
 *            |  the number of occurances of each number in switch
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace week_8_advanced_array_handling_q2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bigArray = new int[10000];
            int length = bigArray.Length;

            Random randomNum = new Random();        // create a Random() object

            Write("Populating the array with 10,000 numbers");
            for (int i = 0; i < 5; i++)
            {
                //simulate a time lapse
                Thread.Sleep(500);
                Write(".");
            }
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                bigArray[i] = randomNum.Next(0, 5); // get a random number between 0 and 4 and pace in array

            }

            int[] numCountArray = new int[5];       //array will store the number of occurances of each random number
            //loop over the columns in the array tracking the occurances of the numbers
            for (int i = 0; i < bigArray.Length; i++)
            {               
                switch (bigArray[i])
                {
                    case 0: numCountArray[0]++; break;
                    case 1: numCountArray[1]++; break;
                    case 2: numCountArray[2]++; break;
                    case 3: numCountArray[3]++; break;
                    case 4: numCountArray[4]++; break;
                    default:
                        WriteLine("Error sorting the numbers");
                        break;
                }//END: switch(bigArray[i])
            }//END: for()

            double[] pctArray = new double[5];                  //array will store the percentages 
            double testNum, total;
            int pctArrayLength = pctArray.Length;
            for (int i = 0; i < pctArrayLength; i++)
            {
                total = numCountArray[i];                       //re-assign total tot the total of the next column
                pctArray[i] = (total / pctArrayLength) / 1000;
                testNum = pctArray[i];                          //store the value to be assigned to pctArray for easier debug
            }

            for (int i = 0; i < pctArray.Length; i++)          
            {
                Console.WriteLine($"{i} occured {pctArray[i]:p2} of the time.");
            }

        }//END: Main()

    }//END: class Program

}//END: namespace
