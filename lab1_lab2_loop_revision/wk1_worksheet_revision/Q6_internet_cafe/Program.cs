/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  Q6. An internet cafe charges:
 *            |         - €2.00 minimum fee to use the internet for up to three hours.
 *            |         - additional €0.50 per hour for each additional hour or part thereof.
 *            |         - The maximum charge for any given session is €10.00.
 *            |
 *            |     Your program will:
 *            |         - accept the hours used by each customer.
 *            |         - Display the charge for each customer
 *            |         - Display a running total for all usage.
 *            |
 *            |     The program will have at least one method that calculates
 *            |     the charge for each customer.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * BUGS:      |     ****CALCULATIONS IVCORRECT
 * ===================================================================*/


using System;

namespace Q6_internet_cafe
{
    class Program
    {
        // declare const's for charges and sentinel value
        const double STANDARD_RATE = 2, ADDITIONAL_RATE = 0.5;
        static double subtotal = 0, additional_cost = 0, additionalHours = 0, currentCustomer = 0;
        const int END_PROGRAM = -999, BASIC_HOURS = 3;

        // declare class level display tables
        const string INPUTTAB = "{0, -25}{1, -4}";
        const string OUTPUTTAB = "{0, -25}{1, -5}";
        const string OUTPUT_2_TAB = "{0, -25}{1, -5}{2, 10}";

        static void Main(string[] args)
        {
            int hoursUsed;
            // begin loop
            do
            {
                hoursUsed = Convert.ToInt32(GetHoursUsed());    // prompt user for hours used                
                if (hoursUsed == END_PROGRAM) { break; }            // end loop if sentnel entered
                double currentCustomer = CalculateCurrentCust(hoursUsed);   // calculate charge for this customer
                subtotal = AddToSubTotal(currentCustomer);          // add this customer charge to subtotal
                DisplayCurrentCust(currentCustomer);                // Display curret customer price
                DisplaySubtotal(subtotal);                          // Display current running total

            } while (hoursUsed != -999);
            // end loop

        } // END OF Main()


        /************ USER DEFINED METHODS ************/

        // Method to prompt user for hours used
        static public double GetHoursUsed()
        {
            Console.Write(INPUTTAB, "Enter number of hours used (or -999 to quit)", ":");
            double hours = double.Parse(Console.ReadLine());

            //if (hours % 1 != 0)     // if there is a remainder
            //    { hours = (Convert.ToInt32(hours)) + 1; }
            //else
            //    { hours = Convert.ToInt32(hours); }

            hours = (hours % 1 != 0) ? hours = (Convert.ToInt32(hours)) + 1 : hours = Convert.ToInt32(hours);

            /* test */
            //Console.WriteLine("Rounded hours : " + /*hours*/);
            return hours;


        } // END OF GetHoursUsed()

        // Method to calculate this customers charge
        static public double CalculateCurrentCust(int hoursUsed)
        {
            //if (hoursUsed < BASIC_HOURS)
            //{
            //    currentCustomer = STANDARD_RATE;
            //}
            //else
            //{
            //    additionalHours = hoursUsed - BASIC_HOURS;
            //    /* test */
            //    //Console.WriteLine("Calculated additionalHours:" + additionalHours);
            //    additional_cost = (additionalHours * ADDITIONAL_RATE);
            //    currentCustomer = STANDARD_RATE + (additional_cost);
            //}

            currentCustomer = (hoursUsed < BASIC_HOURS) ? currentCustomer = STANDARD_RATE : currentCustomer = STANDARD_RATE + ((hoursUsed - BASIC_HOURS) * ADDITIONAL_RATE);

            return currentCustomer;
        } // END OF CalculateCurrentCust()


        // Method to display current cost
        static private void DisplayCurrentCust(double currentCustomer)
        {
            Console.Write(OUTPUT_2_TAB, "Customer Charge", $": {currentCustomer}", " ");
        } // END OF DisplayCurrentCust()


        // Method to subtoal the charge
        static public double AddToSubTotal(double currentCustomer)
        {
            subtotal += currentCustomer;
            return subtotal;
        }


        // Method to display current customer
        static public void DisplaySubtotal(double subtotal)
        {
            Console.WriteLine(OUTPUTTAB, "Current Total", $": {subtotal}");
        } // END: DisplaySubtotal()

    } //END: class Program 
}
