using System;
using System.Linq;

namespace _02._TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (peopleWaiting <= 0)
            {
                Console.WriteLine(string.Join(' ', array));
                return;
            }

            peopleWaiting = WagonFill(peopleWaiting, array);

            if (peopleWaiting == 0 && array.Sum() < array.Length * 4)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(' ', array));
            }
            else if (peopleWaiting != 0 && array.Sum() == array.Length * 4)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine($"{string.Join(' ', array)}");
            }
            else
            {
                Console.WriteLine(string.Join(' ', array));
            }
        }

        private static int WagonFill(int peopleWaiting, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (array[i] < 4)
                    {
                        array[i]++;
                        peopleWaiting--;

                        if (peopleWaiting == 0)
                        {
                            return peopleWaiting;
                        }
                    }
                }
            }

            return peopleWaiting;
        }
    }
}
