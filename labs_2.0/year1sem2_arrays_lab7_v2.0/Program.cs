/* Lab 7 - Arrays and Methods
 * ------------------------------------
 * Author : Leigh McGuinness
 * Created: 20 May 2021
 * ------------------------------------
 * Re-written with implementation for:
 *  - data validation
 *  - exception handling
 *  - file-handling (where applicable)
 *  - OOP (where applicable)
 */

using System;
using System.Collections.Generic;

namespace year1sem2_arrays_lab7_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1
            Random rnd = new Random();
            int[] intArr = new int[rnd.Next(5, 10)];

            //int[,] testArrays = {
            //    { 1, 2, 3, 4, 5 },
            //    { 2, 1, 4, 5, 6 },
            //    { 1, 1, 2, 3, 4 },
            //    { 4, 4, 3, 2, 1 } 
            //};



            try
            {
                for (int i = 0; i < intArr.Length; i++)
                    intArr[i] = Convert.ToInt32(rnd.Next(10));

                Console.Write("Numbers: ");
                PrintArray(intArr);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "Error while filling the arrey");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nUnknown error occurred while filling the array of numbers.");
            }

            DisplayArrayStats(intArr);

        }//END: Main()

        private static void DisplayArrayStats(int[] intArr)
        {
            try
            {
                Console.WriteLine("\nThe maximum value in the array is " + GetMax(intArr));
                Console.WriteLine("\nThe minimum value in the array is " + GetMin(intArr));
                Console.WriteLine("\nThe numbers were generated in ascending order: " + CheckIsAscending(intArr));
                Console.WriteLine("\nThe average of every third elem starting at [0] is: " + AverageOfThirdElements(intArr));
                Console.WriteLine("\nStandard Dev. of array elements: " + CalcStandDev(intArr));
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "Error while filling the arrey");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nUnknown error occurred while filling the array of numbers.");
            }            
        }

        private static double CalcStandDev(int[] intArr)
        {
            double total = 0;

            foreach (int num in intArr)
                total += num;
            return Math.Sqrt(total / intArr.Length);
        }

        private static double AverageOfThirdElements(int[] intArr)
        {
            double avg = 0;
            int count = 0;

            for (int i = 0; i < intArr.Length; i += 3)
            {
                avg += intArr[i];
                count++;
            }
            return avg / count;
        }

        private static void PrintArray(int[] arr)
        {            
            foreach (int num in arr)
                Console.Write(num + " ");            
        }

        private static bool CheckIsAscending(int[] arr)
        {
            int length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                if (i < (length - 1))           // only check if i will not send search out of bounds
                {
                    if (arr[i] > arr[i + 1])    // if current value > next value                    
                        return false;                    
                }//END: if()   
            } // END: for()
            return true;
        }


        private static int GetMin(int[] arr)
        {
            int min = arr[0];

            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                        min = arr[i];
                }
            }
            else
                Console.WriteLine("Null array was passed to GetMax()");

            return min;
        }


        private static int GetMax(int[] arr)
        {
            int max = arr[0];

            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];                    
                }
            }
            else
                Console.WriteLine("Null array was passed to GetMax()");

            return max;
        }

    }//END: Program class
}
