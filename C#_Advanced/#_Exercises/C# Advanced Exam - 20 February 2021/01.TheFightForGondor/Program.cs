using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> warriorOrcs = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                if (!plates.Any())
                {
                    break;
                }

                warriorOrcs = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (warriorOrcs.Any() && plates.Any())
                {
                    if (warriorOrcs.Peek() > plates.Peek())
                    {
                        warriorOrcs.Push(warriorOrcs.Pop() - plates.Peek());
                        plates.Dequeue();
                    }
                    else if (plates.Peek() > warriorOrcs.Peek())
                    {
                        int count = plates.Count;
                        plates.Enqueue(plates.Dequeue() - warriorOrcs.Peek());

                        for (int j = 0; j < count - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                        warriorOrcs.Pop();
                    }
                    else
                    {
                        warriorOrcs.Pop();
                        plates.Dequeue();
                    }
                }
            }

            Console.WriteLine(warriorOrcs.Any() ? "The orcs successfully destroyed the Gondor's defense." : "The people successfully repulsed the orc's attack.");

            Console.WriteLine(warriorOrcs.Any() ? $"Orcs left: {string.Join(", ", warriorOrcs)}" : $"Plates left: {string.Join(", ", plates)}");
        }
    }
}
