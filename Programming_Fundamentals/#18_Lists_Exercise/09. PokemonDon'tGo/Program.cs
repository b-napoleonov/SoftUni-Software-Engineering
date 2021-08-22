using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int index = int.Parse(Console.ReadLine());
            int sum = 0;

            while (true)
            {
                if (index < 0)
                {
                    int current = inputList[0];
                    sum += current;

                    inputList[0] = inputList[inputList.Count - 1];

                    IncreaseDecreaseElements(inputList, current);
                }
                else if (index >= inputList.Count)
                {
                    int current = inputList[inputList.Count - 1];
                    sum += current;

                    inputList[inputList.Count - 1] = inputList[0];

                    IncreaseDecreaseElements(inputList, current);
                }
                else
                {
                    sum += inputList[index];

                    int currentNumber = inputList[index];

                    inputList.RemoveAt(index);

                    IncreaseDecreaseElements(inputList, currentNumber);
                }

                if (inputList.Count == 0)
                {
                    break;
                }

                index = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }

        private static void IncreaseDecreaseElements(List<int> inputList, int currentNumber)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] <= currentNumber)
                {
                    inputList[i] += currentNumber;
                }
                else if (inputList[i] > currentNumber)
                {
                    inputList[i] -= currentNumber;
                }
            }
        }
    }
}
