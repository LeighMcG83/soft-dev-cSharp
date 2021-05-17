using System;

namespace _2021_Alternate_Final_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            //test both ctors
            Apprentice appr = new Apprentice();
            Apprentice appr2 = new Apprentice("Leigh", 10);
            Console.WriteLine(appr.ToString());
            Console.WriteLine(appr2.ToString());

            Certified appr3 = new Certified();
            Certified appr4 = new Certified("CARPENTRY");
            Certified appr5 = new Certified("programmer");

            Console.WriteLine(appr3.ToString());
            Console.WriteLine(appr4.ToString());
            Console.WriteLine(appr5.ToString());
        }
    }
}
