using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //float a = 0.4f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("0.4 after Convert.ToInt  :" + a);

            //a = 0.5f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("0.5 after Convert.ToInt :" + a);

            //a = 0.6f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("0.6 after Convert.ToInt :" + a);

            //a = 1.4f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("1.4 after Convert.ToInt :" + a);

            //a = 1.5f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("1.5 after Convert.ToInt :" + a);

            //a = 1.6f;
            //a = Convert.ToInt32(a);
            //Console.WriteLine("1.6 after Convert.ToInt :" + a);

            //int[] numbers = { 1, 2, 3, 4, 5 };
            int[] numbers = { };

            Console.WriteLine(GetMax(numbers));


        }
        static int GetMax(int[] numbers)
        {
            int max = 0;

            if (!(numbers == null || numbers.Length == 0))
            {
                for (int i = 0; i < numbers.Length; i++)
                {

                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }

                    else
                    {
                        return max;
                    }
                }
            }

            return -999;
        }

        static public string GetPrice(string item)
        {
            string price = "";
            switch (item)
            {
                case "bananas": price = "1.50"; break;
                case "spuds": price = "2.50"; break;
                case "pizza": price = "3.50"; break;
                case "tomatoes": price = "3.00"; break;
                case "apples": price = "3.00"; break;
                case "oranges": price = "3.00"; break;
                default: price = "-1"; break;
        } 
        
            return price;
        }

    }
}
