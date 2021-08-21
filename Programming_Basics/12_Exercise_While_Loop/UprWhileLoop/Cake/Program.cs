using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cakeSize = cakeWidth * cakeLength;
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "STOP")
            {
                int pieces = int.Parse(input);
                sum += pieces;
                if (sum > cakeSize)
                {
                    Console.WriteLine($"No more cake left! You need {sum - cakeSize} pieces more.");
                    break;
                }

                input = Console.ReadLine();
            }
            if (input == "STOP")
            {
                Console.WriteLine($"{cakeSize - sum} pieces are left.");
            }
        }
    }
}
