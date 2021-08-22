using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Addition(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Substraction(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiplication(firstNumber, secondNumber);
                    break;
                case "divide":
                    Division(firstNumber, secondNumber);
                    break;
            }
        }
        static void Addition(int numberOne, int numberTwo)
        {
            int result = numberOne + numberTwo;
            Console.WriteLine(result);
        }

        static void Substraction(int numberOne, int numberTwo)
        {
            int result = numberOne - numberTwo;
            Console.WriteLine(result);
        }
        
        static void Multiplication(int numberOne, int numberTwo)
        {
            int result = numberOne * numberTwo;
            Console.WriteLine(result);
        }

        static void Division(int numberOne, int numberTwo)
        {
            int result = numberOne / numberTwo;
            Console.WriteLine(result);
        }
    }
}
