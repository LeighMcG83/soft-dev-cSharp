/* ===================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_8_advanced_array_handling_q3_storeSales
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  18/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  A company has three regions, with five stores in each region.
 *            |  Input the weekly sales for each store. Find the average weekly
 *            |  sales for each region and for the whole company.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;
using System.Text;

namespace week_8_advanced_array_handlng_q3_storeSales
{
    class Program
    {
        static void Main(string[] args)
        {

            //setup
            double[,] salesArray = new double[3,6];             //declare an array to store sales for 3 regions with 5 stores each
            salesArray[0, 0] = 1;                               //region1
            salesArray[1, 0] = 2;                               //region2
            salesArray[2, 0] = 3;                               //region3
            double[] avgRegions = new double[3];                //declare the array that will store the average sales for each region
            double average = 0;                                 //var will store the returned average value of all sales
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Encoding to allow us to print sepcial characters to the screen.

            //method calls
            PopulateSalesArray(salesArray);                 //call method to get user to enter the sales
            PrintAllSales(salesArray);                      //Test print the contents of the array
            AverageSalesRegional(avgRegions, salesArray);   //pass the avgArray to store values into, salesArray to get sales from
            average = AverageSalesOverall(salesArray);      //call the method to calculate the ovall sales avg and assign it to var, average
            PrintSalesAverageReport(average, avgRegions);   //pass the average variable for overall average and the array of regional avgs

        }//END: Main()


        /*****************************************************/
        /*************  USER DEFINED METHODS     *************/
        /*****************************************************/

        //method to get sales figures for the 15 stores
        static void PopulateSalesArray(double[,] salesArray)
        {
            int numRows = salesArray.GetLength(1);          //get the number of rows in the array
            int numCols = salesArray.GetLength(0);          //get the number of cols in the array
            const string INPUT_TAB = "{0, 8}{1,-12}{2,-12}";

            Console.WriteLine($"Enter sales for:"); 
            for (int row = 0; row < numCols; row++)
            {
                for (int col = 1; col < numRows; col++)    //start at col 1 as col 0 hold the region
                {
                    Console.Write(INPUT_TAB, "", $"Region {row}", $"store {col}:");
                    salesArray[row, col] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();
            }//END: for()
        }//END: PopulateSalesArray()


        //method calculates the average of the sales for each region
        static void AverageSalesRegional(double[] avgArray, double[,] salesArray)
        {
            double total = 0;
            int region = 0;                                 //use to track the row in avgArray, increment at end of each iteration of inner loop 
            int numStrores = salesArray.Length - 1;         //length = 6, 1st value reps. the region number => 5 (length = 1) is number of sales

            for (int i = 0; i < salesArray.GetLength(0); i++)
            {
                total = 0;                                  //reset the value in total for the next region
                for (int j = 1; j < salesArray.GetLength(1); j++)   //start at 1 so we dont add the 'region-number' to the sales
                {
                    total += salesArray[i, j];              //accumulate the sales
                }
                avgArray[region] = total / numStrores;
                region++;                                   //move to next row in array, i.e next region
            }//END: for()
        }//END: AverageSalesRegional()


        //method calculates and returns the average of the sales for all regions
        static double AverageSalesOverall(double[,] salesArray)
        {
            double total = 0, average = 0;
            int numStrores = salesArray.Length - 1; //length = 6, 1st value reps. the region number => 5 (length = 1) is number of sales

            for (int i = 0; i < salesArray.GetLength(0); i++)
            {
                for (int j = 1; j < salesArray.GetLength(1); j++)   //start at 1 so we dont add the 'region-number' to the sales
                {
                    total += salesArray[i, j];      //accumulate the sales
                }
                average = total / numStrores;
            }//END: for()
            return average;
        }//END: AverageSalesRegional()


        //method that prints all the values in a 2d array passed to it
        static void PrintAllSales(double[,] salesArray)
        {
            for (int i = 0; i < salesArray.GetLength(0); i++)
            {     
                for (int j = 0; j < salesArray.GetLength(1); j++)
                {
                    Console.Write(salesArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }//END: PrintAllSales()

        //method that prints a sales report of the averages for regions and averall average
        static void PrintSalesAverageReport(double average, double[] avgRegions)
        {
            const string OUTPUT_TAB = "{0,-35}{1,10}";
            Console.WriteLine(OUTPUT_TAB,"The overall sales average", $": {average:c2}");
            for (int i = 0; i < avgRegions.Length; i++)
            {
                Console.WriteLine(OUTPUT_TAB, $"Region {i}", $": {avgRegions[i]:c2}");
            }
        }//END: PrintSalesAverageReport()

    }//END: class Program

}//END: namepsace
