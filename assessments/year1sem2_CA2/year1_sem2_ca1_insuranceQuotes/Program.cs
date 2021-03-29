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

        public static int numUnder25s = 0, numOver35s = 0;
        static decimal quotesValuesUnder25 = 0m, quotesValuesOver25 = 0m;

        static public string[] customerDetails = new string[4];    //stores the customers details

        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            OutputEncoding = System.Text.Encoding.UTF8;

            // declare and initialize variables
            decimal quote = 0, average = 0;
            string[] details = new string[4];
            decimal[] quoteArray = new decimal[100];
            int menuChoice = 0;
            const int QUIT = 3;                         //sentinel

            do
            {
                menuChoice = PrintMenu();
                switch (menuChoice)
                {
                    case 1:
                        GetCustomerDetails();                                             
                        quote = CalculateQuote(details, ref quotesValuesUnder25, ref numUnder25s, ref quotesValuesOver25, ref numOver35s);             
                        Console.WriteLine($"This quote is {quote:c2}");
                        quoteArray[quoteArray.Length - 1] = quote;      // put quote at end of array
                        Console.WriteLine($"quteArray:");
                        foreach (var q in quoteArray)
                        {                             
                            Console.Write(q + " ");
                        }
                        break;
                    case 2:
                        average = CalculateAverage(quoteArray);
                        PrintStatistics(average, numUnder25s, numOver35s);
                        break;
                    case 3:
                        Console.WriteLine("You have chosen to exit the program");
                        break;
                    default:
                        Console.WriteLine("Invalid option chosen");
                        break;
                }
            } while (menuChoice != QUIT);



        } //END: Main()


        //method to print the menu
        static int PrintMenu()
        {
            int menuChoice = 0;
            string userInput = "";
            bool isValid = false;               // set isValid to false
            while (!isValid)                    // loop while the input was not valid
            {
                // print menu heading and options
                Console.WriteLine("Menu");
                Console.WriteLine(MENUTAB, "", "1. Calculate Quote");
                Console.WriteLine(MENUTAB, "", "2. Print Statistics");
                Console.WriteLine(MENUTAB, "", "3. Exit");
                Console.Write("Enter: ");
                userInput = Console.ReadLine();

                //check if input was valid option, if was 3 we break inside main()
                if (IsPresent(userInput) && IsPositiveInt(userInput, "Menu Choice") && int.TryParse(userInput, out menuChoice))
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
            string input = string.Empty;
            bool isValid = false;
            string[] details = { "Enter Vehicle value", "Enter Age", "Enter No Claims Bonus", "Enter Penalty points" };

            for (int i = 0; i < length; i++)
            {
                do
                {
                    Console.Write(INPUTTAB, details[i], ": ");
                    input = Console.ReadLine();

                    if (i == 0)     //value                     
                        isValid = IsPresent(input) && IsDouble(input, details[i]) && IsInRange(input);                    
                    else if (i == 1) //age                                        
                        isValid = IsPresent(input) && IsPositiveInt(input, details[i]);                    
                    else            //noClaims || penalty points                    
                        isValid = IsPresent(input) && IsPositiveInt(input, details[i]) && IsInRange(input, 0, 12);
                    if (isValid)
                    {
                        customerDetails[i] = input;
                    }
                       

                    //Console.WriteLine($"{details[i]} : {customerDetails[i]}");

                } while (!isValid);
                
            }

            int age = Convert.ToInt32(input);
            if (age <= 18)
            {
                Console.WriteLine("No quote POSSIBLE");
            }
            else
            {
                do
                {
                    Console.Write(INPUTTAB, "Enter Years No Claims Bonus", ": ");
                    input = Console.ReadLine();
                    isValid = IsPresent(input) && IsPositiveInt(input, "NoClaims") && IsInRange(input, 0, 25);
                } while (!isValid);
                customerDetails[2] = input;
                Console.WriteLine($"In array[2]: {customerDetails[2]}");

            }//END: if(>18)

            return customerDetails;

        } //END: GetCustomerDetails()

        /// <summary>
        /// Method validates a user input by checking it is greater than zero
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is greater than zero</returns>
        private static bool IsInRange(string input)
        {
            const int MIN = 0;
            int intChoice = Convert.ToInt32(input);
            bool isValid = false;

            if (intChoice > MIN)
            {
                isValid = true;
            }

            return isValid;
        }//END: IsInRange()



        /// <summary>
        /// Method validates a user input by checking it is between a min and max value
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is between min and mas range allowed</returns>
        private static bool IsInRange(string choice, int minValue, int maxValue)
        {
            int intChoice = Convert.ToInt32(choice);
            bool isValid = false;

            if (intChoice >= minValue && intChoice <= maxValue)
            {
                isValid = true;
            }

            return isValid;
        }//END: IsInRange()



        //method to calculate a quote
        static public decimal CalculateQuote(string[] details, ref decimal quotesUnder25, ref int under25s, ref decimal quotesOver25, ref int over25s)
        {
            decimal premium = 0.0m;
            decimal quote = 0, discount = 0;

            // get the values from the array and convert to appropriate datatypes, stroe in vars.
            decimal value = Convert.ToDecimal(details[0]);
            int age = Convert.ToInt32(details[1]);
            int noClaims = Convert.ToInt32(details[2]);
            int points = Convert.ToInt32(details[3]);

            if (age < 18)
            {
                return -1;                             // if under 18 we will return -1
            }
            else if (age >= 18 && age < 25)
            {
                premium = 0.13m;                        // set premium to the higher rate   
            }
            else
            {
                premium = 0.03m;                        // set premium to the higher rate            
            }

            if (noClaims > 0)                           // if customer has noClaims bonus,apply a discount
            {
                for (int i = 0; i <= noClaims; i++)     // apply disc. for every year of noClaims
                {
                    discount += (discount * premium);
                }//END: (for(noCalims > 0)
            }

            if (age >= 18 && age <= 25)                 
            {
                quote += (value * premium) - discount;
                quotesUnder25 += quote;                 //accumulate the value of quotes for the under 25s
                under25s++;                             //increment the number if quotes given to under 25s
            }
            else
            {
                quote += (value * premium) - discount;
                quotesOver25 += quote;                  //accumulate the value of quotes for the under 25s
                over25s++;                              //increment the number if quotes given to under 25s
            }

            return quote;
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
            Console.WriteLine(OUTPUTTAB, "18 - 25", $"{under25s}", $"{quotesValuesUnder25 / under25s}");
            Console.WriteLine(OUTPUTTAB, "Over25", $"{over25s}", $"{quotesValuesOver25 / over25s}");
        }


        /// <summary>
        /// Method checks if a string input can be converted to an integer,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="name"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsPositiveInt(string textIn, string name)
        {
            int num;
            if (int.TryParse(textIn, out num) == true) // all went ok
                return true;
            else // there was a problem
                Console.WriteLine(name + " must be an integer value.", "Entry Error");
            return false;
        }//END:  IsInt()


        /// <summary>
        /// Method checks if a string input can be converted to a double,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="inout"></param>
        /// <param name="name"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsDouble(string inout, string name)
        {
            double num;
            if (double.TryParse(inout, out num) == true) // all went ok
            {
                return true;
            }

            else // there was a problem
            {
                Console.WriteLine($"{name} must be a real (decimal) value greater than zero.\n");
            }
            return false;
        }//END:  IsInt()


        /// <summary>
        /// Method check if the passed string argument id an empty string
        /// Takes 1 parameter no overloads
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>True if string is not empty, or false if it is</returns>
        private static bool IsPresent(string userInput)
        {
            if (!String.IsNullOrEmpty(userInput))
            {
                return true;
            }
            else
                Console.WriteLine("Entry cannot be blank!\n");
            return false;
        }//END: IsPresent();


    } //END: Program class

} //END: namespace
