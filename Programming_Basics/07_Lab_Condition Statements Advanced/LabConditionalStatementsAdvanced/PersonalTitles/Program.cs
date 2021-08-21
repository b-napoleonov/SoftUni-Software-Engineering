using System;

namespace PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char sex = Console.ReadLine()[0];

            if (sex == 'f')
            {
                if (age < 16)
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    Console.WriteLine("Ms.");
                }
            }
            else if (sex == 'm')
            {
                if (age < 16)
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
