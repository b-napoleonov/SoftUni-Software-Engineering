using System;
using System.Linq;

namespace _02._ShootWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < arr.Count() && arr[index] != -1)
                {
                    int current = arr[index];
                    arr[index] = -1;
                    counter++;

                    for (int i = 0; i < arr.Count(); i++)
                    {
                        if (arr[i] > current && arr[i] != -1)
                        {
                            arr[i] -= current;
                        }
                        else if (arr[i] <= current && arr[i] != -1)
                        {
                            arr[i] += current;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(' ', arr)}");
        }
    }
}
