using System;

namespace method_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] reverse = Reverse(numbers);
                
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(reverse[i]);
            }
        }

        static int[] Reverse(int[] numbers)
        {
            int[] reverse = new int[numbers.Length];
            int start = numbers[numbers.Length - 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                reverse[i] = numbers[start];
                start--;
            }
            return reverse;
        }
    }
}
