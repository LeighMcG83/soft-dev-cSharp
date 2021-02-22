/* ===================================================================
 * Worksheet: |  Lab6_method_arrays_many
 * Program:   |  Lab6_method_arrays
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  07/02/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  i.	A website only allows users in the age bracket 18 to 21
 *            |     inclusive to access its content. Write a method that:
 *            |         - accepts the age as an int argument
 *            |         - decides whether it is possible to access the site. 
 *            |     Method shall return a boolean value.
 *            | 
 *            |  ii. Write a method that uses a switch statement to return the
 *            |      cost of a product, where the method receives a product code 
 *            |      as a string argument.
 *            |
 *            |  iii.Write a method named AlltheNines that accepts an int array
 *            |      as an argument and stores the value 9 in each element.
 *            |
 *            |  iv. Write a method named PassCounter that accepts an int array
 *            |      as an argument and returns a count of the number of elements
 *            |      with a value greater than 40.
 *            |  
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

namespace Lab6_method_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            OutputEncoding = System.Text.Encoding.UTF8;
            // setup
            int length;             // var to store lengths of arrays in
            const string INPUT_TAB = "{0, -25}{1,5}";

            /***** Part i ******/
            //setup- get input and assign to var
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CheckAge(age));               // print returned val of CheckAge()

            /***** Part ii ******/
            //setup - get product code
            Console.WriteLine("Enter the product code: ");
            string code = Console.ReadLine();
            Console.WriteLine(GetCost(code));

            /***** Part iii ******/
            int arrayLen = GetArrayLength();        
            int[] intArray = new int[arrayLen];     // create an empty array of user defined length 
            AllTheNines(intArray);                  // call the method and pass the array
            DisplayArrayElems(intArray);            // call method and write the elems to console

            /***** Part iv ******/
            length = GetArrayLength();                      // get length of the array from user
            int[] largeNumArray = new int[length];          // create arra of user specified length
            PopulateArray(largeNumArray);                   // call method to get user to fill the array
            Console.Write("Elements greater than 40 : ");
            Console.WriteLine(PassCounter(largeNumArray));  // call method that returns the number of values over 40 in the array     

            /***** Part v ******/
            /* Write a method named GetBMI that accepts a persons weight in kg
             * and their height in meters as double parameters and return their 
             * body mass index
             */
            Console.WriteLine("Enter your weight in kgs  : ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your height in mtrs : ");
            double height = Convert.ToDouble(Console.ReadLine());
            double bmi = GetBMI(weight, height);                    // store the returned bmi in var
            Console.WriteLine($"BMI : {bmi}");

            /***** Part vi ******/
            /* vi.	Write a method, static int Sum(int n1, int n2)
             *      That returns the sum of all odd numbers between the two integer 
             *      arguments (inclusive) passed to it
             */
            Console.Write("Enter first number : ");     // get the numbers to start and finish numbers
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write($"The sum if the odd numbers between {num1} and {num2} is :  ");
            Console.WriteLine(Sum(num1, num2));

            /***** Part vii ******/
            /* Write a method that accepts a bank balance figure and a deposit amount figure as int arguments.
             * It will update the balance by adding the deposit amount..
             */
            Console.Write("What is your balance : ");
            int balance = Convert.ToInt32(Console.ReadLine());
            Console.Write("How much would you like to deposit : ");
            int deposit = Convert.ToInt32(Console.ReadLine());

            DepositFunds(ref balance, deposit);
            Console.WriteLine($"Funds deposited...Your new balance is {balance:c2}");

            ///***** Part viii ******/
            /*	A tool rental shop charges €10.00 per day to rent a lawnmower for each of the first five days.
             *	The company charges €8.00 per day for each additional day.  
             *	The minimum charge for any given rental period is €15.00.  
             *	Write a method that accepts the numbers of days rental as a parameter and returns the rental charge.
             * */
            Console.WriteLine("Enter rental period in days  :");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Cost for rental period  : {RentalCost(days)}");

            /******** Part ix ***********/
            /*ix.	Write the method with the following signature:
             *          static bool Sorted(int[] x), 
             *      which returns true if all the values in the array are sorted,
             *      with the smallest coming first otherwise returning false.
             */
            length = GetArrayLength();              // get a length for the array from user
            int[] intArray2 = CreateArray(length);   // create the array - use method for practice purposes
            PopulateArray(intArray2);                // get user to fill the array
            Console.WriteLine($"Array in ascending Order  : {Sorted(intArray2)}");   // state if array was in a sorted order

            /******** Part x ***********/
            /* Write a method that returns the discount rate for a holiday based on the number
             * of children going on the holiday. Your method will have one parameter, the number of children.
             * Return the discount rate based on number of kids.
             */
            Console.Write("Enter number of children going on holiday  : ");
            int kids = Convert.ToInt32(Console.ReadLine());
            double discount = CalcDiscRate(kids);
            Console.WriteLine($"Your discount is : {discount:p0}");

            /******** Part xi ***********/
            /* 	Write a method that takes as input the balance in a bank savings account, 
             * 	an annual interest rate, and a number of years that the money will be on 
             * 	deposit. The method will calculate the total compound interest earned over
             * 	the number of years and update the balance. For example, €200 saved for 3 
             * 	years at 5% will result in an updated balance of €231.53.
             */
            Console.Write(INPUT_TAB, "Enter balance", ":  ");
            double balanceXi = Convert.ToDouble(Console.ReadLine());
            Console.Write(INPUT_TAB, "Enter interest rate", ":  ");
            double interestRate = Convert.ToDouble(Console.ReadLine());
            Console.Write(INPUT_TAB, "Enter repayment period", ":  ");
            int years = Convert.ToInt32(Console.ReadLine());
            CalculateUpdatedBalance(ref balanceXi, interestRate, years);      // call method , passing balance by ref to change value in orginal variable
            Console.WriteLine($"Your balance after {years} years @ {interestRate:p2} is {balanceXi:c2}");

            /************* Part xii ***************/
            /* Write a method:
             *      static string Encrypt(string str)
             * That returns the string str with each adjacent pair of characters swapped.  For example:
             *      Encrypt(“my secrets”) returns “yms ceerst”
             *  (Hint: an string can be thought of as an array of characters
             *  (Hint: use a for loop to step through the characters in the string)
             */
            Console.WriteLine(INPUT_TAB, "Enter a word to be encrypted", ": ");
            string inputString = Console.ReadLine();
            string encryptedStr = Encrypt(inputString);
            Console.WriteLine($"Encrypted string: {encryptedStr}");

        }//END: Main()

        // i. method receives int age as arg and checks if age between 18 && 21 and returns boolean
        static bool CheckAge(int age)
        {
            if (age >=18 && age <= 21)
                { return true; }
            else
                { return false; }
        }//END: CheckAge()

        // ii. method recieves a string and returns the associated cost of the product
        static decimal GetCost(string productCode)
        {
            decimal cost;
            switch (productCode)
            {
                case "ABC": cost = 10.10m; break;
                case "XYZ": cost = 69.34m; break;
                case "FR45": cost = 34.0m; break;
                case "S34":
                case "G65":
                case "F34": cost = 5.0m; break;
                default: cost = -999;
                    break;
            }
            return cost;
        }//END: GetCoat()

        // iii. method takes an array as arg and fills it wth 9's
        static void AllTheNines(int[] intArray)
        {
            int length = intArray.Length;
            for (int i = 0; i < length; i++)
            {
                intArray[i] = 9;
            }
        } //END: AllTheNines()

        // iv. method that counts the elems of value  and returns the count
        static int PassCounter(int[] intArray)
        {
            int length = intArray.Length;
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                if(intArray[i] > 40) { count++; }
            }
            return count;
        }// END: PassCounter()

        // v. method that calucaltes BMI
        static int GetBMI(double weight, double height)
        {
            return Convert.ToInt32(weight / (Math.Pow(height, 2)));             
        }

        // vi. method subtotals the odd numbers between 2 user defined ints
        static int Sum(int n1, int n2)
        {
            int total = 0;
            for (int i = n1; i <= n2; i++)  // start at n1 , end at n2
            {
                if (i % 2 != 0)             // if the number divided by 2 is ot zero we will add it to total
                {
                    total += i;
                } //END: if(odd)
            } // END: for(n1 < i < n2)
            return total;
        } //END: Sum()

        // vii. method deposits funds in an account.
        static void DepositFunds(ref int balance, int deposit)
        {
            balance += deposit;
        } //END: DepositFunds()

        // viii. method calculates rental charge - param for no. of days 
        static decimal RentalCost(int days)
        {
            const decimal RENTAL_RATE = 8m;
            const decimal MAX_RENTAL = 10m;

            decimal thisRental = days * RENTAL_RATE;
            if (thisRental > MAX_RENTAL) { thisRental = MAX_RENTAL; }

            return thisRental;
        }//END: RentalCost()

        // ix. method checks if an array is sorted in ascending order and returns true / false
        static bool Sorted(int[] x)
        {
            bool isSorted = true;
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] > x[i + 1])
                {
                    isSorted = false;
                }// END: if(x[i] > x[i + 1]
            }//END: for(len of x)
            return isSorted;
        }//END: Sorted()

        // x. method calculates the rate of disc. based on no. of children on holiday
        static double CalcDiscRate(int kids)
        {
            double discRate = 0;

            switch (kids)
            {
                case 0: discRate = 0; break;
                case 1:
                case 2: discRate = 0.05; break;
                case 3:
                case 4:
                case 5: discRate = 0.1; break;
                case  int children when kids > 5: discRate = 0.15; break;
                default:
                    Console.WriteLine("Invalid Entry. Enter a number 0 or greater");
                    break;
            }//END: switch(kids)

            return discRate;
        }// CalcDiscRate()

        // xi. method calculates new balnce using original balance, time period and percentage rate params
        static void CalculateUpdatedBalance(ref double balance, double intRate, int yrs) // bal passed by ref => no return.
        {
            for (int i = 0; i < yrs; i++)
            {
                balance += balance * (intRate / 100);       // convert interest rate to decimal, 5 -> 0.05
            }//END: for(yrs)

        }//END: CalculateUpdatedBalance()

        // xii. method will encrypt a string by swapping adjacent letters.
        static string Encrypt(string str)
        {
            int j = 1;                                   // j will be the next letter in the string
            char tempValue = ' ';                       // temporarily store a value until it is swapped
            string encryptedStr = "";      


            for (int i = 0; j < str.Length - 1; i++)
            {
                encryptedStr += str[j];         // assign i to next value
                encryptedStr += str[i];         // assign the previous i to j
               
                j++;
            } //END: for(lenght of str)
            if (str.Length % 2 != 0)
            {
                encryptedStr += str[str.Length - 1];
            }
            
            return encryptedStr;
        }



        // method return the length for an array
        static int GetArrayLength()
        {
        Console.Write("How many values would you like in the array?  : ");
        int arrLen = Convert.ToInt32(Console.ReadLine());
        return arrLen;
        }//END: GetArrayLength()

        // method creates an integer array of user defined length
        static int[] CreateArray(int len)
        {
            int[] intArray = new int[len];
            return intArray;
        }

        // method fills an array with user defined values
        static void PopulateArray(int[] intArray)
        {
        int length = intArray.Length;
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Enter a number to store: ");
            intArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        } //END: PopulateArray()

        // method that prints all the elements of an array on same line
        static void DisplayArrayElems(int[] intArray)
        {
            int length = intArray.Length;
            foreach (int elem in intArray)
            {
                Console.Write(elem + " ");
            }
        }//END: DisplayArrayElems()

    }//END: class 
}
