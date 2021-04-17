/* ==============================================================================================
 * Worksheet: |  File Handling
 * Program:   |  lab13_fileHandling.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  15/4/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/

using System;
using System.IO;

namespace lab13_fileHandling
{
    class Program
    {
        const string TABLE_FORMAT = "{0,-12}{1,12}";
        const string EXIT = "-999";

        static void Main(string[] args)
        {
            //Q1.
            string path = @".\lyrics.txt";
            Console.WriteLine("--------- Question 1 ---------\n");
            RunQuestion1(path);

            //Q2.
            Console.WriteLine("\n--------- Question 2 ---------\n");
            path = "./temperatures.txt";
            RunQuestion2(path);

            //Q3.
            Console.WriteLine("\n--------- Question 3 ---------\n");
            path = "./temperatures.txt";            //redeclare -> can change filename for q3 only to test try-catch
            RunQuestion3(path);

            //Q4.
            Console.WriteLine("\n--------- Question 4 ---------\n");
            path = "./paidup.txt";
            RunQuestion4(path);

            //Q5.
            Console.WriteLine("\n--------- Question 5 ---------\n");
            //path = "./notAFile.txt";              //use to test catch
            RunQuestion5(path);

            //Q6. 
            Console.WriteLine("\n--------- Question 6 ---------\n");
            Console.WriteLine("Added catch blocks to q5 to catch IOException and some derived exceptions");


        }//END: Main()

        private static void RunQuestion5(string path)
        {
            try
            {
                FileStream fs5 = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr5 = new StreamReader(fs5);
                string lineFromFile = sr5.ReadLine();
                string input = "";
                bool isPaid = false;

                do
                {
                    Console.Write("Enter a members name (or '-999' to exit): ");
                    input = Console.ReadLine();

                    isPaid = CheckMemberisPaid(path, sr5, input);

                    if (input != EXIT)
                        Console.WriteLine($"{input} Fully paid: {isPaid}");

                } while (input != EXIT);

                sr5.Close();
                fs5.Close();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message + "\n");
                Console.WriteLine("Could not finf specified dir");
            }
            catch(EndOfStreamException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine("\n\n" + ex.FileName + " not found when called in" + ex.TargetSite + " by " + ex.Source);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool CheckMemberisPaid(string fileIn, StreamReader sr5, string input)
        {
            bool isPaid = false;
            string[] lines = File.ReadAllLines(fileIn);
            string line = "";

            while (line != null)
            {
                for (int i =0; i <lines.Length;i++)
                {
                    if (lines[i] == input)
                    {
                        isPaid = true;
                    }                    
                }
                line = sr5.ReadLine();
            }
            return isPaid;
        }

        private static void RunQuestion4(string path)
        {
            try
            {
                FileStream fs4 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw4 = new StreamWriter(fs4);

                StorePaidUpMembers(EXIT, sw4);
                sw4.Close();
                fs4.Close();
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + "\n[ERROR]: File Not Found");
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message + "\n[ERROR]: Error loading file");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message + "\n[ERROR]: Tried to write to a closed file.");
            }
        }

        private static void StorePaidUpMembers(string EXIT, StreamWriter sw4)
        {
            string input;
            do
            {
                Console.Write("Enter paid-up member's name (or '-999' to exit): ");
                input = Console.ReadLine();
                if (input != EXIT)
                    sw4.WriteLine(input);

            } while (input != EXIT);
        }

        private static void RunQuestion3(string path)
        {
            try
            {
                FileStream fs3 = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr3 = new StreamReader(fs3);

                string[] Ranges = { "<0", "0-9", "10-19", "20-29", "30+" };
                int[] NoOfDays = new int[5];
                string line = sr3.ReadLine();
                string[] fields;
                double temperature = 0;

                while (line != null)
                {
                    fields = line.Split(',');
                    temperature = Convert.ToDouble(fields[1]);
                    CountTempRangeOccurances(NoOfDays, temperature);
                    line = sr3.ReadLine(); //assigns the next line as input - if is null, next while-check will break loop
                }

                PrintTemperatureOccuancesTable(Ranges, NoOfDays);
                fs3.Close();
                sr3.Close();
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message + "\n\n.....File Not Found");
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.Message + "\n\n....File could not be Loaded from memory");
            }

            finally
            {
                Console.WriteLine("Finally....Ending Program");
            }

        }

        private static void RunQuestion2(string path)
        {
            FileStream fs2 = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr2 = new StreamReader(fs2);

            string input = sr2.ReadLine();
            int lineCount = 0;
            double total = 0;

            Console.WriteLine("Temperature Report");
            Console.WriteLine(TABLE_FORMAT, "Date", "Temperature");
            while (input != null)
            {
                string[] fields = input.Split(',');
                string date = fields[0];
                if (double.TryParse(fields[1], out double temperature))
                {
                    temperature = Double.Parse(fields[1]);
                    total += temperature;
                    lineCount++;
                }
                Console.WriteLine(TABLE_FORMAT, $"{date}", $"{temperature}");
                input = sr2.ReadLine();
            }

            Console.WriteLine(TABLE_FORMAT, "Average", $"{total / lineCount}");

            fs2.Close();
            sr2.Close();
        }

        private static void RunQuestion1(string path)
        {
            //Q1 (i)
            CreateFile(path);

            //Q1 (ii)
            string firstLine = ReadFirstLine(path);
            Console.WriteLine("First line in file:");
            Console.WriteLine(firstLine);

            //Q1 (iii)
            Console.WriteLine();
            string thirdline = ReadThirdLine(path);
            Console.WriteLine(thirdline);

            //Q1 (iv)
            Console.WriteLine();
            ReadAllLines(path);
        }

        private static void CountTempRangeOccurances(int[] NoOfDays, double temperature)
        {
            switch (temperature)
            {
                case double t when temperature < 0:
                    NoOfDays[0]++;
                    break;
                case double t when temperature < 10:
                    NoOfDays[1]++;
                    break;
                case double t when temperature < 20:
                    NoOfDays[2]++;
                    break;
                case double t when temperature < 30:
                    NoOfDays[3]++;
                    break;
                case double t when temperature >= 30:
                    NoOfDays[4]++;
                    break;
                default:
                    Console.WriteLine("Error, Invalid temperature");
                    break;
            }
        }

        private static void PrintTemperatureOccuancesTable(string[] Ranges, int[] NoOfDays)
        {
            Console.WriteLine(TABLE_FORMAT, "Range", "No. of Days");
            for (int i = 0; i < Ranges.Length; i++)
            {
                Console.WriteLine(TABLE_FORMAT, $"{Ranges[i]}", $"{NoOfDays[i]}");
            }
        }

        /// <summary>
        /// Method opens and reads all lines of a text file at a filepath passed as param
        /// </summary>
        /// <param name="path"></param>
        private static void ReadAllLines(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string lineIn; 

            lineIn = sr.ReadLine(); // read in first line from file

            while (lineIn != null) // null signals we are end of the file
            {
                Console.WriteLine(lineIn); // print to screen
                lineIn = sr.ReadLine(); // read in next line from file
                
            }

            sr.Close();
            fs.Close();
        }

        /// <summary>
        /// Method opens and reads third line of a text file at a filepath passed as param
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReadThirdLine(string path)
        {            
            int count = 0;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader inputStream = new StreamReader(fs);
            string line = inputStream.ReadLine();

            while (line != null)
            {
                
                if (count == 2)
                {
                    return line;
                }
                line = inputStream.ReadLine();
                count++;
            }
            fs.Close();
            inputStream.Close();

            return "Error reading file";
        }

        /// <summary>
        /// Method opens and reads first line of a text file at a filepath passed as param
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReadFirstLine(string path)
        {
            string line = "";
            for (int i = 0; i < 1; i++)
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                line = sr.ReadLine();
                fs.Close();
                sr.Close();
            }
            
            return line;
        }

        /// <summary>
        /// Method creates a text file and writes a predefined first verse of a song to the file.
        /// </summary>
        /// <param name="path"></param>
        private static void CreateFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Sinne Fianna Fáil\n" +
                "atá faoi gheall ag Éirinn\n" +
                "Buíon dár slua\n" +
                "thar toinn do ráinig chughainn");

            sw.Close();
            fs.Close();
        }
    }
}
