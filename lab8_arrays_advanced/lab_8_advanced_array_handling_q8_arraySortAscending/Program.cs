/* ===================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_4_advanced_array_handling_q8_arraySortAscending.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Sort an array in Ascending order
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace week_4_advanced_array_handling_q8_arraySortAscending
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedArr =  { 4, 5, 3, 7, 2, 9 };
            DisplayArray(unsortedArr);
            SortArray(unsortedArr);
            DisplayArray(unsortedArr);
        }//END: Main()


        //method takes an array and a length as param and displays its values
        static void DisplayArray(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }//END: DisplayArray()


        // method to sort an array in ascending order
        static public Array SortArray(int[] originalArray)         // arrays automatically passed by ref
        {
            //int[] sortedArray = new int[originalArray.Length]; // create new array to store the values in order
            int length = originalArray.Length;
            int currentIndexValue = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (originalArray[i] < originalArray[j])    // if current value < next value
                    {
                        currentIndexValue = originalArray[i];   // assign the value so we can use it 
                        originalArray[i] = originalArray[j];    // assign the next value to this index
                        originalArray[j] = currentIndexValue;   // assign the next index this value (swap the values)
                    }
                } // END: for()
            } // END: for()
            return originalArray;       // return orignail array - as it was passed by reference, original array is sorted
        } // END: SortArray()

        //method moves the value as a passed-in index to the end of a array
        static void MoveBiggestToEnd(int[] arr, int maxIndex)
        {
            int temp = 0, last = arr.Length - 1, max = arr[maxIndex];

            temp = max;               //put the max in a temp
            arr[maxIndex] = arr[last];//assign the value in the last position to the positon max was in 
            arr[last] = max;          //assign the max(now temp) to the last position
        }//END: MoveBiggestToEnd()

    }
}
