using System;

namespace woeksheet3_switch_q2_OrderCost
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEnconding - System.Text.Encoding.UTF8;

            string[] Products = new
            {
                "ASD", "THF",
                "TYG", "GHT",
                "YUR", "UIT",
                "HIP", "UIP",
                "RRT", "JJk",
                "IOP"
            }

            decimal total = 0;

            Console.WriteLine("Enter a Product   :");
            string product = Console.ReadLine();

            foreach (string p in Products)
            {
                Console.WriteLine(Products[p] + " ");

            }

            Console.WriteLine("Enter a Quantity  :");
            int quantity = int.Parse(Console.ReadLine());

            switch (product)
            {
                case "ASD":
                    total = quantity * 67.95;
                    break;
                case "THF":
                    total = quantity * 68.90;
                    break;
                case "TYG":
                    total = quantity * 34.95;
                    break;
                case "GHT":
                    total = quantity * 88.90;
                    break;
                case "YUR":
                    total = quantity * 23.80;
                    break;
                case "UIT":
                    total = quantity * 9.9;
                    break;
                case "HIT":
                case "UIP":
                case "RRT":
                case "JJk":
                case "IOP":
                    total = quantity * 10;
                    break;
                default:
                    Console.WriteLine("Error. Invalid entry");
                    break;
            } //END: switch()

            if (total > 500)
            {
                total /= 1.1;
            }

            Console.WriteLine($"Total of this order is {total:c2}");

        } // END: Main()
    }
}
