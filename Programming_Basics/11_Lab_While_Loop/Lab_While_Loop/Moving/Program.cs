using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeSpaceWidth = int.Parse(Console.ReadLine());
            int freeSpaceLength = int.Parse(Console.ReadLine());
            int freeSpaceHeight = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int freeSpace = freeSpaceWidth * freeSpaceLength * freeSpaceHeight;
            int sum = 0;

            while (input != "Done")
            {
                int boxCount = int.Parse(input);
                sum += boxCount;
                if (freeSpace < sum)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace - sum)} Cubic meters more.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{freeSpace - sum} Cubic meters left.");
        }
    }
}
