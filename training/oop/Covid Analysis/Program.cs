/* Author:      Leigh McGuinness
 * Created:     23/05/21
 * -------------------------------------------------------------------
 * Purpose:     Write a program that will read COVID data from a csv
 *              file and use this data to instantiate Statistic objects
 *              Program will enable a user to:
 *                  - view all statistics on record
 *                  - view stats by country
 *                  - view stats by continent
 *                  - view a calculated overall 14 day moving average
 *                  - view stats for a given date
 *                  - view stats by highest death-toll per day and month
 *                  - view the calculate average death toll per day and month
 *                  - view stats for countries with popultion over a given value
 *------------------------------------------------------------------------------
 * Bugs:        Display the DateTime of a stat with 'date only' (no time)
 *              
 *              Not displaying all stats in the file
 */              


using System;
using System.IO;
using System.Collections.Generic;

namespace Covid_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH = @"./covidData1.csv";
            FileStream fs = null;
            StreamReader sr = null;
            List<Statistic> StatsList = new List<Statistic>();

            try
            {
                fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                sr.ReadLine();          // will discard the row containing headers
                string lineIn = sr.ReadLine();
                while(lineIn != null)
                {
                    string[] fields = lineIn.Split(',');

                    Statistic stat = new Statistic(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[1]), Convert.ToInt32(fields[2]),
                        Convert.ToInt32(fields[3]), Convert.ToInt32(fields[4]), fields[5], fields[6], Convert.ToInt32(fields[7]),
                        fields[8], Convert.ToDouble(fields[9]));

                    StatsList.Add(stat);
                    lineIn = sr.ReadLine();
                }
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"[ERROR] reading from file - File: {PATH} not found.\n{ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ooops....something went wrong while opening {PATH}\n{ex.Message}\n");
            }

            finally
            {
                sr?.Close();
                fs?.Close();
                
            }

            Console.WriteLine($"{"Date", -8}{"Country", -15}{"Cases", -10}{"Deaths", -10}{"14 Day Moving Avg.", -20}{"Population", -12}");
            foreach (var stat in StatsList)
            {
                Console.WriteLine(stat.ToString());
            }

            Console.WriteLine("Press ENTER to exit program");
            Console.ReadLine();
        
        }//END Main()
    
    
    
    }// END: Program class

}//END: Covid Analysis namespace
