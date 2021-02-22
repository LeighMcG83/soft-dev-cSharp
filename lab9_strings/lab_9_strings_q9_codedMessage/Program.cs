/* ==============================================================================================
 * Worksheet: |  lab 9 Strings
 * Program:   |  lab_9_strings_q9_codedMessage.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  21/02/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Develop a program to send and receive a coded message
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  Encrpyt():
 *            |     - Replace() - only replaces all vowels if appear consequetively
 *            |  Decrypt():
 *            |     - Not finding the symbols
 * ==============================================================================================*/

using System;
using System.Threading;

namespace lab_9_strings_q9_codedMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup
            string msg = "";                                           //use 'input' to store input when we ask user for instructions

            Console.Write("Enter a message to be encrypted: ");
            msg = Console.ReadLine();


            string encryptedMsg = Encrypt(msg);                         //call method to encrypt message
            Console.Write("Encrypting");
            Loading();                                                  //mimics the encrption by writing a dot followed by a pause  
            Console.WriteLine($"Encrypted message: {encryptedMsg}\n");

            Console.Write("Sending");                                   //'send' message
            Loading();

            Console.Write("Recieving");                                 //'receive' and display encrypted msg
            Loading();
            Console.WriteLine($"Received encrypted message: \n\t{encryptedMsg}");

            //decrypt msg
            string decrypted =  Decrypt(encryptedMsg);
            //display decrypted
            Console.WriteLine($"Decrypted: {decrypted}");

        }//END:  Main()

        //method simulates the sending of a message using Sleep()
        static void Loading()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }//END: for()
            Console.WriteLine();
        }//END: Loading()

        //method takes a string arg and encrypts it
        /*encryption rules:
         *      change vowels to symbols
         *      shuffle constanents */
        static string Encrypt(string str)
        {
            char[] Vowels = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            char[] Symbols = { '!', '£', '$', '%', '&' };                           //we will Replace a,e,i,o,u with corresponding symbol
            int vowelIndex = 0;
            string encrypted = str;

            for (int i = 0; i < str.Length; i++)
            {
                vowelIndex = encrypted.IndexOfAny(Vowels);                                //finds the index of 1st occurance of a symbol in the array
                switch (str[vowelIndex])                                            //switch on the value (the vowel found)
                {
                    case 'a':
                    case 'A':
                        encrypted = encrypted.Replace(str[vowelIndex], Symbols[0]); //replace the char at current index with a symbol
                        break;
                    case 'e':
                    case 'E':
                        encrypted = encrypted.Replace(str[vowelIndex], Symbols[1]);
                        break;
                    case 'i':
                    case 'I':
                        encrypted = encrypted.Replace(str[vowelIndex], Symbols[2]);
                        break;
                    case 'o':
                    case 'O':
                        encrypted = encrypted.Replace(str[vowelIndex], Symbols[3]);
                        break;
                    case 'u':
                    case 'U':
                        encrypted = encrypted.Replace(str[vowelIndex], Symbols[4]);
                        break;
                    default:
                        Console.Write("Error occured while searching for vowels.");
                        break;
                }//END: switch(vowel)
            }//END: for() 

            return encrypted;

        }//END: Encrypt()


        //method decrypts and returns a string arg
        static string Decrypt(string str)
        {
            char[] Symbols = { '!', '£', '$', '%', '&' };
            int symbolIndex = 0;
            string decrypted = "";

            //iterate over the string to look for symbols
            for (int i = 0; i < str.Length; i++)
            {
                symbolIndex = str.IndexOfAny(Symbols, i);   //finds the index of 1st occurance of a symbol in the array
                
                switch (symbolIndex)
                {
                    case '!': str = str.Replace(str[symbolIndex], 'a'); break;
                    case '£': str = str.Replace(str[symbolIndex], 'e'); break;
                    case '$': str = str.Replace(str[symbolIndex], 'i'); break;
                    case '%': str = str.Replace(str[symbolIndex], 'o'); break;
                    case '&': str = str.Replace(str[symbolIndex], 'u'); break;
                    default : Console.Write("Error decryoting vowels"); break;
                }//END: Switch(symbolIndex)             
                
            }//END: for()
            return decrypted;
        }//END: Decrypt()

    }//END: class Program
}//END: namespace
