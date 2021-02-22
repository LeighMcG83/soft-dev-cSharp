/* ==============================================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q7_stripSymbols.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  21/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a method that accepts a string variable as an argument and returns a new string
 *            |  with the characters ‘$’, ‘%’, ‘,’ ‘ ‘ stripped out of it. (e.g. “abc$$kh%  gg,”  
 *            |  will return “abckhgg”
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/
using System;

namespace lab_9_strings_q7_stripSymbols
{
    class Program
    {
        static void Main(string[] args)
        {  
            //input
            Console.Write($"Enter a string containing symbols and i will remove them : ");
            string input = Console.ReadLine();

            //method call and output
            Console.WriteLine($"With Symbols removed: {StripSymbols(input)}");

        }//END: Main()


        //method returns a string stripped of any symbols it contains
        static string StripSymbols(string str)
        {
            //array of sybols to search for
            char[] Symbols = { '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '/', '\\', '|',
                               '<', '>', '@', ':', ';','#','[',']','-','=','+','`','¬','€','¦','?'};
            int symbolIndex;
            //iterate over the string to look for symbols
            for (int i = 0; i < str.Length; i++)
            {                
                symbolIndex = str.IndexOfAny(Symbols, i);   //finds the index of 1st occurance of a symbol in the array
                if (symbolIndex != -1)                      //remove will return -1 if no symbols present, Remove() cannot start at -1
                {
                    str = str.Remove(symbolIndex, 1);       //start at symbolIndex and remove 1 char
                }
                
            }

            return str;
        }

    }//END: class Program

}//END: namespace