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
 * Mods:      | 
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
        public const string OUTPUT_TAB = "{0, -8}{1, 8}{2, 8}{3, 8}{4, 8}";
        public const string INPUT_TAB = "{0, -30}{1, 5}";

        static void Main(string[] args)
        {
            

            // declare vars for the number of players and matches 
            //int numPlayers, numGames;


            ////ask user how many games and players to store stats for
            //Console.WriteLine(INPUT_TAB,"How many players do you want to enter statistics for",": ");
            //bool input = int.TryParse(Console.ReadLine(), out numPlayers);
            //Console.WriteLine(INPUT_TAB, "How many matches do you want to enter statistics for", ": ");
            //input = int.TryParse(Console.ReadLine(), out numGames);

            // declare a 2D array to store player goals in
            int[,] goalsArray = new int[5, 5];

            //create a new object of Random()
           //Random rnd = new Random();

            /* call method to fill the array with random goal stats
             * we pass the array to fill and a Random-type object, 'rnd', which will be used 
             * to generate the random goal stats for the array */
            //FIllWithRandoms(goalsArray);

            ////print column headings
            //Console.WriteLine(OUTPUT_TAB, "Player #", "Match 1", "Match 2","Match 3", "Match 4");

            //// call method to print the table
            //DisplayGoalStats(goalsArray);

        }// END: Main()

        //method will fill an array with random numbers - takes an array and a random obj as params
        static void FIllWithRandoms(int[,] goalsArray, Random rnd)
        {
            // fill the array with random numbers
            for (int player = 0; player < goalsArray.Length; player++)                      // player wil represent the row
            {
                for (int goalsStats = 0; goalsStats < goalsArray.Length; goalsStats++)      // goalsStats will represent the column
                {
                    // assign a random number < 11 to the array @ index [player][goalsScored]
                    // limits goals per game by a player to 10
                    goalsArray[player, goalsStats] = rnd.Next(11);

                }//END: for(col)

            }//END: for(row)
        }//END: FIllWithRandoms()
    
        // method to display the players and goal stats in the array
        static void DisplayGoalStats(int[,] goalsArray)
        {
            //const string OUTPUT_TAB = "{0, -10}{1, 8}";

            // call GetLength to return the length of the row(numCols) and the number othe rows (numRows)
            int numCols = goalsArray.GetLength(0);
            int numRows = goalsArray.GetLength(1);

            for (int row = 0; row < numCols; row++)
            {
                Console.Write($"Player{row}");

                for (int col = 0; col < numCols; col++)
                {
                    Console.Write($"{goalsArray[row, col]}");
                }//END: inner for()
            
            }//END: outer(for)
        }//END: DisplayGoalStats()

    }//END: class
}