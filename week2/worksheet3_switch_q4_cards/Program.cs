/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  worksheet3_switch_q4_cards
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  30/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  program that takes user input describing playing cards 
 *            | in a 2 string notation and returns a writeline describing the card
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/

using System;

namespace worksheet3_switch_q4_cards
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string card = "";

            try
            {
                Console.WriteLine("Enter a playing car in 2 character notaion e.g.\n");
                Console.WriteLine("\t4d -> four of diamonds");
                Console.Write("Your Card :  ");
                card = Console.ReadLine().ToUpper();
            }
            catch (Exception)
            {
                DisplayHint();
            }
            
            string value = Convert.ToString(card[0]), suit = Convert.ToString(card[1]);
            
            
            switch (card)
            {
                case string c when suit == "H":
                    Console.WriteLine($"{value} of Hearts");
                    break;
                case string c when suit == "D":
                    Console.WriteLine($"{value} of Diamonds"); 
                    break;

                case string c when suit == "C":
                    Console.WriteLine($"{value} of Clubs");
                    break;

                case string c when suit == "S":
                    Console.WriteLine($"{value} of Spades");
                    break;

                default:
                    DisplayHint();
                    break;
            } //END: switch(card)

        } // END: Main()

        /********** USER DEFINED METHODS***********/

        //Method to diplay hint on invalid entry
        static public void DisplayHint()
        {
            Console.WriteLine(@"Invalid entry format",
                        "\nHint:",
                        "\tA = Ace",
                        "\t2....10 = 2,3,4....10",
                        "\tJ = Jack",
                        "\tQ = Queen",
                        "\tK = King");
        } //END: DisplayHint()

    } // END: class Program
}
