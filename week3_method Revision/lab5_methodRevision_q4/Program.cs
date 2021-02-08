/* ===================================================================
 * Worksheet: |  Lab 5 - Methods
 * Program:   |  lab5_methodRevision_q4.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  03/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  a method to double the values of two integer arguments 
 *            |  that are passed to it. For example if the method is called 
 *            |  with two arguments a and b where a equals 10 and b equals
 *            |  30, then after calling the method a will equal 20 and b will
 *            |  equal = 60.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace lab5_methodRevision_q4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;                                          // set isValid to false so we enter loop on 1st iteration
            double num1 = 0;
            double num2 = 0;

            while (!isValid)
            {                
                try
                {
                    // get input of 2 nums from user and assign to vars
                    Console.WriteLine("Enter first number:  ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter second number:  ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    isValid = false;                                        // set isValid to flase
                    Console.WriteLine("ERROR - You must enter a number!!!");// display error msg to user
                }
                if(num1 >= 0 && num2 >= 0) { isValid = true; }              // set isValid to true if input was a number = 0 or greater
            } //END: while(!isValid)

            Console.WriteLine($"Numbers before they are doubled are {num1} and {num2}");

            // call method to double the numbers - pass the arguments by reference to chance the values
            DoubleNumbers(ref num1, ref num2);

            Console.WriteLine($"Numbers after being doubled : {num1} and {num2}");

        }// END: Main()
    
        // method that takes 2 values as aguments by reference
        static public void DoubleNumbers(ref double num1, ref double num2)
        {
            num1 *= num1;
            num2 *= num2;
        } // END: DoubleNumbers();
    } // END: class Program
}// END: namespace
