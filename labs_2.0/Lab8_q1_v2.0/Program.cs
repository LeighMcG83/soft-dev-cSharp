/* 
 * //Q1.(b)
            
    * b) Repeat the computation of part a 100 times, 
    *    and for each position in the array, report
    *    the number of times that the fist occurrence 
    *    of a 7 in the array is at that position             

    Q2
    * Generate an array of 10,000 random numbers from zero to four.
    * Report the percentage of each of the numbers, zero, one, two,
    * three and four in the array
 

     Q3
     * A company has three regions, with five stores in each region. Input the weekly sales for 
     * each store. Find the average weekly sales for each region and for the whole company
     * 
     * 
     */

using System;

namespace Lab8_q1_v2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            const string QUIT = "q";
            string menuChoice;
            do
            {
                menuChoice = GetMenuChoice();
                switch (menuChoice)
                {
                    case "1a":      //Generate an array of 20 random integers from zero to nine. Search for the first occurrence, if any, of the number 7,
                        RunQ1a();
                        break;
                    case "1b":      //Repeat the computation of part a 100 times, and for each position in the array, report the number of times that the fist occurrence of a 7 in the array is at that position
                        RunQ1b();
                        break;
                    case "2":       //Generate an array of 10,000 random numbers from zero to four. Report the percentage of each of the numbers, zero, one, two, three and four in the array
                        RunQ2();
                        break;
                    case "3":       //generate sales for 5 stores in 3 regions, calc and display regional and national avg's
                        RunQ3();
                        break;
                    case "4":       //add 2 3x3 matrices
                        RunQ4();
                        break;
                    case "5":       //store the goals that 11 players scored in 5 different matches.
                        int[,] PlayerStats = new int[11, 5];
                        //TestPrintMultiArrayDimensions(PlayerStats);
                        int rows = PlayerStats.GetLength(0);
                        int cols = PlayerStats.GetLength(1);
                        int playerNumber = 1;
                        string input = "";
                        try
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                Console.WriteLine($"Player {playerNumber}:");
                                for (int j = 0; j < cols; j++)
                                {
                                    Console.Write($"Enter Goals scored on match {j + 1}: ");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input, out int validGoals))
                                    {
                                        PlayerStats[i, j] = validGoals;
                                    }
                                }
                                playerNumber++;
                            }
                        }
                        catch(IndexOutOfRangeException ex)
                        {
                            Console.WriteLine("Array index out of bounds while entering goals scored\n" + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unspecifed Exception thorn while filling golas scored array" + ex.Message);
                        }
                        Console.WriteLine($"{"Player", -8}{"Match1", -8}{"Match1",-8}{"Match2",-8}{"Match3",-8}{"Match4",-8}{"Match5",-8}");
                        DisplayMultiArray(PlayerStats);
                        break;
                    case "q":
                        Console.WriteLine("Exiting program");
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option e.g. '1a' or '2' and press ENTER/RETURN");
                        break;
                }


            } while (menuChoice.ToLower() != QUIT);




        }//END: Main()



        private static void RunQ4()
        {
            int[,] matrixA = new int[3, 3], matrixB = new int[3, 3];
            int[,] resultMatrix = new int[3, 3];
            FillWithRandoms(matrixA, 9);
            FillWithRandoms(matrixB, 9);

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)                
                    resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];                
            }

            Console.WriteLine("Matrix A:");
            DisplayMultiArray(matrixA);
            Console.WriteLine("Matrix B:");
            DisplayMultiArray(matrixB);
            Console.WriteLine("Result:");
            DisplayMultiArray(resultMatrix);
        }


        /// <summary>
        /// Method accepts a multi dimensional array to fill with random numbers as a parameter, and a max value for each random number
        /// /// </summary>
        /// <param name="arr"></param>
        /// <param name="maxValue"></param>
        private static void FillWithRandoms(int[,] arr, int maxValue)
        {
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i,j] = rnd.Next(maxValue);
                    }
                }
                    
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - FillWithRandoms()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - FillWithRandoms()");
            }
        }

        private static void RunQ3()
        {
            double[,] RegionalSales = new double[3, 5];
            GetSalesFigures(RegionalSales);
            DisplayMultiArray(RegionalSales);

            // get average for each store
            double[] RegionalAverages = new double[RegionalSales.GetLength(0)]; //array of length == nuber of rows(regions)
            CalculateRegionalAverages(RegionalSales, RegionalAverages);
            Display1Darray(RegionalAverages);

            // get national average -> total of all sales / (rows * cols) 
            double nationalAverage = 0;
            nationalAverage = CalculateNationalAverage(RegionalSales, nationalAverage);
            Console.WriteLine("\nNational Average: " + nationalAverage);
        }

        private static double CalculateNationalAverage(double[,] RegionalSales, double nationalAverage)
        {
            for (int i = 0; i < RegionalSales.GetLength(0); i++)
            {
                for (int j = 0; j < RegionalSales.GetLength(1); j++)
                {
                    nationalAverage += RegionalSales[i, j];
                }
            }
            nationalAverage /= (RegionalSales.GetLength(0) * RegionalSales.GetLength(1));
            return nationalAverage;
        }

        /// <summary>
        /// Method takes parameters for the sales array and averages array, calculates the average of each region and stores the avg's in averages array
        /// </summary>
        /// <param name="RegionalSales"></param>
        /// <param name="averages"></param>
        private static void CalculateRegionalAverages(double[,] RegionalSales, double[] averages)
        {
            
            for (int i = 0; i < RegionalSales.GetLength(0); i++)
            {
                for (int j = 0; j < RegionalSales.GetLength(1); j++)
                {
                    averages[i] += RegionalSales[i, j];
                }
                averages[i] /= RegionalSales.GetLength(1);  //divides by the number of stores in the region
            }
        }


        /// <summary>
        /// Method gets the sales figures for all stores in all regions
        /// </summary>
        /// <param name="RegionalSales"></param>
        private static void GetSalesFigures(double[,] RegionalSales)
        {
            for (int i = 0; i < RegionalSales.GetLength(0); i++)
            {
                Console.WriteLine("Region " + (i + 1) + "\n");
                for (int j = 0; j < RegionalSales.GetLength(1); j++)
                {
                    bool isValid = false;
                    do
                    {
                        Console.WriteLine($"Enter sales for store {j + 1}: ");
                        if (double.TryParse(Console.ReadLine(), out double validSaleFigure));
                        {
                            isValid = true;
                            RegionalSales[i, j] = validSaleFigure;
                        }
                    } while (!isValid);
                }
            }
        }

        private static void TestPrintMultiArrayDimensions(int[,] arr)
        {
            Console.WriteLine("Rows: " + arr.GetLength(0));
            Console.WriteLine("Columns : " + arr.GetLength(1));
        }

        private static void TestPrintMultiArrayDimensions(double[,] arr)
        {
            Console.WriteLine("Rows: " + arr.GetLength(0));
            Console.WriteLine("Columns : " + arr.GetLength(1));
        }

        private static void RunQ2()
        {
            int[] RandomNums = new int[10000];
            //fill RandomNums[] with numbers between 0 and 4
            FillWithRandoms(RandomNums, 4);
            double[,] CountOccuraces = new double[2, 4];    //row[0] == total occurances, row[1] == percentage that value occured
            CalculateOccuraceTotals(RandomNums, CountOccuraces);
            CalculatePectentagesOfOccurances(CountOccuraces);
            DisplayMultiArray(CountOccuraces);
            Console.WriteLine("\n\n");
        }

        private static void RunQ1b()
        {
            int[,] NumberArray100 = new int[101, 20];   //101 rows as last row will store the count of occurances
            GetAllOccurance(NumberArray100, 7);
            DisplayMultiArray(NumberArray100);
            Console.WriteLine("\n\n");
        }

        private static void RunQ1a()
        {
            int[,] NumberArray = new int[2, 20];
            FillFirstRow(NumberArray);
            DisplayMultiArray(NumberArray);
            GetFirstOccurance(NumberArray, 7);
            Console.WriteLine("\n\n");
        }


        /// <summary>
        /// Method Displays Main Menu to user and returns a validated string input
        /// </summary>
        /// <returns>The users input when valid</returns>
        private static string GetMenuChoice()
        {
            string input;
            bool validChoice;
            do
            {
                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("1a. Question 1 (a)");
                Console.WriteLine("1b. Question 1 (b)");
                Console.WriteLine("2. Question 2");
                Console.WriteLine("3. Question 3");
                Console.WriteLine("4. Question 4");
                Console.WriteLine("5. Question 5");
                Console.WriteLine("Q. Quit");
                Console.Write("Choice: ");
                input = Console.ReadLine();
                validChoice = CheckInputIsValid(input);               
            } while (input.ToLower() != "q" && !validChoice);
            Console.WriteLine("\n");
            return input;
        }


        /// <summary>
        /// Method checks the user input from Main menu is a valid choice
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true if the user's choice is a valid choice, else returns false</returns>
        private static bool CheckInputIsValid(string input)
        {
            string[] ValidMenuChoices = { "1a", "1b", "2", "3", "4", "5", "6", "7", "8", "9", "q" };

            bool isValid = false;
            if (input.ToLower() == "q")
                return isValid;
            else
            {
                for (int i = 0; i < ValidMenuChoices.Length; i++)
                {
                    if (input == ValidMenuChoices[i])
                        isValid = true;                    
                }
            }
            if(isValid == false)
            {
                Console.WriteLine("Invalid choice");
                isValid = false;
            }
            return isValid;
        }


        /// <summary>
        /// Method calculates percentage of occurances of random numbers in a multi-dimensional array, takes the array of random nums and array to store the counts in as parameteres
        /// </summary>
        /// <param name="CountOccuraces"></param>
        private static void CalculatePectentagesOfOccurances(double[,] CountOccuraces)
        {
            try
            {
                for (int i = 1; i < CountOccuraces.GetLength(0); i++)
                {
                    for (int j = 0; j < CountOccuraces.GetLength(1); j++)
                        CountOccuraces[1, j] = (CountOccuraces[0, j] / 10000) * 100;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - CalculatePectentagesOfOccurances()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - CalculatePectentagesOfOccurances()");
            }
        }

        /// <summary>
        /// Method calculates the number of occurances of each random number in a multi-dimensional array, takes the array of random nums and array to store the counts in as parameteres
        /// </summary>
        /// <param name="RandomNums"></param>
        /// <param name="CountOccuraces"></param>
        private static void CalculateOccuraceTotals(int[] RandomNums, double[,] CountOccuraces)
        {
            foreach (var num in RandomNums)
            {
                switch (num)
                {
                    case 0: CountOccuraces[0, 0]++; break;
                    case 1: CountOccuraces[0, 1]++; break;
                    case 2: CountOccuraces[0, 2]++; break;
                    case 3: CountOccuraces[0, 3]++; break;
                    case 4: CountOccuraces[0, 4]++; break;
                    default:
                        Console.WriteLine("Array Error - examined num was out of range (0-4)");
                        break;
                }
            }
        }


        /// <summary>
        /// Method takes as a parameter a 1d array and fills it with random numbers between zero and a specified integer
        /// </summary>
        /// <param name="RandomNums"></param>
        private static void FillWithRandoms(int[] RandomNums, int maxValue)
        {
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < RandomNums.Length; i++)
                    RandomNums[i] = rnd.Next(maxValue);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - FillWithRandoms()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - FillWithRandoms()");
            }
        }

        /// <summary>
        /// Method takes as a parameter a 1 dimensional integer array and displays its elements, space separated, on a single line
        /// </summary>
        /// <param name="arr"></param>
        private static void Display1Darray(int[] arr)
        {
            foreach (var num in arr)
                Console.Write(num + " ");
        }

        /// <summary>
        /// Method takes as a parameter a 1 dimensional double array and displays its elements, space separated, on a single line
        /// </summary>
        /// <param name="arr"></param>
        private static void Display1Darray(double[] arr)
        {
            foreach (var num in arr)
                Console.WriteLine(num);
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
            try
            {
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
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - GetAllOccurance()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - GetAllOccurance()");
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
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                    if (i == 99)
                        Console.WriteLine("----------------------------------------");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - DisplayMultiArray()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - DisplayMultiArray()");
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
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write($"{arr[i, j]:f2} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - DisplayMultiArray()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - DisplayMultiArray()");
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
            try
            {
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
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "\nIndex out of range - GetFirstOccurance()");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified error thrown - GetFirstOccurance()");
            }
        }


    }
}
