/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q5_startWithNumeric.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that returns true if the string that is passed 
 *            |  to it as an argument starts with a numeric character.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace lab_9_strings_q5_startWithNumeric
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string input = "";
            bool startsNumeric;
            //input
            Console.Write("Enter a string and I will determine if it starts with a number : ");
            input = Console.ReadLine();

            //method calls
            startsNumeric = CheckStartIsNumeric(input);

            //output
            Console.WriteLine($"Checking with TryParse that {input} starts with a number : {startsNumeric}");
            Console.WriteLine($"Checking with else-if that {input} starts with a number : {CheckStartIsNumeric(input)}");

        }//END: Main()

        //method takes a string as arg and checks if it starts with a number, returns true / false
        static bool CheckStartIsNumeric(string str)
        {
            double aNum = 0;                                //will tryparse input to aNum var, if successful it is a number
            string firstLetter = Convert.ToString(str[0]);  //get the 1st letter and convert to a string from char

            if (double.TryParse(firstLetter, out aNum)) 
            {                                          
                return true;                           
            }                                          
            else                                        
            {
                return false;
            }//END if-else()

        }//END: CheckStartIsNumeric()

        //method takes a string as arg and checks if it starts with a number, returns true / false
        static bool CheckStartIsNumericIfElse(string str)
        {
            bool startsNumeric = false;

            if (str.StartsWith('0')) { startsNumeric = true; }
            else if (str.StartsWith('1')) { startsNumeric = true; }
            else if (str.StartsWith('2')) { startsNumeric = true; }
            else if (str.StartsWith('3')) { startsNumeric = true; }
            else if (str.StartsWith('4')) { startsNumeric = true; }
            else if (str.StartsWith('5')) { startsNumeric = true; }
            else if (str.StartsWith('6')) { startsNumeric = true; }
            else if (str.StartsWith('7')) { startsNumeric = true; }
            else if (str.StartsWith('8')) { startsNumeric = true; }
            else if (str.StartsWith('9')) { startsNumeric = true; }
            else { startsNumeric = false; }

            return startsNumeric;
        }

    }//END: class Program

}//END: namespace
