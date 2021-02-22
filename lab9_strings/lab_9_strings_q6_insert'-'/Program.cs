/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q6_insert'-'.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  21/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that accepts a string variable as an argument 
 *            |  and returns a new string with a ‘-‘ inserted after every third
 *            |  character (e.g. “ 97755512312” will return “977-555-123-12”)
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;


namespace lab_9_strings_q6_insert___
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string inputStr = "", outputStr = "";

            //input
            Console.Write($"Enter a string and I will insert '-' after every 3 chars : ");
            inputStr = Console.ReadLine();

            //method calls
            outputStr = InsertHyphens(inputStr);

            //output
            Console.WriteLine(outputStr);

        }//END: Main()


        //method inserts a hyphen into a string after every 3 chars and returns a new string
        static string InsertHyphens(string str)
        {
            for (int i = 3; i < str.Length; i += 4)
            {
                str = str.Insert(i, "-");               //start at index 2, then we increment by 3 on each iteration
            }
            return str;
        }//END: InsertHyphens()

    }//END: class Program

}//END: namespace