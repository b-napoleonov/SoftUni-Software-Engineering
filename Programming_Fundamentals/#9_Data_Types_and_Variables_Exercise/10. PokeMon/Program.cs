using System;

namespace _10._PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokes = 0;
            int originalPower = pokePower;

            while (pokePower >= distance)
            {
                pokes++;
                
                pokePower -= distance;

                if (pokePower == (decimal)originalPower / 2 && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokes);
        }
    }
}
