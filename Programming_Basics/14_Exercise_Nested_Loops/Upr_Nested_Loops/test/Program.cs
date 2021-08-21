using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Широчина на свободното пространство - цяло число в интервала[1...1000]
            int weight = int.Parse(Console.ReadLine());
            //2.Дължина на свободното пространство - цяло число в интервала[1...1000]
            int lenght = int.Parse(Console.ReadLine());
            //3.Височина на свободното пространство - цяло число в интервала[1...1000]
            int height = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int freeSpace = weight * lenght * height;



            while (command != "Done")
            {
                int boxes = int.Parse(command);

                if (freeSpace < boxes)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    break;
                }
                freeSpace -= boxes;


                command = Console.ReadLine();
            }
            if (command == "Done")
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
        }
    }
}
