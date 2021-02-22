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
            
            double[,] empty = { { } };
            Console.WriteLine($"empty array Length = {empty.GetLength(1)}");

            int[,] a1 = { { 1, 2, 3 },
                          {7, 4 , 6 },
                          { 7, 8, 9 } };

            int[,] a2 = { { 1, 2, 3 },
                          {7, 4 , 6 },
                          { 7, 8, 9 } };

            bool isFound = false;
            isFound = FindIn2DArray(numbers);

            Console.WriteLine(isFound + "\n");

            Console.WriteLine($"number is at column {GetColumnIndex(13, numbers)}");
            Console.WriteLine($"number is at row {GetRowIndex(13, numbers)}");
            //double avg = GetRowAverage(1, dblNums);
            double avg = GetRowAverage(0, empty);


            Console.WriteLine(avg);

            Console.Write(Multipliable(a1, a2));

        }//END: Main()


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
            double total = 0, avg = -1;
            int length = table.GetLength(row);
            Console.WriteLine($"Length: {length}");

            if ((length -1)== 0)
            {
                return avg;
            }

            else
            {
                for (int i = row; i == row; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        total += table[i, j];
                        avg = total / length;
                    }
                }
            }
            return avg;
        }


        static bool Multipliable(int[,] a1, int[,] a2)
        {
            int length = a1.GetLength(0);
            bool isSuitable = false;

            for (int row = 0; row < length; row++)
            {
                if (a1.GetLength(row) == a2.GetLength(row))
                {                
                    isSuitable = true;
                }
            }

            return isSuitable;
        }



    }
}
