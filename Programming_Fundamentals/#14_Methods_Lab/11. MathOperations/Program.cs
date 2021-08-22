using System;

namespace _11._MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine(MathOperations(number1, @operator, number2));
        }

        static int MathOperations(int num, char symbol, int num2)
        {
            int result = 0;
            switch (symbol)
            {
                case '+':
                    result = num + num2;
                    break;
                case '-':
                    result = num - num2;
                    break;
                case '*':
                    result = num * num2;
                    break;
                case '/':
                    result = num / num2;
                    break;
            }

            return result;
        }
    }
}
