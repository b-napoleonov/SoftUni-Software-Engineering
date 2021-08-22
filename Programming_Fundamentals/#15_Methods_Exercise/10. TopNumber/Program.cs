using System;
using System.Linq;

namespace _10._TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            for (int i = 8; i < int.Parse(number); i++)
            {
                if (Sum(i.ToString()) % 8 == 0 && OddDigit(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static int Sum(string number)
        {
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += int.Parse(number[i].ToString());
            }

            return sum;
        }

        static bool OddDigit(string number)
        {
            bool isOdd = false;

            for (int i = 0; i < number.Length; i++)
            {
                if (int.Parse(number[i].ToString()) % 2 == 1)
                {
                    isOdd = true;
                    break;
                }
            }
            return isOdd;
        }
    }
}
