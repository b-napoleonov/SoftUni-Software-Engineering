using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;

            while (input != "Stop")
            {
                int number = int.Parse(input);
                if (maxNumber < number)
                {
                    maxNumber = number;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}
