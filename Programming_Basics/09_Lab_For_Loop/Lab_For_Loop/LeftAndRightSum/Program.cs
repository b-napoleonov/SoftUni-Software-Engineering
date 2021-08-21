using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int leftSum = 0;
            int rightSum = 0;
            int counter = 0;

            for (int i = 1; i <= number * 2; i++)
            {
                int num = int.Parse(Console.ReadLine());
                counter++;
                if (counter <= number)
                {
                    leftSum += num;
                }
                else if (counter > number)
                {
                    rightSum += num;
                }
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
