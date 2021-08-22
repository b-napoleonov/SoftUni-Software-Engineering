using System;

namespace _09_Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            float lightsaberPrice = float.Parse(Console.ReadLine());
            float robesPrice = float.Parse(Console.ReadLine());
            float beltPrice = float.Parse(Console.ReadLine());

            double lightsabers = Math.Ceiling(studentsCount * 1.1);

            float totalLightsabers = (float)lightsabers * lightsaberPrice;
            float totalRobes = robesPrice * studentsCount;
            int freeBelt = studentsCount / 6;
            studentsCount -= freeBelt;
            float totalBelts = studentsCount * beltPrice;

            float total = totalLightsabers + totalRobes + totalBelts;

            if (total <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {total - money:f2}lv more.");
            }
        }
    }
}
