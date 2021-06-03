using System;

namespace Lab8_q1_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] NumberArray = new int[2, 20];

            //Console.WriteLine("Rows: " + NumberArray.GetLength(0));
            //Console.WriteLine("Columns : " + NumberArray.GetLength(1));

            //FillFirstRow(NumberArray);
            //DisplayMultiArray(NumberArray);

            //Q1.(a)
            //GetFirstOccurance(NumberArray, 7);
            //Console.WriteLine("\n\n");

            //Q1.(b)
            /*
             * b) Repeat the computation of part a 100 times, 
             *    and for each position in the array, report
             *    the number of times that the fist occurrence 
             *    of a 7 in the array is at that position
             */
            //int[,] NumberArray100 = new int[101, 20];   //101 rows as last row will store the count of occurances
            //GetAllOccurance(NumberArray100, 7);
            //DisplayMultiArray(NumberArray100);
            //Console.WriteLine("\n\n");


            /* Q2 
             * Generate an array of 10,000 random numbers from zero to four.
             * Report the percentage of each of the numbers, zero, one, two, 
             * three and four in the array
             */
            int[] RandomNums = new int[10000];
            FillWithRandoms(RandomNums, 4);
            double[,] CountOccuraces = new double[2,4];

            /* check logic:
             * 
             * switch()
             * FillWithRandoms()
             * CountOccurances()
             */
            foreach (var num in RandomNums)
            {
                switch (num)
                {
                    case 0: CountOccuraces[0,0]++; break;
                    case 1: CountOccuraces[0,1]++; break;
                    case 2: CountOccuraces[0,2]++; break;
                    case 3: CountOccuraces[0,3]++; break;
                    case 4: CountOccuraces[0,4]++; break;
                    default:
                        Console.WriteLine("Array Error - examined num out of range");
                        break;
                }
            }
            for (int i = 1; i < CountOccuraces.GetLength(1); i++)
            {
                CountOccuraces[1, i] = (CountOccuraces[0, i] / RandomNums.Length) * 100;
            }
            DisplayMultiArray(CountOccuraces);

        }//END: Main()


        /// <summary>
        /// Method takes as a parameter a 1d array and fills it with random numbers between zero and a specified integer
        /// </summary>
        /// <param name="RandomNums"></param>
        private static void FillWithRandoms(int[] RandomNums, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < RandomNums.Length; i++)
            {
                RandomNums[i] = rnd.Next(maxValue);
            }
        }

        /// <summary>
        /// Method takes as a parameter a 1 dimension array and displays its elements, space separated, on a single line
        /// </summary>
        /// <param name="RandomNums"></param>
        private static void Display1Darray(int[] RandomNums)
        {
            foreach (var num in RandomNums)            
                Console.Write(num + " ");  
        }


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
        /// Method takes as a parameter a multi-dimensional integer array to display
        /// </summary>
        /// <param name="arr"></param>
        private static void DisplayMultiArray(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            //display the multi dimensional array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
                if (i == 99)
                {
                    Console.WriteLine("----------------------------------------");

                }

            }
        }


        /// <summary>
        /// Method takes as a parameter a multi-dimensional double array to display
        /// </summary>
        /// <param name="arr"></param>
        private static void DisplayMultiArray(double[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            //display the multi dimensional array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{arr[i, j]:f2} ");
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
