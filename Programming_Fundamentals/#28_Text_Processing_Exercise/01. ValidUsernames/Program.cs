using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01._ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Where(x => x.Length >= 3)
                 .Where(x => x.Length <= 16)
                 .ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                bool isValid = true;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    char current = arr[i][j];
                    if (!char.IsLetterOrDigit(current))
                    {
                        if (current == '-' || current == '_')
                        {
                            continue;
                        }
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}
