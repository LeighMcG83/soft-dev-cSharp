/* ==========================================================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_4_advanced_array_handling_q6_ticTacToe
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  18/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Purpose:   |  Write a program that moves the largest value in an array to the last element in the array
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Mods:      | 
 *  _ _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * BUGS:      |  
 * ==========================================================================================================*/

using System;

namespace week_4_advanced_array_handling_q7_moveBiggest
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            int[] intArray = new int[10];              //declare an empty array that we will fill woth random ints
            int length = intArray.Length;              //get the length of array to pass to PopulateArray()

            //method calls            
            PopulateArray(intArray, length);           //fill array with random numbers   
            Console.WriteLine("Array original Order:");
            DisplayArray(intArray);                    //display the array unsorted
            int maxIndex = GetBiggestIndex(intArray);  //search array and return the biggest numbers' position
            MoveBiggestToEnd(intArray, maxIndex);      //move the biggest number
            Console.WriteLine("Array with larges value moved to end:");
            DisplayArray(intArray);                    //redisplay the array

        } //END: Main()


        //method fills an array with random numbers
        static void PopulateArray(int[] arr, int length)
        {
            //create a new object of Random() class so we can fill the array with randoms
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                arr[i] = rnd.Next(0, 9);        //get a random number between 0 and 9 and assign to array[i]
            }
        }//END: PopulateArray()

        
        //method takes an array and a length as param and displays its values
        static void DisplayArray(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }//END: DisplayArray()


        //method takes an array as param and returns the maximum value index
        //if the max value occurs more than once, returns first occurance
        static public int GetBiggestIndex(int[] arr)
        {
            int maxIndex = 0;
            int length = arr.Length;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] > arr[maxIndex])
                    {
                        maxIndex = i;
                    } //END: if(num>min)

            } //END: for(lengthArray)

            return maxIndex;
        } ///END: GetBiggestIndex()


        //method moves the value as a passed-in index to the end of a array
        static void MoveBiggestToEnd(int[] arr, int maxIndex)
        {
            int temp = 0, last = arr.Length - 1, max = arr[maxIndex]; 
            
            temp = max;               //put the max in a temp
            arr[maxIndex] = arr[last];//assign the value in the last position to the positon max was in 
            arr[last] = max;          //assign the max(now temp) to the last position
        }//END: MoveBiggestToEnd()


    }//END: class Program

}//END: namespace