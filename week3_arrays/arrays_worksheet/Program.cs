
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
            int[] testArray = { 7, 3, 6, 2, 9 };        // creates array initialised with values
            int biggest = GetBiggest(testArray);
            int smallest = GetSmallest(testArray);
            SortArray(testArray);
            Console.WriteLine($"Biggest : {biggest}");
            Console.WriteLine($"Smallest  :  {smallest}");
            foreach (int elem in testArray)
            {
                Console.Write(elem + " ");
            }

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

        // method to sort an array in ascending order
        static public void SortArray(int[] originalArray)         // arrays automatically passed by ref
        {
            int[] sortedArray = new int[originalArray.Length]; // create new array to store the values in order
            int length = sortedArray.Length;
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

        } // END: SortArray()

    }//END: class
}
