/* ===================================================================
 * Worksheet: |  Lab 5 - Methods
 * Program:   |  lab5_methodRevision.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  03/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write the following methods
 *            |     a) static int Smallest(int x, int y, int z), returning 
 *            |        the smallest of the arguments
 *            |     b) static int Average(int x, int y, int z), returning
 *            |        the average of the arguments
 *            |     c) static bool Same(int x, int y, int z), returning 
 *            |        true if all the arguments are the same
 *            |     d) static bool Diff(int x, int y, int z), returning 
 *            |        true if all the arguments are different
 *            |     e) static bool Sorted(int x, int y, int z), returning 
 *            |        true if all the arguments are sorted, with smallest 
 *            |        coming first
 *            |     
 *            |     Write code to test your methods
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  Q1 - (d) values all different
 *            |     - if values are unique returns they are same
 * ===================================================================*/

using System;

namespace lab5_methodRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numberArray = new double[3];           // declare and initalize array to store the numbers
            PopulateNumberArray(numberArray);               // call method to fill array

            for (int i = 0; i < numberArray.Length; i++)    // test the array was filled
            {
                Console.WriteLine(numberArray[i]);
            }

            double minValue = GetSmallest(numberArray);         // pass number array to method and return smallest number
            Console.WriteLine($"\nSmallest number in array: {minValue}");// write the min value to console

            double maxValue = GetBiggest(numberArray);          // pass number array as arg and return max value
            Console.WriteLine($"\nBiggest number in array: {maxValue}"); // write the maxValue to console

            double averageValue = GetAverage(numberArray);      // pass number array as arg and return avg value
            Console.WriteLine($"\nThe average of the numbers in the array: {averageValue}"); // write the average to console

            bool areAllSame = CheckAreSame(numberArray);        // pass number array as arg and return tue if all vas are equal
            Console.WriteLine($"\nAll values in array are equal: {areAllSame}"); // write result to screen

            bool areAllDifferent = CheckAreDifferent(numberArray);  // pass number array as arg and return tue if all vas are equal
            Console.WriteLine($"\nAll values in array are unique: {areAllDifferent}"); // write result to screen


        } //END: Main()

        // method to populate the array
        static public void PopulateNumberArray(double[] numArray)
        {            
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    // get 3 numbers off the user
                    Console.Write($"Enter number {i} :  ");
                    string input = Console.ReadLine();
                    numArray[i] = double.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: Your must enter a number");
                } //END: catch(input)                
            } //END: for(nums < 4)
        }

        // method takes an array as param and returns the minimum value
        static public double GetSmallest(double[] numArray)
        {
            double min = numArray[0];
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
        static public double GetBiggest(double[] numArray)
        {
            double max = numArray[0];
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
        static public double GetAverage(double[] numArray)
        {
            double subtotal = 0;
            foreach (var val in numArray)
            {
                subtotal += val;
            }
            double avg = subtotal / numArray.Length;
            return avg;
        }

        // method takes array as oaram and returns true if all values are equal
        // or false if not all values are equal
        static public bool CheckAreSame(double[] numArray)
        {
            bool areSame = false;                     // var to track boolean state of areSame
            Array.Sort(numArray);                     // Sort the array with built-in method
            for (int i = 0; i < numArray.Length; i++) // iterate over all elems in array
            {               
                if (numArray[0] == numArray[i])       // if the 0th elem is == to current elem
                {
                    areSame = true;                   
                } // END: if([0] == [i])
                else
                {
                    areSame = false;
                }
            } //END: for(lenArray)

            return areSame;
        } //END: CheckAreSame()

        // method takes array as oaram and returns true if all values are different
        // or false if not all values are equal
        static public bool CheckAreDifferent(double[] numArray)
        {
            bool areDiff = true;                      // var to track boolean state of areDiff
            Array.Sort(numArray);                     // Sort the array with built-in method
            //int previousIndex = 0;                    // var for the previous index checked

            for (int i = 0; i < numArray.Length; i++) // iterate over all elems in array
            {
                for (int j = 1; j < numArray.Length; j++)
                {
                    if (numArray[i] == numArray[j]) 
                    {
                        areDiff = false; 
                    }
                    
                } //END: inner for()
            } //END: outer for()

            //for (int i = 1; i < numArray.Length; i++) // iterate over all elems in array
            //{
            //    if (numArray[i] == numArray[previousIndex])  // if the current elem is == to previous index 
            //    {
            //        areDiff = false;
            //    } // END: if([0] == [i])
            //    else
            //    {
            //        areDiff = true;
            //    }
            //    previousIndex++;
            //} //END: for(lenArray)
            
            return areDiff;
        } //END: CheckAreSame()

       




    } //END: class Program

} //END: namespace
