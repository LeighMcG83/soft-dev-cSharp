/* ==============================================================================================
 * Worksheet: |  lab 9 Strings
 * Program:   |  lab_9_strings_q8_dotCom.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  21/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a method that accepts a string variable as an argument and returns true if 
 *            |  the argument ends with “.com”.  Otherwise the method should return false.
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/

using System;

namespace lab_9_strings_q8_dotCom
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            Console.Write($"Enter a domain name and I will determine if it ends with \".com\": ");
            string input = Console.ReadLine();

            //method call and output
            Console.WriteLine($"Ends in \".com\": {CheckDotCom(input)}");
        }//END:  Main()

        //method retruns true if string arg ends in .com, else returns false
        static bool CheckDotCom(string str)
        {
            if (str.EndsWith(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//END: CheckDotCom()

    }//END: class Program

}//END: namespace
