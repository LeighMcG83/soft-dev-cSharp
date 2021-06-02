using System;

namespace Lab8_q1_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] NumberArray = new int[2, 20];

            Console.WriteLine("Rows: " + NumberArray.GetLength(0));
            Console.WriteLine("Columns : " + NumberArray.GetLength(1));

            FillFirstRow(NumberArray);
            DisplayMultiArray(NumberArray);

            //Q1.(a)
            GetFirstOccurance(NumberArray, 7);
            Console.WriteLine("\n\n");

            //Q1.(b)
            /*
             * b) Repeat the computation of part a 100 times, 
             *    and for each position in the array, report
             *    the number of times that the fist occurrence 
             *    of a 7 in the array is at that position
             */
            int[,] NumberArray100 = new int[101, 20];   //101 rows as last row will containt the count of occurances
            GetAllOccurance(NumberArray100, 7);
            DisplayMultiArray(NumberArray100);
            Console.WriteLine("\n\n");


            //NumberArray[1, (NumberArray[i, j] % 10) - 1]++;



        }//END: Main()


        /// <summary>
        /// Method takes as parameters a multi-dimensional array and an integer number to search for
        /// and records the number of occuraces of the searched number at each location in the array
        /// </summary>
        /// <param name="NumberArray100"></param>
        /// <param name="searchNum"></param>
        private static void GetAllOccurance(int[,] NumberArray100, int searchNum)
        {
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < NumberArray100.GetLength(1); j++)
                {
                    NumberArray100[i, j] = rnd.Next(0, 9);
                    if (NumberArray100[i, j] == searchNum)
                    {
                        NumberArray100[100, j]++;
                    }
                }

            }
        }


        /// <summary>
        /// Method takes as a parameter, a multi-dimensional array and populates the first row with random integers between 0 and 9
        /// </summary>
        /// <param name="NumberArray"></param>
        private static void FillFirstRow(int[,] NumberArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < 1; i++)         // fill 1st row with random nums
            {
                for (int j = 0; j < NumberArray.GetLength(1); j++)
                {
                    NumberArray[i, j] = rnd.Next(0, 9);
                }
            }
        }

        /// <summary>
        /// Method takes as a parameter a multi-dimensional array to display
        /// </summary>
        /// <param name="NumberArray"></param>
        private static void DisplayMultiArray(int[,] NumberArray)
        {
            int rows = NumberArray.GetLength(0);
            int cols = NumberArray.GetLength(1);

            //display the multi dimensional array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(NumberArray[i, j] + " ");
                }
                Console.WriteLine();
                if (i == 99)
                {
                    Console.WriteLine("----------------------------------------");

                }

            }
        }

        /// <summary>
        /// Method takes as parameters a multi-dimensional array and an integer number to search for
        /// </summary>
        /// <param name="NumberArray"></param>
        /// <param name="searchNum"></param>
        private static void GetFirstOccurance(int[,] NumberArray, int searchNum)
        {
            int cols = NumberArray.GetLength(1);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (NumberArray[i, j] == searchNum)
                    {
                        Console.WriteLine($"{searchNum} occured first at index position: " + j);
                        break;
                    }
                }
            }
        }


    }
}
