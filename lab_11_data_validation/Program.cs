/* ==============================================================================================
 * Worksheet: |  Lab 11 - Data Validation
 * Program:   |  lab_11_data_validation.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  26/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a program that reads in an employees name, ID number and hours worked and 
 *            |  hourly pay rate. It will then calculate the employees tax, take home pay.
 *            |
 *            |  Validate all inputs to ensure
 *            |     - The employee’s name must be present
 *            |     - The employees ID number:
 *            |         -Must be present
 *            |         -Must be 6 characters long
 *            |         -Must start with an ‘E’
 *            |     - The hours worked value:
 *            |         -Must be present
 *            |         -Must be of type double
 *            |         -Must be in the range 10 to 50
 *            |     - The hourly pay rate
 *            |         -Must be present
 *            |         -Must be of type double
 *            |         -Must be in the range 10 to 65
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

namespace lab_11_data_validation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] details = new string[4];
            double taxFreeAllowance = 0, taxrate = 0, grossPay, nettPay, taxPayable;

            Console.WriteLine("Enter Employee's Details:\n");
            GetEmployeeDetails(details);

            LoadingMethod();

            grossPay = CalculateGross(details);
            taxPayable = CalculateTax(grossPay, taxrate);
            nettPay = CalculateNettPay(grossPay, taxPayable);

            /*  Ambuigity in question:
             *  - limit on hours worked and hourly rate of pay mean that certain tax bands can never be reached.
             *  Should displayed details be yearly?
             *  */
            DisplayPayslip(details, taxFreeAllowance, taxrate, grossPay, nettPay, taxPayable);

        }//END:  Main()

        private static void LoadingMethod()
        {
            Console.Write("Generating payslip"); //use a sleep tmer of 0.25sec to simulate generation of a payslip
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
            Console.WriteLine();
        }



        //method displays a yearly summary of the employees pay based on the weekly detials entered earlier
        private static void DisplayPayslip(string[] details, double taxFreeAllowance, double taxrate, double gross, double nettPay, double taxPayable)
        {
            const string DISPLAY_TAB = "{0,10}{1,-20}{2,10}";           //use to format the displayed employee details 
            const string PAGE_DIVIDER = "--------------------------";
            Console.OutputEncoding = System.Text.Encoding.UTF8;         //allow printing of unicode characters such as €

            Console.WriteLine($"Yearly pay summery for {details[0]}:");
            Console.WriteLine(PAGE_DIVIDER);
            Console.WriteLine(DISPLAY_TAB, " ", "Name", $": {details[0]}");
            Console.WriteLine(DISPLAY_TAB, " ", "EMployee ID", $": {details[1]}");
            Console.WriteLine(DISPLAY_TAB, " ", "Hours worked", $": {details[2]}");
            Console.WriteLine(DISPLAY_TAB, " ", "Hourly Rate of Pay", $": {details[3]:c2}\n");
            Console.WriteLine(PAGE_DIVIDER);
            Console.WriteLine(DISPLAY_TAB, " ", "Total Gross Pay", $": {gross * 52:c2}");
            Console.WriteLine(DISPLAY_TAB, " ", "Rate of Tax", $": {taxrate:p2}");
            Console.WriteLine(DISPLAY_TAB, " ", "Tax Free Allowance", $": {taxFreeAllowance:c2}");
            Console.WriteLine(DISPLAY_TAB, " ", "Total Tax Paid", $": {(taxPayable * 52):c2}");
            Console.WriteLine(PAGE_DIVIDER);
            Console.WriteLine(DISPLAY_TAB, " ", "Nett Pay", $": {nettPay * 52:c2}");
        }


        //method calculates the nett ay based on gross and taxable pay parameters. Assigns yearly net.
        private static double CalculateNettPay(double grossPay, double taxPayable)
        {
            double nettPay = grossPay - taxPayable;
            return nettPay;
        }


        //method calculate the tax payable of the employee
        private static double CalculateTax(double gross, double taxRate)
        {
            double taxable, taxFreeAllowance = 3000;

            switch (gross)
            {
                case double pay when gross >= 0 && gross <= 3000:
                    return 0;                       //taxable income is zero if earnings below 3000
                    
                case double pay when gross <= 34000: 
                    taxRate = 0.2;
                    break;
                case double pay when gross > 34000:
                    taxRate = 0.4;
                    break;
                default: 
                    Console.Write("Error...Gross Pay cannont be less than Zero");
                    break;
            }//END: switch(gross)

            taxable = (gross - taxFreeAllowance) * taxRate;

            return taxable;
        }//END: CalculateTax()


        //method calculate an employees gross pay
        private static double CalculateGross(string[] details)
        {
            double hours = Convert.ToDouble(details[2]);
            double rate = Convert.ToDouble(details[3]);
            return hours * rate;        
        }

        private static void GetEmployeeDetails(string[] details)
        {
            const string INPUT_TAB = "{0,-19}{1,5}";

            bool nameValid = false, idValid = false;
            bool hoursValid = false, rateValid = false, allValid = false;

            string strInput;
            const int MIN_HRS = 10, MAX_HRS = 50, MIN_PAY = 10, MAX_PAY = 65;

            
            while (!allValid)
            {               
                strInput = GetName(INPUT_TAB);
                nameValid = ValidateName(strInput);

                if (nameValid)
                {
                    strInput = GetID(INPUT_TAB);
                    idValid = ValidateID(strInput);
                    if (idValid)
                    {
                        details[2] = GetHours(INPUT_TAB);
                        hoursValid = ValidateHours(details[2], MIN_HRS, MAX_HRS);

                        if (hoursValid)
                        {
                            details[3] = GetRate(INPUT_TAB);
                            rateValid = ValidatePay(details[3], MIN_PAY, MAX_PAY);
                            if (rateValid)
                            {
                                Console.WriteLine("\nAll valid");
                                allValid = true;                                
                            }

                        }//END:if(hoursValid)      
                    }//END: if(idValid)
                }//END: if(nameValid)
            }//END: while(!allValid)     

        }//END: GetEmployeeDetails()


        //methods to retreive the details of the employee
        private static string GetRate(string INPUT_TAB)
        {           
            Console.Write(INPUT_TAB, "Hourly rate", ": ");
            return Console.ReadLine();
        }
        private static string GetHours(string INPUT_TAB)
        {
            Console.Write(INPUT_TAB, "Hours worked", ": ");
            return Console.ReadLine();
        }
        private static string GetID(string INPUT_TAB)
        {
            Console.Write(INPUT_TAB, "Employee ID", ": ");
            return Console.ReadLine();
        }
        private static string GetName(string INPUT_TAB)
        {
            Console.Write(INPUT_TAB, "Employee Name", ": ");
            return Console.ReadLine();           
        }



        //method validate hours worked (present, 10 <= hours <= 50)
        private static bool ValidateHours(string input, int minValue, int maxValue)
        {
            
            bool isValidDouble = double.TryParse(input, out double hours);

            if (isValidDouble = true && hours >= minValue && hours <= maxValue)
            {
                return true;
            }
            return false;
        }

        //method validate hours worked (present, 10 <= hours <= 50)
        private static bool ValidatePay(string input, int minValue, int maxValue)
        {
            bool isValidDouble = double.TryParse(input, out double rate);

            if (isValidDouble = true && rate >= minValue && rate <= maxValue)
            {
                return true;
            }
            return false;
        }

        //method validates the employee's ID number
        private static bool ValidateID(string input)
        {
            bool isValid = false;

            if (!(string.IsNullOrEmpty(input)) && input != String.Empty)
            {
                if (input.ToUpper().StartsWith('E') && input.Length >= 6)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        //method to validate an id input 
        private static bool ValidateName(string name)
        {
            char[] digits = "0123456789".ToCharArray();            //make a char[] from a string of digits to search input for
            //if ((!String.IsNullOrEmpty(name)) && name != String.Empty) //disallow a space or blank entry
            if (name != String.Empty)
            {
                if (name.IndexOfAny(digits) == -1)                   //disallow digits
                {
                    return true;
                }
            }
            return false;
        }
    }//END: class Program

}//END: namespace
