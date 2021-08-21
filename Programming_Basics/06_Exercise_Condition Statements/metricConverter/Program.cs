using System;

namespace metricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            double inputNumberInCM = number;

            if (inputUnit == "mm")
            {
                inputNumberInCM = number / 10;
            }
            else if (inputUnit == "m")
            {
                inputNumberInCM = number * 100;
            }

            double outputNumber = inputNumberInCM;

            if (outputUnit == "mm")
            {
                outputNumber = inputNumberInCM * 10;
            }
            else if (outputUnit == "m")
            {
                outputNumber = inputNumberInCM / 100;
            }
            Console.WriteLine($"{outputNumber:F3}");
        }
    }
}
