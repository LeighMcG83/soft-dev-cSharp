using System;

namespace y1s2_CA2_vk
{
    class Program
    {
        const string INPUT_TAB = "{0, -20}{1, 5}";
        const int validLength = 6;              //valid length of the product code
        const char start = 'W', third = 'X';    //valid chars for product code[;l

        static string[] jobCodes = { "W0X001", "W0X002", "W0X003", "W0X004", "W0X005", "W0X006" };
        static string[] jobNames = { "Change Breaks", "Change Exhaust", "Change Battery", "Full Service", "Align Wheels", "Valet" };
        static char[] vatTypes = { 'A', 'B', 'B', 'A', 'A' };
        static decimal[] unitPrices = { 2.5m, 2m, 1.5m, 2m, 3.5m, 1.5m };

        static string[] validCodes = new string[10];
        static int[] validHours = new int[10];
        static decimal[] validPriceExVAT = new decimal[10];
        static decimal[] validPriceIncVAT = new decimal[10];
        static decimal[] validvatPaid = new decimal[10];
        static decimal[] valivatPaid = new decimal[10];

        static void Main(string[] args)
        {
            bool isValid = false;
            int jobCount = 0, index = 0;
            const int MAX_JOBS = 3;
            decimal vatRate = 0m, vatPaid = 0m;
            string jobCode = String.Empty, hours = string.Empty, enterAnother = string.Empty;

            do
            {
                do
                {
                    Console.Write(INPUT_TAB, "Enter Job Code or 'Q' to Quit", ": ");
                    jobCode = Console.ReadLine();
                    isValid = IsValidJobCode(jobCode, "Job Code");
                } while (jobCode.ToUpper() != "Q" && !isValid);

                if (jobCode.ToUpper() != "Q" && jobCount < MAX_JOBS)
                {
                    index = FindIndex(jobCode, jobCodes);   //pass the string entered and the string[] to check in
                    if (index != -1)
                    {
                        validCodes[jobCount] = jobCode;

                        Console.Write(INPUT_TAB, "Enter hours on this job", ": ");
                        hours = Console.ReadLine();
                        isValid = IsPositiveInt(hours, "Hours");
                        jobCount++;

                        if (isValid)
                        {
                            validHours[jobCount] = Convert.ToInt32(hours);      //place hours in the hours[] at the current position

                            Console.WriteLine("\nHours:");
                            foreach (var item in validHours)
                            {
                                Console.Write(item + " ");
                            }

                            Console.WriteLine("\nNames:");
                            jobNames[jobCount] = jobNames[index];
                            foreach (var item in jobNames)
                            {
                                Console.Write(item + " ");
                            }

                            vatRate = FindVatRate(index);
                            CalculatePrice(ref vatRate, ref vatPaid, Convert.ToInt32(hours), index);
                            
                        }
                    }//END: if(index != -1)

                }//END: IF(not quit || >max)
                if (jobCount == 3)
                {
                    Console.WriteLine("Max number of jobs reached");
                    break;
                }
                else
                {
                    Console.Write(INPUT_TAB, "\nEnter another job (Y / N)", ": ");
                    enterAnother = Console.ReadLine();
                }
            } while (enterAnother.ToUpper() == "Y" && jobCount < 3);

            PrintReport(jobCount);

        }//END : Main()

        private static void PrintReport(int jobCount)
        {
            int index = 0;
            const string OUTPUT_TAB = "{0, -15}{1, 15}{2,15}{3,15}{4,15}{5,15}";

            Console.WriteLine(OUTPUT_TAB, "Job Code", "Description", "Hours", "Cost ExVAT", "VAT", "Cost InclVAT");
            for (int i = 0; i < jobCount; i++)
            {
                index = FindIndex(validCodes[i], jobCodes);

                Console.WriteLine(validCodes[i], jobNames[index], validHours[i], validPriceExVAT[i], validvatPaid[i], validPriceIncVAT[i]);
            }
        }

        private static void CalculatePrice(ref decimal vatRate, ref decimal vatPaid, int hours, int index)
        {
            decimal costHour = unitPrices[index];
            decimal price = costHour * hours;
            validvatPaid[index] = price * vatRate;

            Console.WriteLine("\nVatPaid:");
            foreach (var item in valivatPaid)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nPrices ex vat");
            validPriceExVAT[index] = price;
            foreach (var item in validPriceExVAT)
            {
                Console.Write(item + " ");
            }
        }


        /// <summary>
        /// Method checks a string[] for containment of a string
        /// </summary>
        /// <param name="jobCode"></param>
        /// <param name="jobCodes"></param>
        /// <returns>The index position of string if found, or else returns -1</returns>
        private static int FindIndex(string jobCode, string[] jobCodes)
        {
            if (jobCode != null)
            {
                for (int i = 0; i < jobCodes.Length; i++)
                {
                    if (jobCodes[i] == jobCode)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }//END FindIndex()


        /// <summary>
        /// Method assigns a vat rate based on a position passed to it
        /// </summary>
        /// <returns>The vat rate</returns>
        private static decimal FindVatRate(int index)
        {
            decimal rate = 0;

            if (vatTypes[index] == 'A')
            {
                rate = 0.2m;
            }
            else
            {
                rate = 0.1m;
            }

            return rate;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsValidJobCode(string input, string name)
        {            
            if (IsPresent(input, name) && ContainedInArray(input) && IsValidLen(input, validLength) && hasValidChars(input, start, third))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"{name} IS INVALID");
            }
            
            return false;
        }


        /// <summary>
        /// Method takes a string input and check for ctainment of 2 chars
        /// </summary>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="third"></param>
        /// <returns></returns>
        private static bool hasValidChars(string input, char start, char third)
        {
            if (input.StartsWith(start))   
            {
                if(input[2] == third)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"{input} must have a {third} for its third character.");
                }
            }           
            else
            {
                Console.WriteLine($"{input} must start with a {start}");
            }
            return false;
        }//END: hasValidChars()


        /// <summary>
        /// Method takes a string and checks if it is of a valid len, which is also passedas an arg.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="len"></param>
        /// <returns>True id length is correct, or else prints appropriate message to user and returns false</returns>
        private static bool IsValidLen(string input, int len)
        {
            if (input.Length == len)
                return true;
            else
            {
                Console.WriteLine($"{input} should be {len} chars long.");
                return false;
            }
        }//END: ISValidLen()


        /// <summary>
        /// Method check if the passed string argument id an empty string
        /// Takes 1 parameter no overloads
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>True if string is not empty, or false if it is</returns>
        private static bool IsPresent(string userInput, string name)
        {
            if (!String.IsNullOrEmpty(userInput))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"{name} cannot be blank");
            }
            return false;
        }//END: IsPresent();


        /// <summary>
        /// Method validates a user input by checking it is between a min and max value
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is between min and mas range allowed</returns>
        private static bool IsInRange(string choice, int minValue, int maxValue)
        {
            int intChoice = Convert.ToInt32(choice);
            bool isValid = false;

            if (intChoice >= minValue && intChoice <= maxValue)
            {
                isValid = true;
            }

            return isValid;
        }//END: IsInRange()


        /// <summary>
        /// Method validates a user input by checking it is greater than zero
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is greater than zero</returns>
        private static bool IsInRange(string input)
        {
            const int MIN = 0;
            int intChoice = Convert.ToInt32(input);
            bool isValid = false;

            if (intChoice > MIN)
            {
                isValid = true;
            }

            return isValid;
        }//END: IsInRange()


        /// <summary>
        /// Method checks if a string input can be converted to an integer,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsPositiveInt(string input, string name)
        {
            int num;
            if (int.TryParse(input, out num) == true && num > 0) 
                return true;
            else // there was a problem
                Console.WriteLine($"{name} must be an integer value.");
            return false;
        }//END:  IsInt()
       
        
        /// <summary>
        /// Method checks if a string input can be converted to a double,
        /// takes string input and string label for the input.
        /// Gives the user a tip if invalid inout is entered
        /// </summary>
        /// <param name="textIn"></param>
        /// <param name="name"></param>
        /// <returns>true, if input can be converted to an int, else returns false</returns>
        static bool IsDouble(string textIn, string name)
        {
            double num;
            if (double.TryParse(textIn, out num) == true) // all went ok
                return true;
            else // there was a problem
                Console.WriteLine(name + " must be a real (decimal) value.", "Entry Error");
            return false;
        }//END:  IsDoubet()


        /// <summary>
        /// Method checks the an array for containment of the input string
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="validJobCodes"></param>
        /// <returns>true if string is contained in the array, or else returns false</returns>
        private static bool ContainedInArray(string inputString)
        {
            foreach (string jobCode in jobCodes)
            {
                if (jobCode.Equals(inputString))
                    return true;
            }

            return false;
        }//END: ContainedInArray()



    }
}
