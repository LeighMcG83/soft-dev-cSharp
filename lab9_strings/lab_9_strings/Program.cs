/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q1_printChars.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  18/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that prints out every character in a string 
 *            |  that is passed to it as an argument.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace lab_9_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "";
            
            Console.Write("Enter a word and I will spell it back to you : ");
            word = Console.ReadLine();            

            PrintChars(word);       //call method to break string into chars and spell out the word
            
        }//END: Main()

        //method takes a string as a parameter and prints out its chars
        static void PrintChars(string str)
        {
            char letter = ' ';

            for (int i = 0; i < str.Length; i++)
            {
                letter = Convert.ToChar(str.Substring(i, 1));   //start sub string at pos. i, length is 1   
                if (i == str.Length - 1)
                    { Console.Write(letter + ". "); }           //print full stop if is last letter
                else
                    { Console.Write(letter + ", "); }
                
            }//END: for()
        }//END: PrintChars()

    }
}
