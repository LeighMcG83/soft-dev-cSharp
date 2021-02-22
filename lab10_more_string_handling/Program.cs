/* ==============================================================================================
 * Worksheet: |  Lab 10 - More string Handling
 * Program:   |  lab_10_more_string_handling_.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  22/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  1.	Write a prompt “>”, then read in and return a string.
 *            |     “ I am having a great time studying c# at Sligo IT  ”
 *            |  
 *            |  2.	Take one string parameter and write out the length of a given string to the console.
 *            |  
 *            |  3.	Take one string parameter, trim all leading and trailing spaces from the string, 
 *            |     and return the new length of the string.
 *            |
 *            |  4.	Take one string parameter and output the string in upper case.
 *            |     (Can you do this without using the build in function?)
 *            |
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace lab_10_more_string_handling
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string input = "";
            char prompt = '>';

            //Question 1. - unsure what question asks for....do i read in a random string from a user?            
            string output = ReadInput(prompt);      
            Console.WriteLine(output + "\n");

            //Question 2.
            input = GetUserInput();
            int lengthOfString = GetLengthOfString(input);
            Console.WriteLine($"That string is {lengthOfString} chars long.\n");

            //Question 3.
            Console.Write(prompt);
            input = GetUserInput();
            string trimmed = TrimString(input);
            Console.WriteLine(prompt + trimmed);

            //Question 4.



        }//END: Main()

        //question 1
        //method writes a '>' prompt and reads a string form the user and returns a predefined string
        static string ReadInput(char prompt)
        {
            string input = "";
            Console.Write(prompt);
            Console.Write("Enter a word / sentance: ");
            input = Console.ReadLine();

            Console.Write(prompt);
            Console.WriteLine($"You entered: {input}");
            Console.Write(prompt);

            return "I am having a great time studying c# at Sligo IT";
        }//END: ReadInput()

       
        //method gathers input form a user, printing a promt at beginning of each line
        static string GetUserInput()
        {
            char prompt = '>';
            string input = "";

            Console.Write(prompt);
            Console.Write("Enter a word / sentance: ");
            input = Console.ReadLine();
            Console.Write(prompt);

            return input;
        }//END: GetUserInput()

        
        //method measures the length of a string arg
        static int GetLengthOfString(string str)
        {
            int length = str.Length;
            return length;
        }//END: GetLengthOfString()


        //methof=d trims leading and trailing whitespace from a string and returns the new string
        static string TrimString(string str)
        {
            str = str.Trim();
            return str;
        }//END: TrimString()


        //method converts a string to uppercase and returns it.
        static string ConvertToUpper(string str)
        {
            //create an array of chars from the string that we can convert 
            //each to a hex val individually
            char[] values = str.ToCharArray(); 

            foreach(char letter in values)
            {
                int value = Convert.ToInt32(letter);    //convert the char to its dec value
                

            }
            return str;
        }

    }//END: class

}//END: namespace
