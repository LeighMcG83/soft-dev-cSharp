/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  worksheet3_switch_q5_vowels
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  01/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a program to print the following celcius/Fahrenheit
 *            |  conversion table. 
 *            |  
 *            |  C is Celsius     F is Fahrenheit
 *            |  C = 5/9 (F-32)   F = 9/5 (C+32)
 *            |  
 *            |  Celcius		  Fahrenheit
 *            |  0	              32
 *            |  10               50
 *            |  20               68
 *            |  ….               ...
 *            |  …                ...
 *            |  100              211
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

using System;

namespace worksheet3_switch_q6_tempConv
{
    class Program
    {       

        static void Main(string[] args)
        {            
            const string TITLE = "\tCelcius to Fahrenheit Conversion Chart\n";  // declare program title


            Console.WriteLine(TITLE);                    // Diplay program title           
            Console.WriteLine("Celcius\t\tFahrenheit");  // print column headers

            // start loop 
            for (int cel = 0; cel <= 100; cel += 10)     // increment celcius by 10 degrees on each iteration
            {               
                int fah = (cel * 9 / 5) + 32;            // convert cel. to fah.
                Console.WriteLine($"{cel, 10}{fah, 10}");// write cel and fah (to 0 places) to console
            } //END: for()
            
        }// END: Main()

    }// //END: class Program

} // END: namespace
