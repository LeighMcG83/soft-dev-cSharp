/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  worksheet3_switch_q3_gamer
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  30/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a program which will read in the score a gamer got
 *            |  in a game and determines their corresponding ranking, 
 *            |  given the following – you must use a switch statement 
 *            |  (but Not with 100 cases! – hint think integer division)
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

using System;

namespace worksheet3_switch_q3_gamer
{
    class Program
    {
        static double score;
        static string msg;

        static void Main(string[] args)
        {
            // declare loop-control varialbe
            char enterAnother;
            do
            {
                // var to control entry to switch based on user input
                // stops the msg in default case executing on bad input entry
                bool invalidEntry = false;
                try
                {                    
                    // Prompt user to enter a score and assign to 'score'
                    Console.Write("Enter your game score : ");
                    score = double.Parse(Console.ReadLine());
                }
                catch (Exception)       // catch bad input
                {
                    invalidEntry = true;
                    Console.WriteLine("you must enter anumber betweeon 0 and 100!!!");
                }

                if (!invalidEntry)
                {                    
                    switch (score)
                    {
                        case double score when score >= 80: msg = "Awesome dude"; break;
                        case double score when score >= 70: msg = "Your good dude"; break;
                        case double score when score >= 60: msg = "Some potential here dude"; break;
                        case double score when score >= 50: msg = "Back to the training ground dude"; break;
                        case double score when score >= 0: msg = "Don’t give up the day job dude"; break;
                        default: msg = "\n\tInvalid score entered\n"; break;
                    } //END: switch(score)
                }

              

                    // quick - action - promt's suggested switch expression below
                //string msg = score switch
                //{
                //    double score when score >= 80 => "Awesome dude",
                //    double score when score >= 70 => "Awesome dude",
                //    double score when score >= 60 => "Awesome dude",
                //    double score when score >= 50 => "Awesome dude",
                //    double score when score >= 0 => "Awesome dude",
                //    _ => "Invalid score entered",
                //};
                Console.WriteLine(msg);

                Console.Write("\n\tEnter another Score(y / n)  : ");
                enterAnother = char.Parse(Console.ReadLine().ToUpper());

            } while (enterAnother == 'Y');
        }
    }
}
