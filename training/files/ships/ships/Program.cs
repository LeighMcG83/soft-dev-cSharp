using System;
using System.IO;
using System.Collections.Generic;

namespace ships
{
    class Program
    {
        private const string PATH = @"./FrenchMF.TXT";
        private static readonly string[] locations = {
                "The Pacific",
                "The Atlantic",
                "The Mediterranean",
                "The Indian Ocean",
                "The Other Seas"
            };

        static void Main(string[] args)
        {
            List<Ship> vessels = new List<Ship>();
            ReadVesselsFromFile(PATH, ref vessels);

            string input;
            do
            {
                Console.WriteLine("\nMenu\n");
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
                        Console.WriteLine($"{"\n"}{"Location", -20}{"Vessel Count"}");
                        PrintLocationAnalysisReport(vessels);
                        break;
                    case "3":
                        SearchVessels(vessels, locations);
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


        
        private static void SearchVessels(List<Ship> ships, string[] locations)
        {
            Console.WriteLine($"{"Ship ID", -10}{"Name", -15}");
            foreach (Ship s in ships)
            {
                Console.WriteLine($"{s.ID, -10}{s.Name, -15}");
            }

            Console.Write("\nEnter a vessel ID to search for: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool isFound = false;
                for (int i = 0; i < ships.Count; i++)
                {
                    if (ships[i].ID == id)
                    {
                        Console.WriteLine($"Location: {locations[i]}");
                        isFound = true;
                    }
                }
                if (!isFound)                
                    Console.WriteLine($"\nShip number {id} not found.");                
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("\n" + ex.Message + "\nSearch went out of bounds while searching for the vessel name");
            }
            catch (Exception)
            {
                Console.WriteLine("\nUspecified error occured when searching for the vessel name.");
            }
            
        }


        /// <summary>
        /// Method prints the location report of all vessels to the console.
        /// </summary>
        /// <param name="vessels"></param>
        private static void PrintLocationAnalysisReport(List<Ship> vessels)
        {
            int index = 0;
            int[] locationCounts = new int[5];  //keep a count of the occurances of each region

            try
            {
                for (int i = 0; i < vessels.Count; i++)
                {
                    index = FindLocationIndex(vessels[i]);
                    //accumulate the count in each region - refactor: can pass index using the method call instead assigning to 'index'?
                    locationCounts[index]++;            
                }
                for (int i = 0; i < vessels.Count; i++)
                {
                    Console.WriteLine($"{locations[i],-20}{locationCounts[i],-14}");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "Search error - out of bounds while finding the index or printing the Analysis Report.");
            }
            catch (Exception)
            {
                Console.WriteLine("Uspecified error occured when searching for the vessel index.");
            }

        }

        /// <summary>
        /// Method searches a ships location in an array of locations.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>>The index position of the locatin in the array if found, else returns -1</returns>
        private static int FindLocationIndex(Ship s)
        {
            try
            {
                for (int i = 0; i < locations.Length; i++)
                {
                    if (i + 1 == s.Location)
                        return i;
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + "Search out of bounds while searching the vessels location.");
            }
            catch (Exception)
            {
                Console.WriteLine("Unspecified Error ehile searching the vessels location.");
            }
          
            return -1;
        }

        /// <summary>
        /// Method prints all the objects in List of vessels, passed as param, to the console. 
        /// </summary>
        /// <param name="vessels"></param>
        private static void PrintVesselReport(List<Ship> vessels)
        {
            for (int i = 0; i < vessels.Count; i++)
            {
                if (vessels[i].Tonnage >= 3500)                 //print only vessels >= 3500 tons
                    Console.WriteLine(vessels[i].ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Method reads all vessels in a file passed as an arg, and creates a Ship obj from each line on the file.
        /// </summary>
        /// <param name="PATH"></param>
        /// <param name="vessels"></param>
        private static void ReadVesselsFromFile(string PATH, ref List<Ship> vessels)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
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
            }//End: try block
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + "\nError reading data from file");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + "\nError reading data from file");
            }
            catch (Exception)
            {
                Console.WriteLine("Uspecified error occured when reading from file.");
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }            
        }


    }//END: class Program
}
