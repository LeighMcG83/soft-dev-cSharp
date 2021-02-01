/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  worksheet3_switch_q5_vowels
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  01/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  A program that prints the number of vowels in that word.
 *            |     - Accepts string from user as input
 *            |     - Counts the vowels in the string
 *            |     - Outputs the count to the console
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

using System;

namespace worksheet3_switch_q5_vowels
{
    class Program
    {
        static void Main(string[] args)
        {            
            char[] Vowels = { 'a', 'e', 'i', 'o', 'u'};         // declare and initialize an array to store vowewls
            int vowelCount = 0;                                 // initialize counter variable

            Console.WriteLine("Enter a word or sentance : ");   // prompt user to input a string
            string inputString = Console.ReadLine().ToLower();  // convert to lowercase and assign to var.
            int length = inputString.Length;                    // get legth of the arrray

            for (int i = 0; i < length; i++)                    // iterate over the string
            {
                for (int j = 0; j < length; j++)                // iterate over array of vowels
                {
                    if (inputString[i] == Vowels[j])            // compare the letters in the string to the vowels in the array
                    {
                        vowelCount++;                           // increment the counter
                    }
                } // END: for(vowel in array)         
            } // END: for(letter in string)

            Console.WriteLine($"There are {vowelCount} vowels in the word / sentance.");    // Display the number of vowels

        } //END: Main()

    } // ENDclass Program
}
