/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Write a program that computes taxes for a schedule
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/


using System;

namespace Part2_q4_taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // format tables
            const string DISPLAYTAB = "{0, -20}{1, -5}";

            // variable declaration / initialisation
            string maritalStatus = "";
            double earnings = 0, taxable_income = 0;
            double tax_rate = 0, tax_surcharge = 0;
            double net_pay = 0, tax_payable = 0;

            // const's for tax band and tax supplemt payments
            //const double SURCHARGE_1 = 800, SURCHARGE_2 = 4400, SURCHARGE_3 = 1600, SURCHARGE_4 = 8800;
            //const double TAX_BAND_1 = 8000;
            char again = ' ';

            // Promt user to inout marutal status and earnings           
            do
            {
                Console.WriteLine("\nWhat is your marital status");
                Console.Write(DISPLAYTAB, "(single / married", ": ");
                maritalStatus = Console.ReadLine().ToLower();


                Console.Write(DISPLAYTAB, "What are your earnings", ": ");
                earnings = double.Parse(Console.ReadLine());

                ////Test
                //Console.WriteLine(maritalStatus);
                //Console.WriteLine(taxableIncome);

                if (maritalStatus == "single" && earnings <= 8000)
                {
                    tax_rate = 0.1;
                    taxable_income = earnings;
                }
                else if (maritalStatus == "single" && earnings <= 32000)
                {
                    tax_rate = 0.15;
                    tax_surcharge = 800;
                    taxable_income = earnings - 8000;
                }
                else if (maritalStatus == "single" && earnings > 32000)
                {
                    tax_rate = 0.25;
                    tax_surcharge = 4400;
                    taxable_income = earnings - 32000;
                }
                else if (maritalStatus == "married" && earnings < 16000)
                {
                    tax_rate = 0.1;
                    tax_surcharge = 4400;
                    taxable_income = earnings - 8000;
                }
                else if (maritalStatus == "married" && earnings < 64000)
                {
                    tax_rate = 0.15;
                    tax_surcharge = 1600;
                    taxable_income = earnings - 16000;
                }
                else
                {
                    tax_rate = 0.25;
                    tax_surcharge = 8800;
                    taxable_income = earnings - 64000;
                }

                tax_payable = (taxable_income * tax_rate) + tax_surcharge;
                Console.WriteLine($"taxable ; {taxable_income}");
                net_pay = earnings - tax_payable;


                Console.WriteLine(DISPLAYTAB, "\nGross Pay", $": {earnings:c2}");
                Console.WriteLine(DISPLAYTAB, "Tax Payable", $": {tax_payable:c2}");
                Console.WriteLine(DISPLAYTAB, "Your Nett Pat is", $": {net_pay:c2})");

                while (again != 'N')
                {
                    Console.Write("\nGo again  :  ");
                    again = char.Parse(Console.ReadLine().ToUpper());
                }
            } while (again == 'Y');
            
        } // END: Main()
    }
}
