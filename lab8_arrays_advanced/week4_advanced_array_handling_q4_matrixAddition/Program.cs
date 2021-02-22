/* ===================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week4_advanced_array_handling_q4_matrixAddition
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  18/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a program add two 3 X 3 matrices
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;

namespace week4_advanced_array_handling_q4_matrixAddition
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //setup
            //declare 2 3x3 arrays
            int[,] MatrixA = { {2, 4, 6},
                               {6, 8, 2},
                               {2, 7, 4} };
            int[,] MatrixB = { {2, 4, 6},
                               {6, 8, 2},
                               {2, 7, 4} };
            int[,] ResultMatrix = new int[3, 3];

            //method calls
            Add3x3Matrix(MatrixA, MatrixB, ResultMatrix);   //pass the matrices to be added and matrix to store result
            Display2dMatrix(ResultMatrix);


        }//END: Main()

        /*****************************************************/
        /*************  USER DEFINED METHODS     *************/
        /*****************************************************/

        //method that adds 2 3x3 matrices
        static void Add3x3Matrix(int[,] MatrixA, int[,] MatrixB, int[,] ResultMatrix)
        {
            int length = MatrixA.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //Z[row,col] = x[row,col] + y[row,col];
                    ResultMatrix[i, j] = MatrixA[i, j] + MatrixB[i, j];
                }//END: inner for()
            }//END: outer for()

        }//END: Add3x3Matrix()

        //method will display the values in a 2d matrix
        static void Display2dMatrix(int[,] matrix)
        {
            //commented out- find out how can call method from within itself
            //Console.WriteLine($"The result of adding {Display2dMatrix(MatrixA)} and {Display2dMatrix(MatrixB)} is:");

            Console.WriteLine("The result of adding the 2 matrices is: \n\t");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[j,j] + " ");
                }
                Console.WriteLine();
            }
        }//END: DisplayResultMatrix()

    }//END: class Program

}//END: namespace
