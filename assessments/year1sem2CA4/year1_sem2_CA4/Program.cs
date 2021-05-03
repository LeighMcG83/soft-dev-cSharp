/* ==============================================================================================
 * Worksheet: |  Year1 Semester2 CA4
 * Program:   |  year1_sem2_CA4.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Created:   |  04/05/21
 * -----------|-----------------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Collections.Generic;

namespace year1_sem2_CA4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 3
            Graduate[] graduates = new Graduate[]
            {
                new Graduate("anna", 20),
                new Graduate("james", 70),
                new HonoursGraduate("annabella", 20, "ML"),
                new HonoursGraduate("Paddy", 55, "HealthTracker")
            };

            Console.WriteLine($"{"Grad No",-10}{"Name", -15}{"Clasification", -15}{"Mark", -6}{"Topic", -10}");
            foreach (Graduate grad in graduates)
            {
                Console.WriteLine(grad.ToString());
            }


            //Question 4                       
            List<Graduate> gradsList = new List<Graduate>();

            ReadFileData(gradsList);        //read from the file, call to CreateGraduates() for each valid line
            DisplayGraduates(gradsList);

        }//END: Main()


        /// <summary>
        /// Method opens the file in read mode, reads a line and calls CreateGraduate() to create an object from each line in file
        /// </summary>
        /// <param name="PATH"></param>
        /// <param name="fs"></param>
        /// <param name="sr"></param>
        /// <param name="lineIn"></param>
        /// <param name="gradsList"></param>
        private static void ReadFileData(List<Graduate> gradsList)
        {
            const string PATH = @"./grads.csv";
            FileStream fs = null;
            StreamReader sr = null;
            string lineIn = "";
            try
            {
                fs = new FileStream(PATH, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                while ((lineIn = sr.ReadLine()) != null)
                {
                    CreateGraduates(lineIn, gradsList);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"\nError: File was not found in the specified directory.\n" + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"\nError reading from file : {PATH}\n" + ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("\nUnspecified error occurred while attempting to read from file.\n");
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }
        }


        /// <summary>
        /// Method displays the List of graduate objects
        /// </summary>
        /// <param name="gradsList"></param>
        private static void DisplayGraduates(List<Graduate> gradsList)
        {
            try
            {
                foreach (Graduate g in gradsList)
                {
                    Console.WriteLine(g.ToString());
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("\nError - tried to access a null object from DisplayGraduates()\n" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nError - unsoecified exception thrown while displaying graduates in DisplayGraduates().\n" + ex.Message);
            }
           
        }


        /// <summary>
        /// Method creates the List of Graduate objects from the data in the lines of the .csv file
        /// </summary>
        /// <param name="lineIn"></param>
        /// <param name="gradsList"></param>
        private static void CreateGraduates(string lineIn, List<Graduate> gradsList)
        {
            string[] fields = lineIn.Split(',');
            try
            {                
                if (fields.Length == 2 && int.TryParse(fields[1], out int mark))
                {
                    gradsList.Add(new Graduate(fields[0], mark));
                }
                else if (fields.Length == 3 && int.TryParse(fields[1], out mark))
                {                   
                    gradsList.Add(new HonoursGraduate(fields[0], mark, fields[2]));
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\nError - Index went out of bounds while indexing fields[].\n" + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nError - Data read from file in incorrect format" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nError - unspecified exception thrown whilecreating Graduate objects\n" + ex.Message);
            }
        }



    }//END: Program class
}
