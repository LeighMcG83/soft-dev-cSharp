/* ===================================================================
 * Worksheet: |  CA1
 * Program:   |  year1_sem2_CA1.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  11/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   | Sligo Insurance, who sells car insurance policies require 
 *            | an application to 
 *            |     (i)Calculate quotes for car insurance 
 *                  (ii)Produce a report  on the people looking for quotes, 
 *                      giving a breakdown of the  numbers of customers in each
 *                      age category, and calculating the average quote given for each.
                    (iii)A maximum of 100 quotes will be given. 

 *            | 
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  ****PENALTY POINTS NOT IMPLEMENTED
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;
using System.Collections.Generic;

namespace year1_sem2_CA1
{
    class Program
    {
        // Declare input / output tables
        public const string INPUTTAB = "{0, -35}{1, 10}";
        public const string MENUTAB = "{0, -15}{1,0}";     // first column is blank to indent second column
        public const string OUTPUTTAB = "{0, -10}{1, 25}{2, 15}";

        public static int under25s = 0, over25s = 0;

        static public string[] customerDetails = new string[4];               // define array to store the customers details in

        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            OutputEncoding = System.Text.Encoding.UTF8;

            // declare and initialize variables
            decimal quote = 0, average = 0;
            string[] details = new string[4];
            decimal[] quoteArray = new decimal[100];

            char menuChoice = ' ';

            //display the menu
            do
            {
                menuChoice = PrintMenu();
                switch (menuChoice)
                {
                    case '1':
                        GetCustomerDetails();                           // call method to get details                        
                        quote = CalculateQuote(details);                // get a quote 
                        Console.WriteLine($"This quote is {quote:c2}");
                        quoteArray[quoteArray.Length - 1] = quote;      // put quote at end of array
                        break;
                    case '2':
                        average = CalculateAverage(quoteArray);
                        PrintStatistics(average, under25s, over25s);
                        break;
                    case '3':
                        Console.WriteLine("You have chosen to exit the program");
                        break;
                    default:
                        Console.WriteLine("Invalid option chosen");
                        break;
                }
            } while (menuChoice != '3');



        } //END: Main()


        //method to print the menu
        static char PrintMenu()
        {
            char menuChoice = ' ';
            bool isValid = false;               // set isValid to false
            while (!isValid)                    // loop while the input was not valid
            {
                // print menu heading and options
                Console.WriteLine("Menu");
                Console.WriteLine(MENUTAB, "", "1. Calculate Quote");
                Console.WriteLine(MENUTAB, "", "2. Print Statistics");
                Console.WriteLine(MENUTAB, "", "3. Exit");
                menuChoice = Convert.ToChar(Console.ReadLine());

                //check if input was valid option, if was 3 we break inside main()
                if (menuChoice == '1' || menuChoice == '2' || menuChoice == '3')
                {
                    isValid = true;
                    return menuChoice;
                }
                
            }
            return menuChoice;
        } //END: PrintMenu()

        //method to get customers details
        static string[] GetCustomerDetails()
        {
            //string value, age, noClaims, points = "";               // declare and initialize variables to store details to base quote on
            int length = customerDetails.Length;                    // calc. length of array to use in for loop

            Console.Write(INPUTTAB, "Enter Vehicle value", ": ");
            customerDetails[0] = Console.ReadLine();
            Console.Write(INPUTTAB, "Enter age", ": ");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age > 18)
            {
                Console.Write(INPUTTAB, "Enter Years No Claims Bonus", ": ");
                customerDetails[2] = Console.ReadLine();
                Console.WriteLine(INPUTTAB, "Enter Penalty points", ": ");
                customerDetails[3] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No quote POSSIBLE");
            }

            return customerDetails;

        } //END: GetCustomerDetails()


        //method to calculate a quote
        static public decimal CalculateQuote(string[] details)
        {
            decimal premium = 0.0m;
            decimal quote = 0, discount = 0;

            // get the values from the array and convert to appropriate datatypes, stroe in vars.
            decimal value = Convert.ToDecimal(details[0]);
            int age = Convert.ToInt32(details[1]);
            int noClaims = Convert.ToInt32(details[2]);
            int points = Convert.ToInt32(details[3]);

            decimal quotesUnder25 = 0, quotesOver25 = 0;

            if (age < 18)
            {
                return -1;                             // if under 18 we will return -1
            }
            else if (age >= 18 && age < 25)
            {
                premium = 0.13m;                        // set premium to the higher rate   
                under25s++;
            }
            else
            {
                premium = 0.03m;                        // set premium to the higher rate            
                over25s++;
            }


            if (noClaims > 0)                           // if customer has noClaims bonus,apply a discount
            {
                for (int i = 0; i <= noClaims; i++)     // apply disc. for every year of noClaims
                {
                    discount += (discount * premium);
                }//END: (for(noCalims > 0)
            }

            if (age >= 18 && age <= 25)                 // if customer older that 18 calc. quote
            {
                quote += (value * premium) - discount;
                quotesUnder25 += quote;
            }
            else
            {
                quote += (value * premium) - discount;
                quotesUnder25 += quote;
            }

            return quote;                                // return the quote to main
        }

        //method to calculate the average quote
        static decimal CalculateAverage(decimal[] quotesArray)
        {
            decimal subtotal = 0;
            decimal average = 0;
            for (int i = 0; i < quotesArray.Length; i++)
            {
                subtotal += quotesArray[i];
            }
            average = subtotal / quotesArray.Length;
            return average;
        }

        //method to print the statistic of the quotes
        static void PrintStatistics(decimal average, int under25s, int over25s)
        {
            int totalCount = over25s + under25s;
            Console.WriteLine(OUTPUTTAB, "Age", "Number of Quotes", "Average Quote");
            Console.WriteLine(OUTPUTTAB, "18 - 25", $"{under25s}", $"{average}");
            Console.WriteLine(OUTPUTTAB, "Over25", $"{over25s}", $"{average}");
        }
    } //END: Program class

} //END: namespace
