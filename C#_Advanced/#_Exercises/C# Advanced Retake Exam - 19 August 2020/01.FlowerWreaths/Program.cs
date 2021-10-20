using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wreaths = 0;
            int extra = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Peek() + roses.Peek();

                if (sum == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    wreaths++;
                }
                else if (sum > 15)
                {
                    //int temp = lilies.Pop() - 2;
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    extra += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            wreaths += extra / 15;

            Console.WriteLine(wreaths >= 5 ? $"You made it, you are going to the competition with {wreaths} wreaths!" :
                $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
