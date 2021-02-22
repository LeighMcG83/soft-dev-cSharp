/* ===================================================================
 * Worksheet: |  Lab 9 Strings
 * Program:   |  lab_9_strings_q3_findXandY.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  20/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Write a method that receives a string as an argument and 
 *            |  returns the number of times the character ‘x’ or ‘y’
 *            |  appears in the string.
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |  
 *  * _ _ _ _ | _ _ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
 * BUGS:      |  
 * ===================================================================*/

using System;
namespace lab_9_strings_q3_findXandY
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            int x = 0, y = 0;       //use to count the occrances of each letter

            //input
            Console.Write("Enter a word and I will count number of X's and Y's it contains: ");
            string word = Console.ReadLine();

            //method calls
            CountXandY(word, ref x, ref y);

            //output
            Console.WriteLine($"\nX occured {x} times");
            Console.WriteLine($"Y occured {y} times");

        }//END: Main()

        //method counts the occurances of a char in a string passed as an argument
        //pass x and y by ref => only need one method as no returns required
        static void CountXandY(string word, ref int x, ref int y)     
        {
            word = word.ToUpper();                          //do this here so we dont change the inputted value in Main()
            string letterX = "X";
            string letterY = "Y";
            int index = 0;                                  //will hold the index position of a letter if found

            foreach(char letter in word)
            {
                if (word.Contains(letterX))
                {
                    index = word.IndexOf(letterX);          //find the index of the first x
                    word = word.Remove(index, 1);           //remove the letter x from the first index it occurs at                    
                    x++;                                    //increment the number of times we found x
                }
                if(word.Contains(letterY))
                {
                    index = word.IndexOf(letterY);          //find the index of the first y
                    word = word.Remove(index, 1);           //remove the letter y from the first index it occurs at
                    y++;                                    //increment the number of times we found y
                }
            }//END: foreach()
        }//END: CountXandY()


    }//END: class Program

}//END: namespace
