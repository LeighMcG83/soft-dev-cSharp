/* ===================================================================
 * Worksheet: |  array_worksheet
 * Program:   |  array_worksheet_q2_PlayerGoals
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  09/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Use a 2 dimensional array to store the goals that 5 
 *            |  players scored in 4 different matches. 
 *            |
 *            |  Print out report of the players' stats in  a table
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  Modify the report to show the player names, 
 *            |  1= “Pat”,2 = “John”, 3 = “Kim”, 4 = “Betty”, 5 = “Ivana”
 *            |  Hint initialise an array with these
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;             
using static System.Console;


namespace array_worksheet_q2
{
    class Program
    {
        // declare and initialize format table for output
        public const string OUTPUT_TAB = "{0, -12}{1, 15}{2, 15}{3, 15}{4, 15}";
        public const string INPUT_TAB = "{0, -30}{1, 5}";

        //initializze the array of names
        static public string[] namesArray = { "Pat", "John", "Kim", "Betty", "Ivana" };

        static void Main(string[] args)
        {
            // declare a 2D array to store player goals in
            int[,] goalsArray = new int[5, 5];
            string[] players = { "Pat", "John", "Kim", "Betty", "Ivana" };

            //create a new object of Random() class
            Random rnd = new Random();

            /* call method to fill the array with random goal stats
             * we pass the array to fill, and a Random-type object, 'rnd',
             * which will be used to generate the random goal stats for the array */
            FIllWithRandoms(goalsArray, rnd);
           
            //print column headings
            Console.WriteLine(OUTPUT_TAB, "Player Name", "Match 1", "Match 2", "Match 3", "Match 4");

            // call method to print the table
            DisplayGoalStats(goalsArray);

        }// END: Main()

        //method will fill an array with random numbers - takes an array and a random obj as params
        static void FIllWithRandoms(int[,] goalsArray, Random rnd)
        {
            // fill the array with random numbers
            for (int player = 0; player < goalsArray.GetLength(0); player++)                      // player wil represent the row
            {
                for (int goalsStats = 0; goalsStats < goalsArray.GetLength(0); goalsStats++)      // goalsStats will represent the column
                {
                    // assign a random number < 11 to the array @ index [player][goalsScored]
                    // limits goals per game by a player to 6
                    goalsArray[player, goalsStats] = rnd.Next(7);

                }//END: for(col)

            }//END: for(row)
        }//END: FIllWithRandoms()
    
        // method to display the players and goal stats in the array
        static void DisplayGoalStats(int[,] goalsArray)
        {         
            // call GetLength to return the length of the row(numCols) and the number othe rows (numRows)
            int numCols = goalsArray.GetLength(0);
            int numRows = goalsArray.GetLength(1);

            for (int row = 0; row < numCols; row++)
            {
                Console.Write(OUTPUT_TAB, $"{namesArray[row]}", $"{goalsArray[row,0]}", $"{goalsArray[row, 1]}", $"{goalsArray[row, 2]}", $"{goalsArray[row, 3]}");

                Console.WriteLine();
            }//END:(for)
        }//END: DisplayGoalStats()

    }//END: class
}