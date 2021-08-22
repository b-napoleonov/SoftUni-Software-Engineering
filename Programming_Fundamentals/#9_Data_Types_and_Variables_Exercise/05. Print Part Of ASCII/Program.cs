using System;

namespace _05._Print_Part_Of_ASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish= int.Parse(Console.ReadLine());

            for (int i = start; i <= finish; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
