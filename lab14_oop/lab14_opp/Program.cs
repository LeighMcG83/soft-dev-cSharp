using System;

namespace lab14_opp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Encoding to allow us to print sepcial characters to the screen.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Rectangle box1 = new Rectangle();    //create a  angle obj

            box1.Length = 30;                    //assign a length to the length attribute
            box1.Width = 10;
            int area = box1.CalcArea();

            Console.WriteLine("RECTANGLES");
            Console.WriteLine($"The area of box1 is {area}");
            Console.WriteLine(box1.ToString());             //call ToString() to display the info about the object

            Rectangle box2 = new Rectangle(20, 20);         //creat an object and pass values to the constructor
            Console.WriteLine($"\nThe area of box2 is {box2.CalcArea()}");
            Console.WriteLine(box2.ToString());

            Console.WriteLine("\nCIRCLES");
            Circle defaultCirc = new Circle();              //created from default ctor
            Console.WriteLine(defaultCirc.ToString());

            Circle paramCirc = new Circle(2);               //created from paramaterized ctor
            Console.WriteLine("\n" + paramCirc.ToString());

            Circle[] circles = new Circle[4];
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = new Circle();
            }

            //q2.(ix)
            circles[0].Radius = 10;                         //used the getter/setter to set property 'Radius' to 10
            circles[2].Radius = 10;

            //q2.(x)
            Console.WriteLine();
            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine($"Radius of circle {i + 1}: {circles[i].Radius}");
            }
            
            //q2 (xi)
            Console.WriteLine();
            Console.WriteLine($"Area of first circle: {circles[0].GetArea()}");
            Console.WriteLine($"Area of last circle: {circles[circles.Length - 1].GetArea()}");        

            //q2.(xii)
            Console.WriteLine($"3rd circle details: {circles[2].ToString()}");

            //Q3
            //q3.1 (i)
            Employee newEmployee = new Employee();

            //q3.1 (ii)
            newEmployee.Gender = "male";
            newEmployee.Name = "Leigh";

            //q3.1 (iii)
            //default .ToString()
            Console.WriteLine($"\nNew employees details: {newEmployee.ToString()}"); 

            //q3.1 (iv)
            Employee employee2 = new Employee();

            //q3.1 (v)
            Console.Write($"\nEmployee 2 details: {employee2.ToString()}");
            Console.WriteLine("Created by empty ctor");

            /*Find out how to create multiple ctors with different params
             * 4 attributes -> 24 possible ctors??
             * */

            //q3.1 (Viii)
            Employee employee3 = new Employee("British");
            Console.WriteLine($"\nEmployee 3 nationailty: {employee3.Nationality}");
            /*Problem here - most likely in class
             *  Whn "Britsih" is passed, value "Visa Required" not set
             *  */

            //q3.1(x)
            Employee employee4 = new Employee();
            Console.WriteLine($"Tax: {employee4.CalcTax(20000):c2}");


        }//END: Main()
    }
}
