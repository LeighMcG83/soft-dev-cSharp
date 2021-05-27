using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            const string QUIT = "-999";
            bool isValid = false;
            string input = "";
            double[] sales = new double[100];
            int count = 0;
            double saleAmount = 0, saleInput = 0;

            do
            {
                input = GetInput();

                isValid = CheckInputIsValid(QUIT, ref isValid, input, sales, ref count, ref saleInput);
                if (isValid)
                {
                    sales[count] = saleAmount;  //place saleAmount in [0] of < 100, [1] if 100 <= sale <= 200 etv.
                    count++;
                }
            } while (input != QUIT && !isValid);


            //print sales report



        }//END: MAin()

        private static string GetInput()
        {
            string input;
            Console.Write("Enter sale amount (or -999 to exit): ");
            input = Console.ReadLine();
            return input;
        }

        private static bool CheckInputIsValid(string QUIT, ref bool isValid, string input, double[] sales, ref int count, ref double saleAmount)
        {
            if (input != QUIT && String.IsNullOrEmpty(input) && double.TryParse(input, out double sale))
            {                
                return true;
            }
            return false;
        }

    }
}
