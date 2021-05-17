/* ===================================================================
 * Worksheet: |  worksheet3_switch
 * Program:   |  namespace week2_switch_q2_orderCost
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  28/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   | 
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      |
 * ===================================================================*/
using System;

namespace week2_switch_q2_orderCost
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputEnconding - System.Text.Encoding.UTF8;
            decimal total = 0m;
            string[] Products = 
            {
                "ASD","THF","TYG","GHT",
                "YUR","UIT","HIP","UIP",
                "RRT","JJk","IOP"
            };

            Console.WriteLine("Enter a Product   :");
            string product = Console.ReadLine();
            Console.WriteLine("Enter a Quantity  :");
            decimal quantity = decimal.Parse(Console.ReadLine());

            switch (product)
            {
                case "ASD":
                    total = quantity * 67.95m;
                    break;
                case "THF":
                    total = quantity * 68.90m;
                    break;
                case "TYG":
                    total = quantity * 34.95m;
                    break;
                case "GHT":
                    total = quantity * 88.90m;
                    break;
                case "YUR":
                    total = quantity * 23.80m;
                    break;
                case "UIT":
                    total = quantity * 9.9m;
                    break;
                case "HIT":
                case "UIP":
                case "RRT":
                case "JJk":
                case "IOP":
                    total = quantity * 10m;
                    break;
                default:
                    Console.WriteLine("Error. Invalid entry");
                    break;
            } //END: switch()

            if (total > 500)
            {
                total /= 1.1m;
            }

            total = total <= 500 ? total : total /= 1.1m;

            Console.WriteLine($"Total of this order is {total:c2}");

        } // END: Main()
    }
}