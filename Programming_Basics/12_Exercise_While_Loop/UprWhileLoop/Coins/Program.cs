using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double lv = Math.Floor(change);
            double coins = Math.Round((change - lv) * 100);
            int br = 0;

            while (lv > 0)
            {
                if (lv >= 2)
                {
                    lv -= 2;
                    br++;
                }
                else if (lv >= 1)
                {
                    lv -= 1;
                    br++;
                }
            }
            while (coins > 0)
            {
                if (coins >= 50)
                {
                    coins -= 50;
                    br++;
                }
                else if (coins >= 20)
                {
                    coins -= 20;
                    br++;
                }
                else if (coins >= 10)
                {
                    coins -= 10;
                    br++;
                }
                else if (coins >= 5)
                {
                    coins -= 5;
                    br++;
                }
                else if (coins >= 2)
                {
                    coins -= 2;
                    br++;
                }
                else if (coins >= 1)
                {
                    coins -= 1;
                    br++;
                }
            }
            Console.WriteLine(br);
        }
    }
}
