

using System;

namespace oopCar
{
    class Program
    {
        public const string DISPLAY_TAB = "{0, -10}{1, -10}{2, -10}{3, -10}";

        static void Main(string[] args)
        {
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
            
           


        }
    }
}
