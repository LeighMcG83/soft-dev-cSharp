using System;
using System.IO;
using System.Collections.Generic;

namespace ships
{
    class Program
    {
        private const string PATH = @"./FrenchMF.TXT";

        static void Main(string[] args)
        {
            List<Ship> vessels = new List<Ship>();
            ReadVesselsFromFile(PATH, ref vessels);

            string input;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Vessel Report");
                Console.WriteLine("2. Location Analysis Report");
                Console.WriteLine("3. Search for a vessel");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter Choice : ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine($"{"\nLocation", -20}{"Function", -20}{"Name", -15}{"Tonnage", -10}{"Crew", -10}{"Cost", -10}{"\n"}");
                        PrintVesselReport(vessels);
                        break;
                    case "2":
                        PrintLocationAnalysisReport(vessels);

                        break;
                    case "3":
                        //SearchVessels();

                        break;
                    case "4":
                        System.Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Error: Invalid Menu option chosen");
                        break;
                }

            } while (input != "4");


        }//END: Main()

        private static void PrintLocationAnalysisReport(List<Ship> vessels)
        {
            int[] regions = new int[6]; //count the occurances of each region
            int index = 0;
           

            for (int i = 0; i < vessels.Count; i++)
            {
                index = FindLocationIndex(vessels[i]);


            }
        }

        private static int FindLocationIndex(Ship s)
        {
            string[] locations = {
                "The Pacific",
                "The Atlantic",
                "The Mediterranean",
                "The Indian Ocean",
                "The Other Seas"
            };

            for (int i = 0; i < locations.Length; i++)
            {
                if (i == s.Location)
                    return i;                
            }
            return -1;
        }

        private static void PrintVesselReport(List<Ship> vessels)
        {
            for (int i = 0; i < vessels.Count; i++)
            {
                if (vessels[i].Tonnage >= 3500)                 //print only vessels >= 3500 tons
                    Console.WriteLine(vessels[i].ToString());
            }
            Console.WriteLine();
        }

        private static void ReadVesselsFromFile(string PATH, ref List<Ship> vessels)
        {
            FileStream fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string lineIn = sr.ReadLine();
           
            while ((lineIn = sr.ReadLine()) != null)
            {
                string[] fields = lineIn.Split(',');
                if (fields.Length == 5)
                {
                    Ship newShip = new Ship(fields[0], Convert.ToInt32(fields[1]), Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]), Convert.ToInt32(fields[4]));
                    vessels.Add(newShip);
                }
                lineIn = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }


    }//END: class Program
}
