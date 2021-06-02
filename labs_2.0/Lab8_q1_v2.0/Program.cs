using System;

namespace Lab8_q1_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] NumberArray = new int[2, 20];

            Console.WriteLine("Rows: " + NumberArray.GetLength(0));
            Console.WriteLine("Columns : " + NumberArray.GetLength(1));

            for (int i = 0; i < 1; i++)         // fill 1st row with random nums
            {
                for (int j = 0; j < NumberArray.GetLength(1); j++)
                {
                    NumberArray[i, j] = rnd.Next(0, 9);
                }
            }

            DisplayMultiArray(NumberArray);

            //Q1.(a)
            GetFirstOccurance(NumberArray, 7);


            //Q1.(b)
            /*
             * b) Repeat the computation of part a 100 times, 
             *    and for each position in the array, report
             *    the number of times that the fist occurrence 
             *    of a 7 in the array is at that position
             */

            //NumberArray[1, (NumberArray[i, j] % 10) - 1]++;



        }//END: Main()

        /// <summary>
        /// Method takes a parameter a multi-dimensional array to display
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
