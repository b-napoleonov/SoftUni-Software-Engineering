using System;

namespace HairSalon
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyGoal = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int total = 0;

            while (input != "closed")
            {
                int income = 0;
                switch (input)
                {
                    case "haircut":
                        string typeOfHaircut = Console.ReadLine();
                        switch (typeOfHaircut)
                        {
                            case "mens":
                                income = 15;
                                break;
                            case "ladies":
                                income = 20;
                                break;
                            case "kids":
                                income = 10;
                                break;
                        }
                        break;
                    case "color":
                        string typeOfDyeing = Console.ReadLine();
                        switch (typeOfDyeing)
                        {
                            case "touch up":
                                income = 20;
                                break;
                            case "full color":
                                income = 30;
                                break;
                        }
                        break;
                }
                total += income;
                if (total >= dailyGoal)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (total >= dailyGoal)
            {
                Console.WriteLine("You have reached your target for the day!");
                Console.WriteLine($"Earned money: {total}lv.");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {dailyGoal - total}lv. more.");
                Console.WriteLine($"Earned money: {total}lv.");
            }
        }
    }
}
