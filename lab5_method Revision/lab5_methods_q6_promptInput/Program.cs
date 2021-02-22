/* ===================================================================
 * Worksheet: |  
 * Program:   |  
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   | Write a method that displays a prompt string, followed by
 *            |  a space, and then reads an integer and returns it.
 *            |     
 *            |     static int Read_Integer(string prompt)
 *            |
 *            | Here is a typical usage:
 *            |     int salary = Read_Integer(“please enter your salary : “)
 *            |     Write similar methods to read data of type double, and string.
 * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace lab5_methods_q6_promptInput
{
    class Program
    {
        static void Main(string[] args)
        {
            int intNum = Read_Integer("Enter a whole number : ");
            double dblNum = Read_Double("Enter a decimal number : ");
            string str = Read_String("Enter a word or sentance : ");

        } //END: Main()

        // method that takes a string as arg and returns an int
        static int Read_Integer(string strNum)
        {
            int intNum = Convert.ToInt32(Console.ReadLine());
            return intNum;
        }

        // method that takes a string as arg and returns a double
        static double Read_Double(string strNum)
        {
            double dblNum = Convert.ToDouble(Console.ReadLine());
            return dblNum;
        }

        // method that takes a string as arg and returns a string
        static string Read_String(string str)
        {
            return str;
        }

    }// END: class Program
}
