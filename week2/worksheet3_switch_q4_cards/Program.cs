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
        static public string suit = "", value = "";
        public static bool isValid = true;

        static void Main(string[] args)
        {
            string card = "";
            char askAgain = ' ';

            do
            {
                isValid = true;     // resets isValid for iteration after invalid entry
                try
                {
                    Console.WriteLine("Enter a playing car in 2 character notaion e.g.\n");
                    Console.WriteLine("\t4d -> four of diamonds");
                    Console.Write("Your Card :  ");
                    card = Console.ReadLine().ToUpper();
                }
                catch (Exception)
                {
                    isValid = false;
                    DisplayHint();
                }

                // convert the chars in index positions 0 and 1 to strings
                value = Convert.ToString(card[0]);
                suit = Convert.ToString(card[1]);

                string cardValue = GetCardValue(card);      // pass the card to the get value method and assign to string
                string cardSuit = GetCardSuit(card);      // pass the card to the get suit method and assign to string

                if (isValid)
                {
                    Console.WriteLine($"Your card was the {cardValue} of {cardSuit}");  // display the entered card if input ws validvalid
                }
               
                Console.WriteLine("\n\nDo you want to ask again?");
                askAgain = char.Parse(Console.ReadLine().ToUpper());    

            } while (askAgain == 'Y');
        } // END: Main()



                /********** USER DEFINED METHODS***********/

        //Method to diplay hint on invalid entry
        static public void DisplayHint()
        {
            Console.WriteLine("\nHint:\n\tA = Ace\n\t2....10 = 2,3,4....10\n\tJ = Jack\n\tQ = Queen\n\tK = King");
        } //END: DisplayHint()

        
        //Method to get string of card value
        static public string GetCardSuit(string card)
        {
            string suitMsg = "";
            switch (card)
            {
                case string s when suit == "H":
                    suitMsg = "Hearts";
                    break;
                case string s when suit == "D":
                    suitMsg = "Diamonds";
                    break;
                case string s when suit == "C":
                    suitMsg = "Clubs";
                    break;
                case string s when suit == "S":
                    suitMsg = "Spades";
                    break;
                default:
                    isValid = false;
                    Console.WriteLine("\n\tInvalid Suit entered");
                    DisplayHint();
                    break;
            } //END: switch(card)

            return suitMsg;
        }// END: GetCardValue()


        //Method to get string of card suit
        static public string GetCardValue(string card)
        {
            string msg = "";

            switch (card)
            {
                case string v when value == "A":
                    msg = "Ace";
                    break;
                case string v when value == "2":
                    msg = "Two";
                    break;
                case string v when value == "3":
                    msg = "Three";
                    break;
                case string v when value == "4":
                    msg = "Four";
                    break;
                case string v when value == "5":
                    msg = "Five";
                    break;
                case string v when value == "6":
                    msg = "Six";
                    break;
                case string v when value == "7":
                    msg = "Seven";
                    break;
                case string v when value == "8":
                    msg = "Eight";
                    break;
                case string v when value == "9":
                    msg = "Nine";
                    break;
                case string v when value == "10":
                    msg = "Ten";
                    break;
                case string v when value == "J":
                    msg = "Jack";
                    break;
                case string v when value == "Q":
                    msg = "Queen";
                    break;
                case string v when value == "K":
                    msg = "King";
                    break;
                default:
                    isValid = false;
                    Console.WriteLine("Invalid card value entered");
                    break;
            } //END: switch(value)

            return msg;

        } // END: GetCrdSuit()

    } // END: class Program

} //END: namespace
