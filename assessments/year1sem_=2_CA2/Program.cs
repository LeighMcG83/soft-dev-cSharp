/* ==============================================================================================
 * Worksheet: |  Year 1 Semester 2 - CA2
 * Program:   |  year1sem__2_CA2.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  11/3/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  
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


namespace year1sem__2_CA2
{
    class Program
    {
        // Declare input / output tables accessible to all methods
        const string INPUT_TAB = "{0, -25}{1, 10}";
        const string MENUTAB = "{0, -10}{1,0}";     // first column is blank to indent second column
        const string OUTPUT_TAB = "{0,10}{1,10}{2,10}{3,10}";
        //formatting
        const string TITLE_SHORT = " ----------------INCOME TAX ---------------- ";
        const string PROG_END_SHORT = "==============================================\n";
        const string DIVIDER_SHORT = "----------------------------------------------\n";


        static int[] numPeopleInBand = new int[50];
        static decimal[] totalsPerband = new decimal[50];
        static decimal[] taxPerBand = new decimal[50];
        static decimal[] taxRates = { 0.18m, 0.2m, 0.21m, 0.23m, 0.3m, 0.33m, 0.5m };
        static int[] taxBands = { 0, 1, 2, 3, 4, 5, 6 };
        static int[] taxBandsUsed = new int[50];

        static int count = 0;
        const int QUIT = -999;
        decimal taxRate = 0m;

        static void Main(string[] args)
        {
            //setup
            // Encoding to allow us to print sepcial characters to the screen.
            OutputEncoding = System.Text.Encoding.UTF8;
            string input;
            int band = 0;

            //print banner
            Console.WriteLine(DIVIDER_SHORT);
            Console.WriteLine(TITLE_SHORT); 
            Console.WriteLine(DIVIDER_SHORT);

            //main loop
            do
            {
                decimal salary = GetValidSalary();
                if (salary == 0)        //value will be zero if -999 was input in GetValidSalary()
                {
                    break;
                }

                band = GetTaxBand(salary, ref band);
                CalculateTaxTotals(band, salary);

            } while (count < 50);

            Console.WriteLine(DIVIDER_SHORT);
            PrintTaxReport();
            Console.WriteLine(DIVIDER_SHORT);
            

        }//END:  Main()

        private static void PrintTaxReport()
        {
            
            Console.WriteLine(OUTPUT_TAB, "Tax Band", "TaxRate", "Tax Paid", "Number");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(OUTPUT_TAB, $"{taxBands[i]}", $"{taxRates[i]:p2}", $"{taxPerBand[i]:c2}", $"{numPeopleInBand[i]}");
            }

            decimal total = 0m;

            for (int i = 0; i < totalsPerband.Length; i++)
            {
                total += totalsPerband[i];
            }
            decimal avg = total / count;
            Console.WriteLine(OUTPUT_TAB, "Average Tax Paid", $"{avg}");
            Console.WriteLine(OUTPUT_TAB,"Total Tax");
        }

        private static int FindIndex(decimal rate, decimal[] taxBands)
        {
            int index = -1;

            if (rate != null)
            {
                for (int i = 0; i < taxBands.Length; i++)
                {
                    if (rate == taxBands[i])
                    {
                        return i;
                    }
                }
            }
            
            return index;
        }


        private static void CalculateTaxTotals(int band, decimal salary)
        {
            decimal total = 0m, taxPaid = 0m;

            taxPaid = salary * taxRates[band];
            taxPerBand[band] += taxPaid;
            
            //totalsPerband[band] += total;

        }


        private static int GetTaxBand(decimal salary, ref int band)
        {
            if (salary <= 10000)
            {
                band = 0;
                numPeopleInBand[band]++;
                
            }
            else if (Convert.ToInt32(salary) <= 15000)
            {
                band = 1;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            else if (salary <= 20000)
            {
                band = 2;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            else if (salary <= 25000)
            {
                band = 3;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            else if (salary <= 30000)
            {
                band = 4;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            else if (salary <= 50000)
            {
                band = 5;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            else
            {
                band = 6;
                numPeopleInBand[band]++;
                taxBandsUsed[band] = band;
            }
            return band;
        }

        private static decimal GetTaxBand(decimal salary)
        {
            decimal rate = 0m;

           if(salary <= 10000)
            {
                rate = taxRates[0];
                numPeopleInBand[0]++;
                taxPerBand[0] += rate;
            }
            else if (Convert.ToInt32(salary) <= 15000)
            {
                rate = taxRates[1];
                numPeopleInBand[1]++;
                taxPerBand[1] += rate;

            }
            else if (salary <= 20000)
            {
                rate = taxRates[2];
                numPeopleInBand[2]++;
                taxPerBand[2] += rate;

            }
            else if (salary <= 25000)
            {
                rate = taxRates[3];
                numPeopleInBand[3]++;
                taxPerBand[3] += rate;

            }
            else if (salary <= 30000)
            {
                rate = taxRates[4];
                numPeopleInBand[4]++;
                taxPerBand[4] += rate;

            }
            else if (salary <= 50000)
            {
                rate = taxRates[5];
                numPeopleInBand[5]++;
                taxPerBand[5] += rate;

            }
            else 
            {
                rate = taxRates[6];
                numPeopleInBand[6]++;
                taxPerBand[6] += rate;

            }
            return rate;
        }

        private static decimal GetValidSalary()
        {
            string input = "";
            decimal salary = 0m;

            do
            {
                Console.Write(INPUT_TAB, "Please enter a Salary", ": ");
                input = Console.ReadLine();
                if(Convert.ToInt32(input) == QUIT)
                {
                    break;
                }
                if(decimal.TryParse(input, out salary))
                {
                    salary = Convert.ToDecimal(input);
                    count++;
                }
            } while (count < 50 && !IsPresent(input) && !IsPositiveInt(input, "Salary"));

            return salary;
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
            if (int.TryParse(textIn, out num) == true)
            {
                if (num > 0)
                {                    
                    return true;
                }                
            }                
            else 
                Console.WriteLine(name + " must be an integer value.", "Entry Error");
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
            return false;
        }//END: IsPresent();


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







    }//END: class Program

}//END: namespace