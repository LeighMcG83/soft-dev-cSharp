/* ===================================================================
 * Worksheet: |  Semester 1 Revision 
 * Program:   |  q5_avg_min_max.cs
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  25/01/21
 * _ _ _ _ _ _| _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Purpose:   |  Revision of Loops and Decision Structures
 *            |  
 *            |  An on line book retailer charges a flat 2.50 for each  
 *            |  delivery, on top of which it applies the following:
 *            |     - the progressive fee rate depending on delivery weight.
 *            |  The progressive fee rate is applicable to the book total weight.
 *            |  
 *            |  Type of delivery 	For  weight of Books	Fee Rate (Euro/gram)
 *            |  ----------------------------------------------------------------
 *            |  Regular	        0 - 2000 grams	        0.025
 *            |  Regular	        2001 – 5000 grams	    0.03
 *            |  Regular	        5001 and over	        0.05
 *            |  Express	        Regular plus 1.50
 *            |  Super Express	    Regular plus 2.50
 *            |  Super Super Exp.   Regular plus 3.50
 * _ _ _ _ _ _|_ _ __ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
 * Mods:      | 
 * ===================================================================*/

using System;

namespace Part2_q2_bookDelivery
{
    class Program
    {
        // declare public display tables
        const string INPUTTAB = "{0, -40}{1, -5}";
        const string OUTPUTTAB = "{0, -40}{1, -5}";
        const string MENUTAB = "{0, 10}{1, -5}";

        static void Main(string[] args)
        {
            // Encoding to allow us to print sepcial characters to the screen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // variable ininitialization
            double deliveryCost = 0;
            char deliveryType = ' ', response = ' ';
            int expressType = 0;
            bool askAgain = true;            

            while (askAgain)
            {
                double weight = GetBookWeight();            // prompt user for weight             
                char weightCat = GetWeightCategory(weight); // call weight category calculation method                                
                deliveryType = GetDeliveryType();           // promt user for tyoe of delivery - reg / express

                // if chose express get type of exress - express / super / super-super
                if (deliveryType == 'X')
                {
                    try
                    {                                                                  
                        expressType = GetExpressType();
                    }
                    catch (Exception)
                    { 
                        Console.WriteLine("\nInvalid Entry...Please enter 1, 2 or 3");
                    }
                }

                double baseCost = GetBaseCost(weight, weightCat);   // calculate base cost of delivery

                if (expressType != 0)
                {
                    // call delivery cost calculation method
                    deliveryCost = ExpressDelCost(expressType, baseCost, weight);
                }
                else
                {
                    deliveryCost = baseCost;    
                }
                
                DisplayCost(deliveryCost);  // Display the cost of the delivery

                response = ' ';
                try
                {
                    while (response != 'Y' && response != 'N')
                    {
                        Console.Write(INPUTTAB, "\n\nWould you like to calculuate another (y/n)", ": ");
                        response = Convert.ToChar(Console.ReadLine().ToUpper());
                        if (response == 'N')
                        {
                            askAgain = false;
                        }
                    } // END: while(respone !=)
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry"); ;
                }
                
                
            } // END: while(askAgain)

        } // end of Main()


        /************ USER DEFINED METHODS ********************/

        //Method to get the weight of the book to be delivered
        static public double GetBookWeight()
        {            
            Console.Write(INPUTTAB, "\nEnter the weight of book", ": ");
            double weight = double.Parse(Console.ReadLine());
            //// test
            //Console.WriteLine($"\nweight : {weight}");

            return weight;
        } // END: GetBookWeight()


        // Method to get the delivery method
        static public char GetDeliveryType()
        {
            char deliveryType = ' ';

            while (!(deliveryType == 'X') && !(deliveryType == 'R'))
            {
                Console.WriteLine("\nEnter the delivery method");
                Console.Write(INPUTTAB, "(R = Regulaer, X = eXpress)", ": ");
                deliveryType = char.Parse(Console.ReadLine().ToUpper());
                ////Test
                //Console.WriteLine($"\ndelType : {deliveryType}");
            } // end while (!= R && != X)

            return deliveryType;
        } // END: GetDeliveryType()


        // method to calculate the weight category
        static public char GetWeightCategory(double weight)
        {
            char category = ' ';
            
            // determine weight category
            if (weight <= 2000)
                { category = 'A'; }

            else if (weight <= 5000) 
                { category = 'B'; }

            else { category = 'C'; }
            
            //// Test
            //Console.WriteLine($"\ncategory : {category}");

            return category;
        }


        // method to calculate standard delivery
        static public double GetBaseCost(double weight, char weightCat)
        {
            const double REGULAR_UNDER_2000 = 0.025, REGULAR_2001_5000 = 0.03, REGULAR_OVER_5000 = 0.05;
            double baseCost = 0;

            if (weightCat == 'A')
                { baseCost = weight * REGULAR_UNDER_2000; }
            else if (weightCat == 'B')
                { baseCost = (weight * REGULAR_UNDER_2000) + ((weight - 2000) * REGULAR_2001_5000); }
            else
                { baseCost = (weight * REGULAR_UNDER_2000) + ((weight - 2000) * REGULAR_2001_5000) + ((weight - 5000) * REGULAR_OVER_5000); }

            ////Test
            //Console.WriteLine($"\nBaseCost : { baseCost}");

            return baseCost;
        }//END: GetBaseCost()


        // Method to get express type
        static public int GetExpressType()
        {
            Console.WriteLine("Do you want:");
            Console.WriteLine(MENUTAB,"", "1. Express");
            Console.WriteLine(MENUTAB,"", "2. Super-Express");
            Console.WriteLine(MENUTAB,"", "3. Super-Super-Express");
            Console.Write(INPUTTAB, "Enter Choice (1,2, or 3)", ": ");
            int expressType = int.Parse(Console.ReadLine());

            return expressType;
        }

        // method to calculate express delivery 
        static public double ExpressDelCost(int expressType, double baseCost, double weight)
        {
            const double EXPRESS_1 = 1.5, EXPRESS_2 = 2.5, EXPRESS_3 = 3.5;
            double total = 0;
            // if express, add express charge
            if (expressType == 1)
            {
                total = baseCost + EXPRESS_1;
            }
            // else-if is super-express, add supExpress charge
            else if (expressType == 2)
            {
                total = baseCost + EXPRESS_2;
            }
            // else, apply catC charge
            else
            {
                total = baseCost + EXPRESS_3;
            }

            return total;

        } // END: ExpressDelCost()
        

        // method to display the cost of delivery
        static public void DisplayCost(double deliveryCost)
        {
            Console.WriteLine(OUTPUTTAB, "\nDelivery Cost", $": {deliveryCost:c2}");
        }//END: DisplayCost()


    } // END OF: class - Program
}
