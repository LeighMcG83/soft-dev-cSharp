/* ===================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_8_advanced_array_handling.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  16//02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Generate an array of 20 random integers from zero to nine.
 *            |   - Search for the first occurrence, if any, of the number 7,
 *            |   - report its position in the array 
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  Repeat the computation of part a 100 times, and for each
 *            |  position in the array, report the number of times that the
 *            |  fist occurrence of a 7 in the array is at that position
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  PrintResults()
 *            |    - prints the number of times 7 was found @ index 19 only
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace week_8_advanced_array_handling
{
    class Program
    {
        static void Main(string[] args)
        {    
            //setup
            int[] numArray = new int[20];       // create an empty array of legth 20 that we will fill with random ints
            int target = 7, foundIndex = -1;    // declare a target number to search for. initialize a var to store its index pos.
            int count = 0;
            int[] timesFound = new int[20];     // array will storethe number of times a 7 is found at each index position
            bool isFound = false;

            
            while (count <= 100)                                                                // repeat 100 times
            {
                //method calls
                FillArrayWithRandoms(numArray);                                                 // populate numArray
                isFound = SearchForTargetNumber(numArray, target, ref foundIndex, timesFound);  // check array for the target number, pass the index by ref change the value
                count++;
            }
            
            PrintResult(isFound, target, foundIndex, timesFound);                               // print the result based on if the target number was found
                  



        }//ENd: MAin()

        //method that will fill an array with random integer numbers
        //array passed by reference as default -> no return needed
        static void FillArrayWithRandoms(int[] numArray)        
        {
            int length = numArray.Length;

            //fill array with random numbers
            for (int i = 0; i < length; i++)
            {               
                Random randomNum = new Random();        // create a Random() object
                numArray[i] = randomNum.Next(0, 10);     // get a random number between 0 and 9
            }
        }//END: FillArrayWithRandoms()


        //method will search the array for a predetermined int and return true if found
        static bool SearchForTargetNumber(int[] numArray, int target, ref int foundIndex, int[] timesFound)
        {
            bool isFound = false;       // boolean will be used to track if a target number is specified in array
            foundIndex = -1;
            int length = numArray.Length;

            // loop over array
            for (int i = 0; i < length; i++)    
            {
                if (isFound)            // if number has been found, break and dont search again
                    break;
                
                // check if current value = 7
                if (numArray[i] == target)
                {
                    isFound = true;     // track if the number was found
                    foundIndex = i;     // record the index position   
                    timesFound[i]++;    // increment the value at same position in the timesFound array
                }
            }//END: for()
            return isFound;
        }//END: SearchForTargetNumber()

        static void PrintResult(bool found, int target, int foundIndex, int[] timesFound)
        {
            string msg;
            for (int i = 0; i < timesFound.Length; i++)
            {
                if (found)
                {
                    msg = $"{target} was found at index position {i}, {timesFound[foundIndex]} times";
                }
                else
                {
                    msg = $"{target} was not found in array";
                }
                Console.WriteLine(msg);
            }//END: for()
        }//END: PrintResult()



    }//END: class Program

}//END:namespace
