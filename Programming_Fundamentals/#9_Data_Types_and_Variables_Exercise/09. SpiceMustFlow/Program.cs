using System;

namespace _09._SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int extracted = 0;
            int counter = 0;

            while (yield >= 100)
            {
                counter++;
                extracted += yield;
                if (extracted - 26 < 0)
                {
                    yield -= 10;
                    continue;
                }
                
                extracted -= 26;

                yield -= 10;
            }
            if (yield < 100 && extracted - 26 > 0)
            {
                extracted -= 26;
            }
            Console.WriteLine(counter);
            Console.WriteLine(extracted);
        }
    }
}
