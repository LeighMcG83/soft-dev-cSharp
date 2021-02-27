/* ==============================================================================================
 * Worksheet: |  Lab 10 - More string Handling
 * Program:   |  lab_10_more_string_handling_.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  22/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  1.	Write a prompt “>”, then read in and return a string.
 *            |     “ I am having a great time studying c# at Sligo IT  ”
 *            |  
 *            |  2.	Take one string parameter and write out the length of a given string to the console.
 *            |  
 *            |  3.	Take one string parameter, trim all leading and trailing spaces from the string, 
 *            |     and return the new length of the string.
 *            |
 *            |  4.	Take one string parameter and output the string in upper case.
 *            |     (Can you do this without using the build in function?)
 *            |
 *            |  5.	Take one string parameter the output the string in lower case.
 *            |
 *            |  6.	Take one string parameter and output the first position of the character “g” in 
 *            |     the string. and also output the first position of the character “g” in the string
 *            |     starting from position 11.
 *            |
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/


// Library Imports.
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace lab_10_more_string_handling
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string input = "";
            char prompt = '>';

            //Question 1. - unsure what question asks for....do i read in a random string from a user?            
            string output = ReadInput(prompt);
            Console.WriteLine(output + "\n");

            ////Question 2.
            //input = GetUserInput();
            //int lengthOfString = GetLengthOfString(input);
            //Console.WriteLine($"That string is {lengthOfString} chars long.\n");

            ////Question 3.
            //Console.Write(prompt);
            //input = GetUserInput();
            //string trimmed = TrimString(input);
            //Console.WriteLine(prompt + trimmed);

            ////Question 4.
            //Console.Write(prompt);
            //input = GetUserInput();
            //string upper = ConvertToUpper(input);
            //Console.WriteLine(upper);

            ////Question 5.
            //Console.Write(prompt);
            //input = GetUserInput();
            //string lower = ConvertToLower(input);
            //Console.WriteLine(lower);

            ////Question 6.
            //Console.Write(prompt);
            //input = GetUserInput();
            //Console.Write(prompt);
            //Console.WriteLine($"The first occurance of 'g' in that string is at position {FindFirstOccurance(input, 'g')}");

            ////Question 7.
            //Console.Write(prompt);
            //input = GetUserInput();
            //Console.Write(prompt);
            //Console.WriteLine($"The last occurance of 'g' in that string is at position {input.LastIndexOf('g')}");


            ////Question 8.
            //Console.Write(prompt);
            //input = GetUserInput();
            //Console.Write(prompt);
            //Console.WriteLine($"The letter g occurs {FindAllOccurance(input, 'g')} times in total");

            ////Question 9.
            //char[] alphabet =  { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            //                     'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'}; 

            //ShowAplaphabetOccurances(alphabet, "programming");

            //Question 10.
            //input = GetUserInput();
            //Console.Write($"{input} = \"I Love Sligo\": {CheckEquality(input)}");

            ////Question 12.
            //input = GetUserInput();
            //BreakString(input);

            //Question 13.
            //input = GetUserInput();
            //CountVowels(input);

            //Question 14. - skipped
            //count and display consonant

            //Question 15.
            //string encryptedString = EncrpytString("bats");     //will change a to b and t to s
            //Console.WriteLine(encryptedString);

            ////Question 16 - Password Vallidation
            //bool valid = false;
            //while (!valid)
            //{
            //    string password = GetPassword();
            //    valid = ValidatePassword(password);
            //    if (valid)
            //    {
            //        Console.WriteLine("that is a valid password");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Password.....");
            //    }
            //}//END: while(notValid

            //Question 18 - Cheque Writer
            string[] chequeDetails = new string[3];     //date, name, amount
            decimal pay = 0.0m;

        }//END: Main()


        //method asks user for password
        private static string GetPassword()
        {

            Console.Write("Enter you password (must be at least 6 long, contain upper & lower case and a number):");
            string input = Console.ReadLine();
            return input;
        }



        //question1
        //method writes a '>' prompt and reads a string form the user and returns a predefined string
        static string ReadInput(char prompt)
        {
            string input = "";
            Console.Write(prompt);
            Console.Write("Enter a word / sentance: ");
            input = Console.ReadLine();

            Console.Write(prompt);
            Console.WriteLine($"You entered: {input}");
            Console.Write(prompt);

            return "I am having a great time studying c# at Sligo IT";
        }//END: ReadInput()

       
        //method gathers input form a user, printing a promt at beginning of each line
        static string GetUserInput()
        {
            char prompt = '>';
            string input = "";

            Console.Write(prompt);
            Console.Write("Enter a word / sentance: ");
            input = Console.ReadLine();
            
            return input;
        }//END: GetUserInput()


        //question2
        //method measures the length of a string arg
        static int GetLengthOfString(string str)
        {
            int length = str.Length;
            return length;
        }//END: GetLengthOfString()


        //question3
        //methof=d trims leading and trailing whitespace from a string and returns the new string
        static string TrimString(string str)
        {
            str = str.Trim();
            return str;
        }//END: TrimString()

        
        //question4
        //method converts a string to uppercase and returns it.
        static string ConvertToUpper(string str)
        {
            //create an array of chars from the string that we can convert 
            //each to a hex val individually
            char[] values = str.ToCharArray();
            char letter = ' ';
            string upperStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                letter = str[i];
                byte code = (byte)str[i];       //cast the current letter as a byte type
                code -= 32;                     //-32 -> 32 places between a capital and the lowercase on ASCII chart
                letter = (char)code;            //re-cast as a char - will now be uppercase
                values[i] = letter;             //assign the letter to the char array
            }

            foreach (char c in values)          //loop over the values array to get each letter
            {
                upperStr = string.Concat(upperStr, Convert.ToString(c));
            }

            return upperStr;
        }//END: ConvertToUpper()

        
        //question5
        //method converts a string arg to lowercase
        static string ConvertToLower(string str)
        {
            //create an array of chars from the string that we can convert 
            //each to a hex val individually
            char[] values = str.ToCharArray();
            char letter = ' ';
            string lowerStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                letter = str[i];
                byte code = (byte)str[i];       //cast the current letter as a byte type
                code += 32;                     //+32 -> 32 places between a capital and the lowercase on ASCII chart
                letter = (char)code;            //re-cast as a char - will now be uppercase
                values[i] = letter;             //assign the letter to the char array
            }

            foreach (char c in values)          //loop over the values array to get each letter
            {
                lowerStr = string.Concat(lowerStr, Convert.ToString(c));
            }

            return lowerStr;
        }//END: ConvertToLower()


        //question6
        //method finds the first occurance of a char arg passed to in in a given string
        static int FindFirstOccurance(string str, char c)
        {
            int first = str.IndexOf(c);

            return first;
        }//END: FindFirstOccurance()


        //question8
        //method counts all occurances of a char in a string
        static int FindAllOccurance(string str, char c)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'g')
                {
                    count++;                    //increment the number of occurances
                    str.Remove(i);              //remove the current occurance from the string so we dont find it on next iteration
                }
            }//END: for()
            return count;
        }//END: FindAllOccurance()


        //question9
        //method displays the number of occuarances of each letter in the alphabet in a string arg
        static void ShowAplaphabetOccurances(char[] alphabet, string str)
        {
            int[] occurances = new int[26];     //array to hold the number of occurances of each letter
            str = str.ToUpper();
            int alphabetIndex = 0;

           for (int i = 0; i < str.Length; i+=0)               //will reassigni in for so dont increment here as will throw out the start position
            {
                alphabetIndex = str.IndexOfAny(alphabet, i);   //return the index of the current letter in the str in the alphabet array
                occurances[alphabetIndex]++;                   //increment the value at that poition int the counter array
                i = alphabetIndex + 1;                         //set the startIndex for IndexOfAny's next search
            }

            Console.WriteLine($"Word: {str}");
            for (int i = 0; i < alphabet.Length; i++)
            {
                Console.Write(alphabet[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < occurances.Length; i++)
            {
                Console.Write(occurances[i] + " ");
            }
        }//END: ShowAplaphabetOccurances()


        //question10
        //method checks if an inputted string arg is eual to I Love Sligo
        static bool CheckEquality(string input)
        {
            if (input.Equals("I Love Sligo"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//END: CheckEquality()

        //question11.
        //method takes a string arg and breaks it into words. Displays the words and word count
        private static void BreakString(string str)
        {
            string[] Words = new string[50]; //array to hold the words of a string  
            int length = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (Words[i] != null)       //if the value at index position is not empty
                {
                    length++;               //increment the counter -> we will only loop through the indices with values in next for
                                            //as length with be the number of poitions with  a value
                }
            }

            Words = str.Split(' ');         //split on the space and store the wrd in the array
            
            for (int i = 0; i < length; i++)
            {
                if (Words[i] != null)
                {
                    Console.WriteLine(Words[i]);
                }
            }
            length = Words.Length;
            
            Console.WriteLine($"There were {length} words.");
        }


        //question12.
        //method counts and outputs number of vowels in a string
        private static void CountVowels(string str)
        {
            
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string vowelList = "";      //will be a 'list' of the vowels I find
            int vowelIndex = 0;         //will contain the index of a vowel when found
            int count = 0;              //count the instances of vowels

            if (str.IndexOfAny(vowels) != -1)                   //will stop entry to for loop if no vowels in string
            {
                for (int i = 0; i < str.Length; i += 0)         //dont increment i here, i will be reassigned in if-else
                {
                    if (i == str.Length - 1)                    //we break if at last position or i = vowelIndexex + 1 will push out of bounds
                    {
                        break;
                    }
                    else
                    {
                        vowelIndex = str.IndexOfAny(vowels, i); //looks for index of any vowels in the string,starting form pos. i
                        vowelList += str[vowelIndex];           //add the vowel we found to the list
                        i = vowelIndex + 1;                     //set the startIndex for next check
                        count++;                                //add to the count of found vowels 
                    }    
                }//END: for(len of the string)
            }//END: if(there are vowels)

            Console.WriteLine("The vowels were :");
            foreach (char vowel in vowelList)
            {
                Console.Write(vowel + " ");
            }
            Console.WriteLine($"\nThat was {count} vowels in total");
            
        }//END: CountVowels()

        //question15
        //method replaces a's with b's and t's with s in a string passed as arg
        private static string EncrpytString(string str)
        {
            string encrypted = str;

           for(int i = 0; i < str.Length; i++)
            {
                encrypted = encrypted.Replace('a', 'b');
                encrypted = encrypted.Replace('t', 's');

            }

            return encrypted;
        }//END : EncrpytString()

        //question16        
        //method validates a password 
        private static bool ValidatePassword(string pass)
        {
            bool isValid = false;
            char[] upperArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] lowerArray = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] numbers = "1234567890".ToCharArray();

            if (pass.Length >= 6 && pass.IndexOfAny(numbers) != -1)
            {
                if (pass.IndexOfAny(upperArray) != -1 && pass.IndexOfAny(lowerArray) != -1)
                {                   
                    isValid = true;                    
                }
            }
            
            return isValid;
        }//END: ValidatePassword()

        //question 18

        //method gets details of a cheque and stores in an array
        private static void GetChequeDetails(string[] chequeDetails, ref decimal pay)
        {
            const string INPUT_TAB = "{0, -15}{1, 5}";

            Console.Write(INPUT_TAB, "Enter date", ": ");
            chequeDetails[0] = Console.ReadLine();
            Console.Write(INPUT_TAB, "Enter name", ": ");
            chequeDetails[1] = Console.ReadLine();
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write(INPUT_TAB, "Enter amount", ": ");
                    chequeDetails[2] = Console.ReadLine();
                    if (decimal.TryParse(chequeDetails[2], out pay))  
                    {
                        isValid = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You must enter a number");
                }
            } while (!isValid);
            

        }//END: GetChequeDetials()
        
        //method displays cehque details
        private static void DisplayChequeDetials(string[] chequeDetails)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            const string DISPLAY_ONE = "{0, -10}{1, -25}";
            const string DISPLAY_TWO = "{0, -10}{1, -25}{2, 10}";

            decimal pay = Convert.ToDecimal(chequeDetails[2]);
            string[] denominations = { "hundred", "thousand" };
            string[] values = { "one", "two", "three ", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };
            string[] teens = {"teen", "twenty", "thirty", "forty", "fifty", "sixty", "seventy","eighty","nienty"};
            
            string stringPay = " hundred euros cent";                            //will concat to this string t build the pay in words
            int[] intPayValues = new int[chequeDetails[2].Length];      //will store the int value of the numbers in the string of pay

            Console.WriteLine("\nPay Cheque");
            Console.WriteLine(DISPLAY_ONE, "Date:", $"{chequeDetails[0]}");
            Console.WriteLine(DISPLAY_TWO, "Pay to:", $"{chequeDetails[1]}", $"{pay:c2}");

            for (int i = 0; i < chequeDetails[2].Length; i++)        //iterate over the string digits in the pay
            {
                if (int.TryParse(chequeDetails[2].Substring(i,1), out int value))   //pull the value from the string - parse as int
                {
                    intPayValues[i] = value;
                }
                else
                {
                    intPayValues[i] = -1;           //when we read from this array convert -1 to a '.'
                }
            }//END: for()


            //test print the int values
            foreach (var item in intPayValues)
            {
                Console.WriteLine(item);
            }

            //for (int i = 0; i < intPayValues.Length; i++)
            //{
            //    switch (chequeDetails[i])
            //    {
            //        case int num when intPayValues[i] == 1: stringPay += values[0]; break;
            //        case int num when intPayValues[i] == 2: stringPay += values[1]; break;
            //        case int num when intPayValues[i] == 3: stringPay += values[2]; break;
            //        case int num when intPayValues[i] == 4: stringPay += values[3]; break;
            //        case int num when intPayValues[i] == 5: stringPay += values[4]; break;
            //        case int num when intPayValues[i] == 6: stringPay += values[5]; break;
            //        case int num when intPayValues[i] == 7: stringPay += values[6]; break;
            //        case int num when intPayValues[i] == 8: stringPay += values[7]; break;
            //        case int num when intPayValues[i] == 9: stringPay += values[8]; break;
            //        case int num when intPayValues[i] == 0: stringPay += values[0]; break;
            //        default:
            //            break;
            //    }//END: witch()
            //}//END: for()

            Console.WriteLine(stringPay);

        }//END: DisplayChequeDetials()


    }//END: class

}//END: namespace