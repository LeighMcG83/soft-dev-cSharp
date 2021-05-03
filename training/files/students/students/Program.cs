/* ==============================================================================================
 * Worksheet: |  Graduates Income Practice Question
 * Program:   |  students.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  03/05/21
 * -----------|-----------------------------------------------------------------------------------
 * Purpose:   |  Write a program to read all the records from the file and report:
 *            |     - The total number of graduates in each band
 *            |     - the total number of females in each band
 *            |     - the total number of males in each band.
 *            |     - the overall total number graduates,
 *            |     - total number of females
 *            |     - the total number of males
 *            |  The program will include exception handling to deal with any IO-related exception.
 * -----------|-----------------------------------------------------------------------------------
 * Mods:      | 
 * -----------|-----------------------------------------------------------------------------------
 * BUGS:      |  
 * ==============================================================================================*/

using System;
using System.IO;
using System.Collections.Generic;

namespace students
{
    class Program
    {
        private const string PATH = @"./graduates.txt";
        private static string[] bands = { "0 - 20,000", "20,001 - 40.000", "40,001 - 60,000", "60,000+" };

        static void Main(string[] args)
        {
            FileStream fs = null;
            StreamReader sr = null;
            string lineIn = "";
            List<Graduate> graduates = new List<Graduate>();

            try
            {
                fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                while ((lineIn = sr.ReadLine()) != null)
                {
                    CreateGraduates(lineIn, graduates);
                }//END: while(lineIn != null)
                TestPrintObjectsFromFile(graduates);

                DisplayGenderReport(graduates);

                
                int[,] bandCount = new int[4,3];
                for (int i = 0; i < graduates.Count; i++)
                {
                    if (graduates[i].Salary > 60000)
                    {
                        bandCount[3,0]++;       //++ the income band
                        if (graduates[i].Gender == "male")
                        {
                            bandCount[3,1]++;   //++ number of males in this band
                        }
                        else
                        {
                            bandCount[3,2]++;   //++ number of females
                        }
                    }
                    else if (graduates[i].Salary > 40000)
                    {
                        bandCount[2,0]++;
                        if (graduates[i].Gender == "male")
                        {
                            bandCount[2,1]++;   //++ number of males in this band
                        }
                        else
                        {
                            bandCount[2, 2]++;  //++ number of females
                        }
                    }
                    else if (graduates[i].Salary > 20000)
                    {
                        bandCount[1, 0]++;
                        if (graduates[i].Gender == "male")
                        {
                            bandCount[1, 1]++;   //++ number of males in this band
                        }
                        else
                        {
                            bandCount[1, 2]++;  //++ number of females2
                        }
                    }
                    else
                    {
                        bandCount[0, 0]++;
                        if (graduates[i].Gender == "male")
                        {
                            bandCount[0, 1]++;   //++ number of males in this band
                        }
                        else
                        {
                            bandCount[0, 2]++;  //++ number of females2
                        }
                    }

                }//End: for()

                Console.WriteLine();
                Console.WriteLine($"{"Salary Band", -17}{"Females", -8}{"Males", -8}{"Total", -8}");
                for (int i = 0; i < bands.Length; i++)
                {
                    Console.WriteLine($"{bands[i], -17}{bandCount[1,i], -8}{bandCount[2,i], -8}{bandCount[3,i], -8}");
                }


            }//END: try block
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\nError: File was not found in the specified directory.\n" + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"\nError reading from file : {PATH}\n" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nUnspecified error occured while attempting to read from file.\n" + ex.Message);
            }            

            




        }//END: Main()

        private static void CreateGraduates(string lineIn, List<Graduate> graduates)
        {
            string[] fields = lineIn.Split(',');

            if (fields.Length == 3 && double.TryParse(fields[2], out double income))
            {
                Graduate newGrad = new Graduate(fields[0], fields[1], Convert.ToInt32(fields[2]));
                graduates.Add(newGrad);
            }
        }


        /// <summary>
        /// Method counts the number of males, females and the total graduates in the List and displays the report
        /// </summary>
        /// <param name="graduates"></param>
        private static void DisplayGenderReport(List<Graduate> graduates)
        {
            int[] counts = new int[3];
            bool validGender = false;

            for (int i = 0; i < graduates.Count; i++)
            {
                if (graduates[i].Gender == "male")
                {
                    counts[0]++;
                    validGender = true;
                }
                else if (graduates[i].Gender == "female")
                {
                    counts[1]++;    //increment females
                    validGender = true;
                }
                else
                    Console.WriteLine("Gender field in incorrect format");
                
                if (validGender)
                    counts[2]++;     //increment total number of grads
            }

            Console.WriteLine($"{"Males",-6}{"females",-8}{"total",-6}");
            Console.WriteLine($"{counts[0],-6}{counts[1],-8}{counts[2],-6}");
        }


        /// <summary>
        /// Method prints all objects in the graduates List
        /// </summary>
        /// <param name="gradutates"></param>
        private static void TestPrintObjectsFromFile(List<Graduate> gradutates)
        {
            Console.WriteLine();
            Console.WriteLine($"{"Student No.",-12}{"Gender",-10}{"Salary",-10}");
            foreach (Graduate g in gradutates)
            {
                Console.WriteLine(g.ToString());
            }
        }


    }//END: Program class 
}
