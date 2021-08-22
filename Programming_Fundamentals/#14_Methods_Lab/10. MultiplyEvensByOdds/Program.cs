using System;

namespace _10._MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMultipleOfEvenAndOdds(number));
        }

        static string GetMultipleOfEvenAndOdds(int number)
        {
            string num = Math.Abs(number).ToString();
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] % 2 == 0)
                {
                    evenSum += int.Parse(num[i].ToString());
                }
                else
                {
                    oddSum += int.Parse(num[i].ToString());
                }
            }

            return $"{evenSum * oddSum}";
        }
    }
}
