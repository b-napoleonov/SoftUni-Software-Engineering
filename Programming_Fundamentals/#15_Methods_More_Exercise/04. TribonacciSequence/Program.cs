using System;

namespace _04._TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] result = TribonacciNumbers(number);

            Console.WriteLine(string.Join(' ', result));
        }

        private static int[] TribonacciNumbers(int number)
        {
            int[] arr = new int[number];
            arr[0] = 1;

            for (int i = 1; i < number; i++)
            {
                if (i == 2)
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }
                else if (i >= 3)
                {
                    arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
                }
                else
                {
                    arr[i] = arr[i - 1];
                }
            }
            return arr;
        }
    }
}
