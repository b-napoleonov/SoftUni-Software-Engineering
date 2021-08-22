using System;
using System.Linq;

namespace _02._ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command.Split(' ')[0] == "swap")
                {
                    int index1 = int.Parse(command.Split(' ')[1]);
                    int index2 = int.Parse(command.Split(' ')[2]);

                    int buffer = arr[index1];
                    arr[index1] = arr[index2];
                    arr[index2] = buffer;
                }
                else if (command.Split(' ')[0] == "multiply")
                {
                    int index1 = int.Parse(command.Split(' ')[1]);
                    int index2 = int.Parse(command.Split(' ')[2]);

                    arr[index1] *= arr[index2];
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i]--;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
