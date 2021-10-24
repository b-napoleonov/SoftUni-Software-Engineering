using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCeleb
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guestCapacity = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wastedFood = 0;

            while (guestCapacity.Any() && plates.Any())
            {
                if (guestCapacity.Peek() <= plates.Peek())
                {
                    wastedFood += plates.Pop() - guestCapacity.Dequeue();
                }
                else if (guestCapacity.Peek() > plates.Peek())
                {
                    guestCapacity.Enqueue(guestCapacity.Dequeue() - plates.Pop());

                    for (int i = 0; i < guestCapacity.Count - 1; i++)
                    {
                        guestCapacity.Enqueue(guestCapacity.Dequeue());
                    }
                }
            }

            Console.WriteLine(guestCapacity.Any() ? $"Guests: {string.Join(' ', guestCapacity)}" : $"Plates: {string.Join(' ', plates)}");
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
