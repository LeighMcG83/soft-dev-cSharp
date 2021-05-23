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

            Console.WriteLine("\nThe maximum value in the array is " + GetMax(intArr));
            Console.WriteLine("\nThe minimum value in the array is " + GetMin(intArr));
            Console.WriteLine("\nThe numbers were generated in ascending order: " + CheckIsAscending(intArr));

            //int[] testAscendingTrue = { 1, 2, 3, 4, 5 };
            //int[] testAscendingFalse = { 2, 1, 4, 5, 6 };
            //int[] testRepeatsAscend = { 1, 1, 2, 3, 4 };
            //int[] testRepeatsDescend = { 4, 4, 3, 2, 1 };

            int[,] testMultiArray =
            {
                { 1, 2, 3, 4, 5 },
                { 2, 1, 4, 5, 6 },
                { 1, 1, 2, 3, 4 },
                { 4, 4, 3, 2, 1 }
            };

            Console.WriteLine($"\nThe numbers were generated in ascending order: {CheckIsAscending(testMultiArray)}");



        }//END: Main()

        public static void PrintArray(int[] arr)
        {            
            foreach (int num in arr)
                Console.Write(num + " ");            
        }


        public static bool CheckIsAscending(int[,] arr)
        {            
            for (int row = 0; row < arr.Length; row++)
            {
                int k = 1;  //k will be the next element in the current row
                for (int col = 1; col < arr.Length; col++, k++)
                {
                    while (row < arr.Length && row != col && col < arr.Length - 1)   //do not want to check on last element as the next would not exist
                    {
                        if (arr[row,col] > arr[row,k])
                            return false;
                    }
                }
            }
            return true;
        }


        public static bool CheckIsAscending(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                while (i < arr.Length)   //do not want to check on last element as the next would not exist
                {                    
                    if (arr[i] > arr[i+1])                        
                        return false;                   
                }
            }
            return true;
        }


        public static int GetMin(int[] arr)
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


        public static int GetMax(int[] arr)
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
