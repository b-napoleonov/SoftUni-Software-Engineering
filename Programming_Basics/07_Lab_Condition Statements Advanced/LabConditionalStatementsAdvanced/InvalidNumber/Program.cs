using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (!(number >= 100 && number <= 200))
            {
                if (number == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
