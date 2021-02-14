using System;

namespace test_2D_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = { {22, 1, 2, 3 },
                               {11, 2, 3, 45 } };
            double[,] dblNums = { { 1, 2, 3, 3 },
                                  { 5, 6 , 6, 5 },
                                  { 7, 8, 9, 2 } };
            bool isFound = false;

            //isFound = FindIn2DArray(numbers);

            //Console.WriteLine(isFound + "\n");

            //Console.WriteLine($"number is at column {GetColumnIndex(13, numbers)}");
            //Console.WriteLine($"number is at row {GetRowIndex(13, numbers)}");
            double avg = GetRowAverage(0, dblNums);
            Console.WriteLine(avg);

            avg = GetRowAverage(1, dblNums);
            Console.WriteLine(avg);

            avg = GetRowAverage(2, dblNums);
            Console.WriteLine(avg);
        }
        static bool FindIn2DArray(int[,] inputArray)
        {
            // only need the method body here
            
            bool isFound = false;
            for (int row = 0; row < inputArray.GetLength(0); row++)
            {
                for (int col = 0; col < inputArray.GetLength(1); col++)
                {
                    if (inputArray[row, col] == 45)
                    {
                        isFound = true;
                        return isFound;
                    }
                }
            }
            return isFound;
        }

        static int GetColumnIndex(int number, int[,] inputArray)
        {
            int row = 0, col = 0;
            for (row = 0; row < inputArray.GetLength(0); row++)
            {
                for (col = 0; col < inputArray.GetLength(1); col++)
                {
                    if (inputArray[row,col] == number)
                    {
                        return col;
                    }
                }
            }
            return -1;
        }

        static int GetRowIndex(int number, int[,] inputArray)
        {
            int row = 0, col = 0;
            for (row = 0; row < inputArray.GetLength(0); row++)
            {
                for (col = 0; col < inputArray.GetLength(1); col++)
                {
                    if (inputArray[row, col] == number)
                    {
                        return row;
                    }
                }
            }
            return -1;
        }

        static double GetRowAverage(int row, double[,] table)
        {
            double total = 0, average = 0;
            for (int r = row; r == row; r++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    total += table[row, col];
                }
                average = total / table.GetLength(0);
                return average;
            }
            return -1;
        }
    }
}
