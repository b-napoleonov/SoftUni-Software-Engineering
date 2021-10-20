using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Peek() + ingredients.Peek();

                switch (sum)
                {
                    case 25:

                        breadCount++;
                        liquids.Dequeue();
                        ingredients.Pop();

                        break;

                    case 50:

                        cakeCount++;
                        liquids.Dequeue();
                        ingredients.Pop();

                        break;

                    case 75:

                        pastryCount++;
                        liquids.Dequeue();
                        ingredients.Pop();

                        break;

                    case 100:

                        fruitPieCount++;
                        liquids.Dequeue();
                        ingredients.Pop();

                        break;

                    default:

                        liquids.Dequeue();
                        ingredients.Push(ingredients.Pop() + 3);

                        break;
                }
            }

            bool isCooked = breadCount >= 1 && cakeCount >= 1 && pastryCount >= 1 && fruitPieCount >= 1;

            Console.WriteLine(isCooked ? "Wohoo! You succeeded in cooking all the food!" : 
                "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Any() ? $"Liquids left: {string.Join(", ", liquids)}" : "Liquids left: none");
            Console.WriteLine(ingredients.Any() ? $"Ingredients left: {string.Join(", ", ingredients)}" : "Ingredients left: none");

            Console.WriteLine($@"Bread: {breadCount} 
Cake: {cakeCount} 
Fruit Pie: {fruitPieCount} 
Pastry: {pastryCount}");
        }
    }
}
