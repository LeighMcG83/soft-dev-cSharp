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
            int[] salesRanges = new int[5];      //keeps count of the instances of each sales range
            int count = 0;
            double saleAmount = 0, saleInput = 0;

            do
            {
                input = GetInput();

                isValid = CheckInputIsValid(QUIT, ref isValid, input, sales, ref count, ref saleInput);
                if (isValid)
                {
                    switch (saleAmount)         //check logic
                    {
                        case double s when saleAmount > 0 && saleAmount < 100:
                            sales[count] = s;
                            salesRanges[0]++;
                            break;
                        case double s when saleAmount < 200:
                            sales[count] = s;
                            salesRanges[1]++;
                            break;
                        case double s when saleAmount < 400:
                            sales[count] = s;
                            salesRanges[2]++;
                            break;
                        case double s when saleAmount < 600:
                            sales[count] = s;
                            salesRanges[3]++;
                            break;
                        case double s when saleAmount >= 600:
                            sales[count] = s;
                            salesRanges[4]++;
                            break;
                        default:
                            Console.WriteLine("Sale not recorded - negative value");
                            break;
                    }
                    count++;
                    
                }
            } while (input != QUIT && !isValid);


            //print sales report
            foreach (double sale in sales)
            {
                Console.Write(sale + ", ");
            }

            foreach (int range in salesRanges)
            {
                Console.Write(range + ", ");
            }



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
