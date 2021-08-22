using System;
using System.Linq;

namespace _02._CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] arr2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < arr2.Length; i++)
            {
                foreach (string item in arr)
                {
                    if (arr2[i] == item)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }
    }
}
