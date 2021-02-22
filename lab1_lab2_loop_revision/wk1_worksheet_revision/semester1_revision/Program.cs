/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  semester1_revision.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Q1. Write a for loop to print all integers between 40 
 *            |      and 60 in ascending order. 
 *            |         a.	Now write it with a while loop. 
 *            |         b.	Now write it with a do.. while loop.
 *            |      Explain to the person beside you how these constructs differ.
 *            |
 *            |  Q2. Modify the for loop from Q1 to print all integers between
 *            |      40 and 60 excluding 46 and 48 in ascending.
 *            |
 *            |  Q3. Write a for loop to print all integers between 60 and 40
 *            |      in descending order.  
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace semester1_revision
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Total of ints 40 > i < 60
            int total = 0;
            for (int i = 40; i < 61; i++)
            {                
                total += i;                
            }
            Console.WriteLine($"Total of ints between 40 and 60 inclusive (incremental loop) = {total}\n");


            // Question 1b: while version
            int total_1b = 0;
            int count = 40;

            while(count < 61)
            {
                total_1b += count;
                count++;
            }
            Console.WriteLine($"Total of ints between 40 and 60 inclusive (while) = {total}\n");


            // Question 1c: do-while version
            int total_1c = 0;
            count = 40;

            do
            {
                total_1c += count;
                count++;
            } while (count < 61);
            Console.WriteLine($"Total of ints between 40 and 60 inclusive (do-while) = { total}\n");


            // Question 2: Total of ints 40 < i < 60 except 46 and 48
            total = 0;
            Console.WriteLine("List of ints between 60 and 40 (decending order):");
            for (int i = 40; i < 61; i++)
            {
                if (i != 46 && i != 48)
                {
                    Console.Write(i + " ");
                    total += i;
                }                
            }
            Console.WriteLine($"\nTotal of ints between 40 and 60 (except 46 and 48) = {total}\n");


            // Question3: Print list of ints 60 > i > 40, descending order
            Console.WriteLine("List of ints between 60 and 40 (decending order):");
            total = 0;
            for (int i = 60; i >= 40; i--)

            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
