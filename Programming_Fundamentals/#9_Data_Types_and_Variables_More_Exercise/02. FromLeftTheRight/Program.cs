using System;

namespace _02._FromLeftTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();

            string firstNumAsString = string.Empty;
            string secondNumAsString = string.Empty;
            bool isFirstNum = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (isFirstNum && numbers[i] != ' ')
                {
                    firstNumAsString += numbers[i];
                }
                else if (!isFirstNum && numbers[i] != ' ')
                {
                    secondNumAsString += numbers[i];
                }
                else if (numbers[i] == ' ')
                {
                    isFirstNum = false;
                }
            }

            int firstNumber = int.Parse(firstNumAsString);
            int secondNumber = int.Parse(secondNumAsString);
        }
    }
}
