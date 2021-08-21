using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int steps;
            int sum = 0;

            while (input != "Going home")
            {
                steps = int.Parse(input);
                sum += steps;
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sum - 10000} steps over the goal!");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Going home")
            {
                steps = int.Parse(Console.ReadLine());
                sum += steps;
                if (sum < 10000)
                {
                    Console.WriteLine($"{10000 - sum} more steps to reach goal.");
                }
                else
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sum - 10000} steps over the goal!");
                }
            }
        }
    }
}
