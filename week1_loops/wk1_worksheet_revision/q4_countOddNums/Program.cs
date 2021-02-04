/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q4_countOddNums.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  4.	Write a program to read in 5 integer values, and determine
 *            |     how many of the numbers entered are odd numbers  
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace q4_countOddNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int odds = 0, count = 0, num;

            while(count < 5)
            {
                Console.Write("Enter a number : ");
                num = int.Parse(Console.ReadLine());
                
                if (num % 2 != 0) 
                {
                    odds++; 
                }
                count++;
            }
            Console.WriteLine($"Number of Odd numbers entered  :  {odds}");
        }
    }
}
