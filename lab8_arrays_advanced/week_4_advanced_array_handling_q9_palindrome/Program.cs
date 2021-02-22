/* ==========================================================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_4_advanced_array_handling_q9_palindrome.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Purpose:   |  Write a program that determines if a string is a palindrome
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Mods:      | 
 *  _ _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * BUGS:      |  
 * ==========================================================================================================*/

using System;
using System.Threading;


namespace week_4_advanced_array_handling_q9_palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool askAgain = false;
            char response = ' ';
            do
            {
                askAgain = false;
                Console.Write("Enter a word : ");
                string str = Console.ReadLine();
                Console.Write($"Checking if {str} is a palindrome");
                Loading();
                bool isPalindrome = CheckPalindrome(str);
                Console.WriteLine($"Palindrome : {isPalindrome}");
                Console.Write("\nDo you want to check another word? (y / n) :");
                response = Convert.ToChar(Console.ReadLine().ToUpper());
                if (response == 'Y')
                {
                    askAgain = true;
                }
            } while (askAgain);
           
            

        }//END: Main()

        //method prints a series of .'s to represent loading/processing
        static void Loading()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);      //wait 0.5sec
            }
            Console.WriteLine();
        }//END: Loading()

        //method takes a string as a param and returns true if it is a palindrome
        static bool CheckPalindrome(string str)
        {
            bool isPalindrome = false;
            string reverse = "";

            for (int i = str.Length - 1; i >= 0; i--)   //start at end of str
            {
                reverse += str[i];                      //assign the value in str to reverse (last will be first)
            }
            if (str.Equals(reverse))                    //check for equality in the strings
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }
    }//END: class Program

}//END: namespace
