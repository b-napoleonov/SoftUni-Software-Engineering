using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            int index = input.IndexOf(toRemove);

            while (index >= 0)
            {
                input = input.Remove(index, toRemove.Length);
                index = input.IndexOf(toRemove);
            }

            Console.WriteLine(input);
        }
    }
}
