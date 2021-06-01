using System;

namespace Shop_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string QUIT = "-999";
            double[] sales = new double[100];
            int[] SalesInRanges = new int[5];      //keeps count of the instances of each sales range
            int count = 0;                         //track position in sales[] to add the inputted sale to
            double saleAmount = 0;
            string input;
            string[] Ranges = { "000-99.99", "100-199.99", "200-399.99", "400-599.99", "600+" };

            do
            {
                input = GetInput();
                bool isValid = CheckInputIsValid(QUIT, input, sales, ref count, ref saleAmount);
                if (isValid)
                    CatagorizeSale(sales, SalesInRanges, ref count, saleAmount);
            } while (input != QUIT);

            PrintSalesReport(SalesInRanges, Ranges);

        }//END: Main()

        private static void CatagorizeSale(double[] sales, int[] SalesInRanges, ref int count, double saleAmount)
        {
            switch (saleAmount)
            {
                case double s when saleAmount > 0 && saleAmount < 100:
                    sales[count] = saleAmount;
                    SalesInRanges[0]++;
                    break;
                case double s when saleAmount < 200:
                    sales[count] = saleAmount;
                    SalesInRanges[1]++;
                    break;
                case double s when saleAmount < 400:
                    sales[count] = saleAmount;
                    SalesInRanges[2]++;
                    break;
                case double s when saleAmount < 600:
                    sales[count] = saleAmount;
                    SalesInRanges[3]++;
                    break;
                case double s when saleAmount >= 600:
                    sales[count] = saleAmount;
                    SalesInRanges[4]++;
                    break;
                default:
                    Console.WriteLine("Sale not recorded - negative value");
                    break;
            }
            count++;    //increment the position to add add the next sale to in sales[]
        }

        private static void PrintSalesReport(int[] SalesInRanges, string[] Ranges)
        {
            Console.WriteLine("\nSale Amount Report");
            Console.WriteLine("---------------------\n");
            Console.WriteLine($"{"Range",-12}{"Number in Range",-16}");
            Console.WriteLine($"{"------",-12}{"---------------",-16}");
            for (int i = 0; i < Ranges.Length; i++)
            {
                Console.WriteLine($"{Ranges[i],-12}{SalesInRanges[i],-16}");
            }
        }

        private static string GetInput()
        {
            string input;
            Console.Write("Enter sale amount (or -999 to exit): ");
            input = Console.ReadLine();
            return input;
        }

        private static bool CheckInputIsValid(string QUIT, string input, double[] sales, ref int count, ref double saleAmount)
        {
            if (input != QUIT && !(String.IsNullOrEmpty(input)) && double.TryParse(input, out double sale))
            {
                if (sale > 0)
                {
                    saleAmount = Convert.ToDouble(input);
                    return true;
                }
            }
            return false;
        }

    }
}
