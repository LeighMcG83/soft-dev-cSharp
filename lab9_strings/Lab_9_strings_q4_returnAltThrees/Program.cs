/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q3_findXandY.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that that accepts a string variable as an 
 *            |  argument and returns a new string made up of every alternate
 *            |  3 characters (e.g “abcdefghij” will return “abcghi”)
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace Lab_9_strings_q4_returnAltThrees
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string input = "";       

            //input
            Console.Write("Enter a word and I will return a new string made up of every alternate 3 characters: ");
            input = Console.ReadLine();

            //method calls
            string altWord = AlternateThreeChars(input);

            //output
            Console.WriteLine($"String with every alternating 3 chars removed : {altWord}");

        }//END Main()


        //method takes a string as an arg and returns every 3 alternate chars
        static string AlternateThreeChars(string str)
        {
            for (int i = 3; i < str.Length; i += 3)
            {
                str = str.Remove(i, 3);
            }           

            return str;
        }//END: AlternateThreeChars()

    }//END: classs Program

}
