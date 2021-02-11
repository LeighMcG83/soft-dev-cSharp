
/* ===================================================================
 * Worksheet: |  array_worksheet
 * Program:   |  arrays_worksheet_q1
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  08/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write the following methods that take an array of ints as a parameter and returns
 *            |     1.	The largest value in the array
 *            |     2.	The smallest value in the array
 *            |     3.	True if the array is sorted in ascending order otherwise false
 *            |     4.	The average of every third element in the array, starting with the first element
 *            |     5.	The standard deviation of all the values stored in the array 
 *            |         (check out your maths notes or Math or www.MathisFun.com
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/


using System;

namespace arrays_worksheet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 7, 3, 6, 2, 9 };            // creates array initialised with values to test methods
            
            // Call GetBiggest, return result and wwrite to console
            Console.WriteLine($"Biggest : {GetBiggest(testArray)}"); 

            //call GetSmallest, pass the test array, return the smalles value and write to console
            Console.WriteLine($"Smallest  :  {GetSmallest(testArray)}");

            // pass array to check if it is in ascending order
            Console.WriteLine($"Array in ascending order  : {CheckIsSorted(testArray)}"); 
            
            // Pass array as arg to method, calc. average of every 3rd element, return result and write to console
            Console.WriteLine($"The Average of every third element is : {Average3rds(testArray)}");

            // Pass array as arg to method, calc. standard deviation of the elements, return result and write to console
            Console.WriteLine($"The standard deviation(3 decimal places) in the array elements is :  {GetStandDeviation(testArray):f3}");



        }// END: Main()

        // method takes an array as param and returns the minimum value
        static public int GetSmallest(int[] numArray)
        {
            int min = numArray[0];
            int length = numArray.Length;
            for (int i = 0; i < length; i++)
            {
                if (numArray[i] < min)
                {
                    min = numArray[i];
                } //END: if(num<min)
            } //END: for(lengthArray)
            return min;
        } ///END: GetSmallest()

        // method takes an array as param and returns the maximum value
        static public int GetBiggest(int[] numArray)
        {
            int max = numArray[0];
            int length = numArray.Length;
            for (int i = 0; i < length; i++)
            {
                if (numArray[i] > max)
                {
                    max = numArray[i];
                } //END: if(num>min)

            } //END: for(lengthArray)

            return max;
        } ///END: GetBiggest()

        // method takes array as param and returns the average of the values
        static public double GetAverage(int[] numArray)
        {
            double subtotal = 0;
            foreach (var val in numArray)
            {
                subtotal += val;
            }
            double avg = subtotal / numArray.Length;
            return avg;
        }

        // method to check if an array is sorted in ascending order
        static public bool CheckIsSorted(int[] arr)         // NOTE: arrays automatically passed by ref
        {
            int length = arr.Length;
            bool isSorted = true;
            for (int i = 0; i < length; i++)
            { 
                if (i < (length - 1))           // only check if i will not send search out of bounds
                { 
                    if (arr[i] > arr[i + 1])    // if current value > next value
                    {
                        isSorted = false;
                    }
                }//END: while()   
            } // END: for()

            return isSorted;
        } // END: SortArray()

        //method returns the average of every third elem in array
        static double Average3rds(int[] arr)
        {            
            int count = 0;  //track number of times we add a number
            double total = 0; 
            int length = arr.Length;

            for (int i = 0; i < length; i += 3)
            {
                total += arr[i];
                count++;
            }//END: for(len of arr)
            return total / count;
        }//END: Average3rds()

        //method returns the standard deviation of a passed-in array
        static double GetStandDeviation(int[] arr)
        {
            int length = arr.Length;
            double  total = 0;

            for (int i = 0; i < length; i++)
            {
                total += arr[i];
            }
            return Math.Sqrt(total / length);   // calculate and return the standard deviation
        }//END: GetStandDeviation()

    }//END: class
}
