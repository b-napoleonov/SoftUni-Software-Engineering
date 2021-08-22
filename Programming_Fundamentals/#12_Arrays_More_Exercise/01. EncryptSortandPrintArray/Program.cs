using System;
using System.Linq;

namespace _01._EncryptSortandPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            string[] names = new string[numberOfStrings];

            int[] sums = new int[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
            {
                names[i] = Console.ReadLine();
                string name = names[i];
                int sum = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    char bufferLetter = name[j];
                    string letter = name[j].ToString().ToLower();

                    switch (letter)
                    {
                        case "a":
                        case "e":
                        case "i":
                        case "o":
                        case "u":
                            sum += bufferLetter * name.Length;
                            break;
                        default:
                            sum += bufferLetter / name.Length;
                            break;
                    }
                }
                sums[i] = sum;
            }
            Array.Sort(sums);
            foreach (var element in sums)
            {
                Console.WriteLine($"{element} ");
            }
        }
    }
}
