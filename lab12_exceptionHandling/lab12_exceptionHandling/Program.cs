using System;

namespace lab12_exceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            double quotient;
            bool isValid;
            do // i ve put a loop in here so that user can correct their mistake
            {
                try
                {
                    isValid = true;
                    Console.WriteLine("Enter the first number : ");
                    num1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second number : ");
                    num2 = int.Parse(Console.ReadLine());
                    quotient = Divide(num1, num2);
                    Console.WriteLine("The quotient is {0}", quotient);
                }
                catch (ArithmeticException myError)
                {
                    Console.WriteLine(myError.Message); // could put a more app specific message if we wished
                    isValid = false;
                }
                catch (FormatException myError)
                {
                    Console.WriteLine(myError.Message);
                    isValid = false;
                }
                catch (Exception myError) // unspecified exception
                {
                    Console.WriteLine(myError.Message);
                    isValid = false;
                }
                finally // executed in all cases
                {
                    Console.WriteLine("In Finally block");
                }
            }
            while (isValid == false); // if there is a problem, try block is re-executed
        }
        public static double Divide(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArithmeticException("Cannot divide by zero"); // programmer throwing an exception
            else
                return (double)numerator / denominator;

        }
    }
}
