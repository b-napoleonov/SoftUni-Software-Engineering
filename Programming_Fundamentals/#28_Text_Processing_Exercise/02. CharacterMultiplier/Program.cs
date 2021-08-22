using System;

namespace _02._CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string first = arr[0];
            string second = arr[1];

            int sum = 0;
            int min = Math.Min(first.Length, second.Length);

            for (int i = 0; i < min; i++)
            {
                sum += first[i] * second[i];
            }

            if (first.Length > second.Length)
            {
                for (int i = min; i < first.Length; i++)
                {
                    sum += first[i];
                }
            }
            else if (first.Length < second.Length)
            {
                for (int i = min; i < second.Length; i++)
                {
                    sum += second[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
