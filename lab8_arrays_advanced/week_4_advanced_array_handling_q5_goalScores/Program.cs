/* ==========================================================================================================
 * Worksheet: |  Lab 8 Advanced Array Handling
 * Program:   |  week_4_advanced_array_handling_q5_goalScores
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  18/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Purpose:   |  Using a 2 dimensional array, write a program to store the goals that 11 players scored in 5
 *            |  different matches. Print out:
 *            |    - the details for all players in the format:
 *            |        Player Match1 Match2 Match 3 Match 4 Match 5
 *            |          1      0     0      1       2        0
 *            |          2      1     0      1       0        0
 *            |          3      3     0      1       2        0
 *            |    and so on, down to 11 players
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * Mods:      |  
 *  _ _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * BUGS:      |  
 * ==========================================================================================================*/

using System;

namespace week_4_advanced_array_handling_q5_goalScores
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare and initialize format table for output
            const string OUTPUT_TAB = "{0, -12}{1, 15}{2, 15}{3, 15}{4, 15}";

            // declare a 2D array to store player goals in
            int[,] goalsArray = new int[11, 11];
            string[] players = { "Pat", "John", "Kim", "Betty", "Ivana",
                                 "Stephen", "Leigh", "Abdul", "Rhys", "Jessica", "Ariane"};

            //create a new object of Random() class
            Random rnd = new Random();

            /* call method to fill the array with random goal stats
             * we pass the array to fill, and a Random-type object, 'rnd',
             * which will be used to generate the random goal stats for the array */
            FIllWithRandoms(goalsArray, rnd);

            //print column headings
            Console.WriteLine(OUTPUT_TAB, "Player Name", "Match 1", "Match 2", "Match 3", "Match 4");

            // call method to print the table
            DisplayGoalStats(goalsArray, players);

        }//END: Main()


        //method will fill an array with random numbers - takes an array and a random obj as params
        static void FIllWithRandoms(int[,] goalsArray, Random rnd)
        {
            // fill the array with random numbers
            for (int player = 0; player < goalsArray.GetLength(0); player++)                      // player wil represent the row
            {
                for (int goalsStats = 0; goalsStats < goalsArray.GetLength(0); goalsStats++)      // goalsStats will represent the column
                {
                    // assign a random number < 6 to the array @ index [player][goalsScored]
                    // limits goals per game by a player to 6
                    goalsArray[player, goalsStats] = rnd.Next(7);

                }//END: for(col)

            }//END: for(row)
        }//END: FIllWithRandoms()

        // method to display the players and goal stats in the array
        static void DisplayGoalStats(int[,] goalsArray, string[] players)
        {
            // declare and initialize format table for output
            const string OUTPUT_TAB = "{0, -12}{1, 15}{2, 15}{3, 15}{4, 15}";

            // call GetLength to return the length of the row(numCols) and the number othe rows (numRows)
            int numCols = goalsArray.GetLength(0);
            int numRows = goalsArray.GetLength(1);

            for (int row = 0; row < numCols; row++)
            {
                Console.Write(OUTPUT_TAB, $"{players[row]}", $"{goalsArray[row, 0]}", $"{goalsArray[row, 1]}", $"{goalsArray[row, 2]}", $"{goalsArray[row, 3]}");
                Console.WriteLine();

            }//END:(for)
        }//END: DisplayGoalStats()


    }//END: slass Program

}//END: namespace
