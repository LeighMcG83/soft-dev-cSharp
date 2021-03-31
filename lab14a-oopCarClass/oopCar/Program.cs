

using System;

namespace oopCar
{
    class Program
    {
        public const string DISPLAY_TAB = "{0, -10}{1, -10}{2, -10}{3, -10}";

        static void Main(string[] args)
        {
<<<<<<< HEAD
            Car c = new Car("BMW");
            Console.WriteLine(c.ToString());


            Car c2 = new Car("BMW", "5-Series");
            Console.WriteLine(c2.ToString());


            Car c3 = new Car("BMW", "3-Series", "White");
            Console.WriteLine(c3.ToString());


            Car c4 = new Car("Skoda", "Octavia", "Red");
            Console.WriteLine(c4.ToString());

            
=======
            bool isValid = false;

            do
            {        

                try
                {
                    isValid = true;

                    Car car2 = new Car();

                    car2.Make = "Toyota";
                    car2.Model = "Avensis";
                    car2.Color = "Red";

                    Console.WriteLine(DISPLAY_TAB, "Make", "Model", "Colour", "Registration");
                    Console.WriteLine(car2.ToString());
                    
                }
                catch (Exception ex)
                {
                    isValid = false;
                    Console.WriteLine(ex.Message);
                }
                
            } while (isValid == false);
            
           

>>>>>>> bf9f848c96c015a5e436bfbc1be0f595ffff41b8

        }
    }
}
