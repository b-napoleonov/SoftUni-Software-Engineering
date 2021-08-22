using System;

namespace _01._CS
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int count = 0;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (initialEnergy - distance >= 0)
                {
                    initialEnergy -= distance;
                    count++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
                    return;
                }

                if (count % 3 == 0)
                {
                    initialEnergy += count;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
        }
    }
}
