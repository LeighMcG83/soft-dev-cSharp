using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validInput = false;
            int choice;
            

            do
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("----------------");
                Console.WriteLine("1. PUSH AN OBJECT ONTO THE STACK");
                Console.WriteLine("2. POP AN OBJECT OFF THE TOP OF THE STACK");
                Console.WriteLine("3. EMPTY THE STACK");
                Console.WriteLine("4. DISPLAY THE CURRENT STACK ORDER");
                Console.WriteLine("\nChoicce: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    choice = Convert.ToInt32(input);
                    validInput = true;
                }
            } while (!validInput);

            switch (choice)
            {
                case 1:
                    StackItem item = new StackItem();
                    stackList.Add(item.Push(item));
                default:
                    break;
            }
        }//END: Main()



    }//END: Program class

}
