using System;

namespace GenericBoxOfInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfIntegers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfIntegers; i++)
            {
                Box<int> integers = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(integers);
            }
        }
    }
}
