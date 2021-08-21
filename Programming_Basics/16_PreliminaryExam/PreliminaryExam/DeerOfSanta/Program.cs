using System;

namespace DeerOfSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysSantaIsGone = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double foodForTheFirstDeer = double.Parse(Console.ReadLine());
            double foodForTheSecondDeer = double.Parse(Console.ReadLine());
            double foodForTheThirdDeer = double.Parse(Console.ReadLine());

            double foodNeededForTheFirstDeer = daysSantaIsGone * foodForTheFirstDeer;
            double foodNeededForTheSecondDeer = daysSantaIsGone * foodForTheSecondDeer;
            double foodNeededForTheThirdDeer = daysSantaIsGone * foodForTheThirdDeer;

            double totalFoodNeeded = foodNeededForTheFirstDeer + foodNeededForTheSecondDeer + foodNeededForTheThirdDeer;

            if (totalFoodNeeded <= food)
            {
                Console.WriteLine($"{Math.Floor(food - totalFoodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFoodNeeded - food)} more kilos of food are needed.");
            }
        }
    }
}
