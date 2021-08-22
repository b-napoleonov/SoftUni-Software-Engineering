using System;
using System.Numerics;

namespace _12._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger highestSnowballValue = 0;
            int bigSnow = 0;
            int bigTime = 0;
            int bigQuality = 0;

            for (int i = 1; i <= input; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (highestSnowballValue < snowballValue)
                {
                    highestSnowballValue = snowballValue;
                    bigSnow = snowballSnow;
                    bigTime = snowballTime;
                    bigQuality = snowballQuality;
                }
                if (i == input)
                {
                    Console.WriteLine($"{bigSnow} : {bigTime} = {highestSnowballValue} ({bigQuality})");
                }
            }
        }
    }
}
