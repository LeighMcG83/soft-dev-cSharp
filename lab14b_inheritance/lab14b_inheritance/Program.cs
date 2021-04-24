

using System;

namespace lab14b_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            RunQuestion2();

            RunQuestion3();

        }//End: Main()


        /// <summary>
        /// Method runs Lab 14: Inheritance Question 3
        /// </summary>
        private static void RunQuestion3()
        {
            Computer[] AllComputers = CreateComputers();
            Console.WriteLine("------Computers-------");
            DisplayAllObjectsIn(AllComputers);
            PowerOnComputers(AllComputers);
            PowerOffComputers(AllComputers);
            Console.WriteLine();

            DesktopComputer[] Desktops = CreateDesktopComputers();
            Console.WriteLine("------Desktops-------");
            DisplayAllObjectsIn(Desktops);
            PowerOnComputers(Desktops);
            PowerOffComputers(Desktops);
            Console.WriteLine();

            LaptopComputer[] Laptops = CreateLaptops();
            Console.WriteLine("------Laptops-------");
            DisplayAllObjectsIn(Laptops);
            PowerOnComputers(Laptops);
            PowerOffComputers(Laptops);
        }

        /// <summary>
        /// Method creates an array of laptopComputer objects
        /// </summary>
        /// <returns></returns>
        private static LaptopComputer[] CreateLaptops()
        {
            return new LaptopComputer[]
            {
                new LaptopComputer("USA", "Dell", 1400.00, 17, 5, 80, "Corded"),
                new LaptopComputer("USA", "intel", 2000.00, 22, 8, 50, "TouchPad"),
            };
        }

        /// <summary>
        /// Method creates an array of DesktopComputer objects
        /// </summary>
        /// <returns></returns>
        private static DesktopComputer[] CreateDesktopComputers()
        {
            return new DesktopComputer[]
                        {
                new DesktopComputer("Toshiba", "Japan", 1550.50, 17),
                new DesktopComputer("Apple", "USA", 1750, 19),
                        };
        }

        /// <summary>
        /// Method creates an array of Computer objects
        /// </summary>
        /// <returns></returns>
        private static Computer[] CreateComputers()
        {
            return new Computer[]
            {
                new Computer("Toshiba", "Japan"),
                new Computer("Apple", "USA"),
            };
        }

        /// <summary>
        /// Method powers on all Computer objects in an array of computers
        /// </summary>
        /// <param name="objArr"></param>
        private static void PowerOffComputers(Computer[] objArr)
        {
            for (int i = 0; i < objArr.Length; i++)
                Console.WriteLine(objArr[i].TurnOff() + " " +objArr[i].GetType());
        }

        /// <summary>
        /// Method powers off all Computer objects in an array of computers
        /// </summary>
        /// <param name="objArr"></param>
        private static void PowerOnComputers(Computer[] objArr)
        {
            for (int i = 0; i < objArr.Length; i++)
                Console.WriteLine(objArr[i].TurnOn() + " " + objArr[i].GetType());
        }

        /// <summary>
        /// Run Lab14: Inheritance - Q2
        /// </summary>
        private static void RunQuestion2()
        {
            Rectangle[] rectangles = CreateRectArray();
            DisplayAllObjectsIn(rectangles);

            Box[] boxes = CreateBoxArray();
            DisplayAllObjectsIn(boxes);
        }


        /// <summary>
        /// Create an array of 2 Box objects
        /// </summary>
        /// <returns></returns>
        private static Box[] CreateBoxArray()
        {
            return new Box[]
            {
                new Box(2,3,4),
                new Box(4,5,6),
            };
        }


        /// <summary>
        /// Create an array of 2 rectangle objects
        /// </summary>
        /// <returns></returns>
        private static Rectangle[] CreateRectArray()
        {
            return new Rectangle[]
                        {
                new Rectangle(2,3),
                new Rectangle(4,5),
                        };
        }


        /// <summary>
        /// Method takes an array of objects as a param and calls ToString() on each object in the array
        /// </summary>
        /// <param name="objArr"></param>
        private static void DisplayAllObjectsIn(Object[] objArr)
        {
            foreach (object obj in objArr)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
