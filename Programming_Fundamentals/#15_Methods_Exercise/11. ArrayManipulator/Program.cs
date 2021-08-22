using System;
using System.Linq;

namespace _11._ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string command = input.Split(' ')[0];

                if (command == "exchange")
                {
                    int index = int.Parse(input.Split(' ')[1]);

                    ArraySplit(arr, index);
                }

                else if (command == "max")
                {
                    string secondCommand = input.Split(' ')[1];

                    int index = GetMaxElement(arr, secondCommand);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }

                else if (command == "min")
                {
                    string secondCommand = input.Split(' ')[1];

                    int index = GetMinElement(arr, secondCommand);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }

                else if (command == "first")
                {
                    int count = int.Parse(input.Split(' ')[1]);
                    string secondCommand = input.Split(' ')[2];

                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        input = Console.ReadLine();
                        continue;
                    }

                    int[] firstElement = GetFirst(arr, count, secondCommand);

                    Console.Write("[");

                    bool found = false;

                    foreach (int element in firstElement)
                    {
                        if (element != -1)
                        {
                            if (found)
                            {
                                Console.Write($", {element}");
                            }
                            else
                            {
                                Console.Write($"{element}");
                                found = true;
                            }
                        }
                    }

                    Console.WriteLine("]");
                }

                else if (command == "last")
                {
                    int count = int.Parse(input.Split(' ')[1]);
                    string secondCommand = input.Split(' ')[2];

                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        input = Console.ReadLine();
                        continue;
                    }

                    int[] lastElement = GetLast(arr, count, secondCommand);

                    Console.Write("[");

                    bool found = false;

                    foreach (int element in lastElement)
                    {
                        if (element != -1)
                        {
                            if (found)
                            {
                                Console.Write($", {element}");
                            }
                            else
                            {
                                Console.Write($"{element}");
                                found = true;
                            }
                        }
                    }

                    Console.WriteLine("]");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static int[] GetLast(int[] arr, int count, string secondCommand)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            int ind = 0;
            int parity = Parity(secondCommand);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int number = arr[i];

                if (number % 2 == parity)
                {
                    result[ind] = number;
                    ind++;

                    if (ind >= result.Length)
                    {
                        break;
                    }
                }
            }
            return result.Reverse().ToArray();
        }

        private static int Parity(string secondCommand)
        {
            int parity = 1;

            if (secondCommand == "even")
            {
                parity = 0;
            }

            return parity;
        }

        private static int[] GetFirst(int[] arr, int count, string secondCommand)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            int ind = 0;
            int parity = Parity(secondCommand);

            foreach (int number in arr)
            {
                if (number % 2 == parity)
                {
                    result[ind] = number;
                    ind++;

                    if (ind >= result.Length)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        private static int GetMinElement(int[] arr, string secondCommand)
        {
            int parity = Parity(secondCommand);

            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];

                if (currentNumber <= min &&
                    currentNumber % 2 == parity)
                {
                    min = currentNumber;
                    index = i;
                }
            }

            return index;
        }

        private static int GetMaxElement(int[] arr, string secondCommand)
        {
            int parity = Parity(secondCommand);

            int max = int.MinValue;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];

                if (currentNumber >= max &&
                    currentNumber % 2 == parity)
                {
                    max = currentNumber;
                    index = i;
                }
            }

            return index;
        }

        private static void ArraySplit(int[] arr, int rotations)
        {
            if (rotations < 0 || rotations >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= rotations; i++)
            {
                int firstElement = arr[0];

                for (int j = 1; j < arr.Length; j++)
                {
                    arr[j - 1] = arr[j];
                }
                arr[arr.Length - 1] = firstElement;
            }
        }
    }
}
