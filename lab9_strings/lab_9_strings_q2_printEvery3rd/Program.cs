/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q2_printEvery3rd.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that prints out every third character in
 *            |  a string that is passed to it as an argument.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace lab_9_strings_q2_printEvery3rd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word or sentance and I will repeat every 3rd letter : ");
            string word = Console.ReadLine();

            Prind3rdLetters(word);

        }//END: Main()

        //method prints every 3rd character(including spaces / symbols) in a passed string
        static void Prind3rdLetters(string word)
        {
            Console.WriteLine("\nEvery third letter is :");
            for (int i = 2; i < word.Length; i += 3)
            {
                if (i == word.Length - 1) 
                    { Console.Write(word[i] + "."); }
                else
                    { Console.Write(word[i] + ", "); }
            }//END: for(len of word)
        }//END: Prind3rdLetters()

    }//END: class Program

}//END: namespace
