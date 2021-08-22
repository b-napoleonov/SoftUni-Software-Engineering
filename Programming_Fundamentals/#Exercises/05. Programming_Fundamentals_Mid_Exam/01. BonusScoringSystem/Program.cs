using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BonusScorSys
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            double lectureCount = double.Parse(Console.ReadLine());
            double initialScore = double.Parse(Console.ReadLine());

            List<double> attendance = new List<double>(studentCount);

            for (int i = 0; i < studentCount; i++)
            {
                attendance.Add(double.Parse(Console.ReadLine()));
            }

            double max = 0;
            decimal maxBonusPoints = 0m;

            if (attendance.Count != 0)
            {
                max = attendance.Max();

                decimal result = (decimal)(max / lectureCount) * (decimal)(5 + initialScore);

                maxBonusPoints = Math.Ceiling(result);

                Console.WriteLine($"Max Bonus: {maxBonusPoints}.");
                Console.WriteLine($"The student has attended {max} lectures.");
            }
            else
            {
                Console.WriteLine($"Max Bonus: {maxBonusPoints}.");
                Console.WriteLine($"The student has attended {max} lectures.");
            }
        }
    }
}
