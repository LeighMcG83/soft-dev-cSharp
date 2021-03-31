

using System;

namespace oopCar
{
    class Program
    {
        public const string DISPLAY_TAB = "{0, -10}{1, -10}{2, -10}{3, -10}";

        static void Main(string[] args)
        {
            Car c = new Car("BMW");
            Console.WriteLine(c.ToString());


            Car c2 = new Car("BMW", "5-Series");
            Console.WriteLine(c2.ToString());


            Car c3 = new Car("BMW", "3-Series", "White");
            Console.WriteLine(c3.ToString());


            Car c4 = new Car("Skoda", "Octavia", "Red");
            Console.WriteLine(c4.ToString());

            

        }
    }
}
