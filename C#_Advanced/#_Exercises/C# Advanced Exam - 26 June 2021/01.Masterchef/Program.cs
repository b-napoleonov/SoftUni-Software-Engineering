using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int dippingSauceCount = 0;
            int greenSaladCount = 0;
            int chocolateCakeCount = 0;
            int lobsterCount = 0;

            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int sum = ingredients.Peek() * freshness.Peek();

                switch (sum)
                {
                    case 150:

                        dippingSauceCount++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    case 250:

                        greenSaladCount++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    case 300:

                        chocolateCakeCount++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    case 400:

                        lobsterCount++;
                        ingredients.Dequeue();
                        freshness.Pop();
                        break;

                    default:

                        freshness.Pop();
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        break;
                }
            }

            bool arePrepared = dippingSauceCount >= 1 && greenSaladCount >= 1 && chocolateCakeCount >= 1 && lobsterCount >= 1;
            Console.WriteLine(arePrepared ? 
                "Applause! The judges are fascinated by your dishes!" : 
                "You were voted off. Better luck next year.");

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCakeCount >= 1)
            {
                Console.WriteLine($" # Chocolate cake --> {chocolateCakeCount}");
            }
            if (dippingSauceCount >= 1)
            {
                Console.WriteLine($" # Dipping sauce --> {dippingSauceCount}");
            }
            if (greenSaladCount >= 1)
            {
                Console.WriteLine($" # Green salad --> {greenSaladCount}");
            }
            if (lobsterCount >= 1)
            {
                Console.WriteLine($" # Lobster --> {lobsterCount}");
            }
        }
    }
}
