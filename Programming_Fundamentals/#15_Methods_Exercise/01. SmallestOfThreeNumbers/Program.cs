using System;
using System.Linq;

namespace _01._SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int firstNumber = int.Parse(Console.ReadLine());
            //int secondNumber = int.Parse(Console.ReadLine());
            //int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNumber());
        }

        static int SmallestNumber ()
        {
            //if (num1 < num2 && num1 < num3)
            //{
            //    return num1;
            //}
            //else if (num2 < num1 && num2 < num3)
            //{
            //    return num2;
            //}
            //else
            //{
            //    return num3;
            //}

            int[] arr = new int[3];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            return arr.Min();
        }
    }
}
