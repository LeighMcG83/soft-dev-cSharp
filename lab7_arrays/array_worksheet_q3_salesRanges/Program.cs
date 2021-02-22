/* ===================================================================
 * Worksheet: |  arrays_worksheet
 * Program:   |  array_worksheet_q3_salesRanges
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  13/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  A shop requires a program that determines how many customers 
 *            |  have made purchases in each of the following ranges:
 *            |     0-99.99 euro,
 *            |     100-199.99 euro, 
 *            |     200-399.99 euro, 
 *            |     400-599.99 euro
 *            |     600+
 *            |  Program will print a report showing the number of sales in each 
 *            |  of the ranges.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  ***Not incrementig the value in salesRanf=geCount indexes
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;


namespace array_worksheet_q3_salesRanges
{
    class Program
    {
        //declare and initialize format tables
        const string INPUT_TAB = "{0, -30}{1,5}";
        const string OUTPUT_TAB = "{0, -15}{1,25}";

        //initialize public array to store the sales in
        static public double[] salesArray = new double[100];
        static public string[] rangeNames = { "000-99.99", "100-199.99", "200-399.99", "400-599.99", "600+" };
        static public int[] salesRangeCount = new int[5];   //array will store the number of sales for each range

        // public variable to count the sales in a range
        static public int count = 0;

        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            OutputEncoding = System.Text.Encoding.UTF8;

            ReadInputs();       //call method to get sales inputs
            PrintSales();       //call method to print the report

        }//END: Main()


        //method to read sales inputs from the user, method returns the number of values entered
        static int ReadInputs()
        {                                  
            const int QUIT = -999;      //sentinel value that will allow user to exit
            double input = 0;
            int index = 0;
            do
            {
                Console.Write(INPUT_TAB, "Enter sale amount (or -999 to quit)", ": ");
                input = Convert.ToDouble(Console.ReadLine());
                if (input != QUIT) { count++; }                 // only increment if value entered wasnt -999
                CheckRange(input);                              // check ths sale catgory and inncrement its count
                salesArray[index] = input;                      //assign th input to the array
                index++;                                        //increment the index position
                //test
                //DisplayArray(salesArray);
                //test 
                //DisplayArray(salesRangeCount);                
            } while (input != QUIT);                            //listen for sentinel value
            
            return count;
        }// END: ReadInputs()

        // method checks which sales range input is in and increments number of sales in that range
        static void CheckRange(double input)
        {            
            if (input > 0 && input < 100)                          //check the value if the sale and ++ appropriate counter
            {
                salesRangeCount[0]++;
                //test
                //Console.WriteLine($"Under 100 count: {salesRangeCount[0]}");
            }
            else if (input >= 100 && input < 200) 
            {
                salesRangeCount[1]++;
                //test
                //Console.WriteLine($"100 to 200 count: {salesRangeCount[1]}");
            }
            else if (input >= 200 && input < 400) 
            {
                salesRangeCount[2]++;
                //test
                //Console.WriteLine($"200 to 400 count: {salesRangeCount[2]}");
            }
            else if (input >= 400 && input < 600) 
            {
                salesRangeCount[3]++; 
                //test
                //Console.WriteLine($"200 to 400 count: {salesRangeCount[3]}"); 
            }
            else if(input >= 600) 
            { 
                salesRangeCount[4]++;
                //test
                //Console.WriteLine($"Over 600 count: {salesRangeCount[4]}");
            } else
            {
                Console.WriteLine("Invalid....sale not recorded");
            }
        }//END: CheckRange()

        //method prints the number of sales for each sales category
        static public void PrintSales()
        {
            Console.WriteLine(OUTPUT_TAB, "Sales Range", "Number of Sales");
            for (int row = 0; row < count; row++)
            {
                Console.WriteLine(OUTPUT_TAB, $"{rangeNames[row]}", $"{salesRangeCount[row]}");
            }
        }
        //TEST METHOD - displays the elements in an array
        static void DisplayArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //TEST METHOD - displays the elements in an array
        static void DisplayArray(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //TEST METHOD - displays the elements in an array
        static void DisplayArray(double[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");               
            }
            Console.WriteLine();
        }



    }//END: class 

}//END: namespace
