/* =======================================================================
 * Worksheet: |  worksheet3_AdvancedLoops
 * Program:   |  worksheet3_advLoops_q4_sales
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  03/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Program that asks the user to enter:
 *            |      - today’s sales for five stores. 
 *            |  The program will then display:
 *            |      - a bar chart comparing each stores sales. 
 *            |  Each bar chart is created by displaying a row of asterisks. 
 *            |  Each asterisk represents €100 of sales.
 *            |  
 *            |  Sales Bar Chart
 *            |  Store1 **********
 *            |  Store2 ************
 *            |  Store3 ******************
 *            |  Store4 ********
 *            |  Store5 *******************
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/

using System;

namespace worksheet3_advLoops_q4_sales
{
    class Program
    {
        public const string DISPLAYTAB = "{0, -15}{1, -5}";        // Declare and initalize input / output display table

        static void Main(string[] args)
        {
            //setup
            Console.OutputEncoding = System.Text.Encoding.UTF8;    // Encoding for display of special characters
            const string PROG_TiTLE = "Store Sales Chart Program"; // Declare and initialize constant for the program heading
            int numStores = 5;                                     // Declare and initialize the number of stores
            double[] salesFigs = new double [numStores];           // declare array of lenght = number of stores to store the sales figures in
            Console.WriteLine("---- " + PROG_TiTLE + " ----");     // write the program title to the console

            //method calls
            PopulateSalesArray(salesFigs, numStores);          // call method to populate the array with sales figures
            Console.WriteLine("\nSales Bar-Chart");            // write sales chart heading to console
            PrintBarchart(salesFigs);                          // call method to print the chart

        } // END: Main()


        /*************** USER DEFINED METHODS *****************/
        // Method takes an array as param and populates the array
        static public void PopulateSalesArray(double[] salesFigs, int numStores)  // arrays are passed by ref as default => no return
        {
            for (int i = 0; i < numStores; i++)                        // loop 5 times for the 5 stores 
            {
                Console.Write(DISPLAYTAB, $"Enter the sales for store {i}", ": ");// prompt user to input sales figures
                string input = Console.ReadLine();
                double.TryParse(input, out double sales);      // try to Parse the string to double, assign by ref to sales if succeeds
                salesFigs[i] = sales;                          // assign the sales figure to the array of sales              
            } //END: for(numStores)
        }// END: PopulateSalesArray()

        //method prints the barchart for store sales - takes params for 
        static public void PrintBarchart(double[] salesFigs)
        {
            int length = salesFigs.Length;                     // assign the lengthof the array pass as arg to length
            for (int i = 0; i < length; i++)                   // iterate for over the array elements
            {
                int numHashes = (int)salesFigs[i] / 100;       // convert the value of sales to int and calculate the number of#'s to print
                Console.Write(DISPLAYTAB, $"Store {i}", " ");  // write current store number to console
                for (int j = 0; j < numHashes; j++)
                {
                    Console.Write("#");                        // print '#' for every €100.00
                } //END: for(numHashes)

                Console.WriteLine("\n");                       // go to new line for next store
            } //END: for(sale in salesFigs)
        } //END: PrintBarchart()

    } // END: class Program

} // END: namespace
