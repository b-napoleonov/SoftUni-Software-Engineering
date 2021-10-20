using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> lootBox1 = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> lootBox2 = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int lootSum = 0;

            while (lootBox1.Any() && lootBox2.Any())
            {
                int sum = lootBox1.Peek() + lootBox2.Peek();

                if (sum % 2 == 0)
                {
                    lootSum += lootBox1.Dequeue() + lootBox2.Pop();
                }
                else
                {
                    lootBox1.Enqueue(lootBox2.Pop());
                }
            }

            Console.WriteLine(lootBox1.Count <= 0 ? "First lootbox is empty" : "Second lootbox is empty");
            Console.WriteLine(lootSum >= 100 ? $"Your loot was epic! Value: {lootSum}" : $"Your loot was poor... Value: {lootSum}");
        }
    }
}
