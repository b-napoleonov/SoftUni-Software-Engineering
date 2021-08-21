using System;

namespace timePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int minutesPlus15 = minutes + 15;

            if (minutesPlus15 >= 60)
            {
                minutesPlus15 = minutesPlus15 % 60;
                hour ++;
                if (hour >= 24)
                {
                    hour = 0;
                }
            }

            if (minutesPlus15 < 10)
            {
                Console.WriteLine($"{hour}:0{minutesPlus15}");
            }
            else
            {
                Console.WriteLine($"{hour}:{minutesPlus15}");
            }
        }
    }
}
