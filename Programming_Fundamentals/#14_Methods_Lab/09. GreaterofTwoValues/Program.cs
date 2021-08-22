using System;

namespace _09._GreaterofTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var firstValue = Console.ReadLine();
            var secondValue = Console.ReadLine();

            Console.WriteLine(GetMax(type, firstValue, secondValue));
        }
        
        static string GetMax(string type, string firstValue, string secondValue)
        {
            var firstResult = 0;
            var secondResult = 0;

            if (type == "int")
            {
                firstResult = int.Parse(firstValue);
                secondResult = int.Parse(secondValue);
            }
            else if (type == "char")
            {
                firstResult = char.Parse(firstValue);
                secondResult = char.Parse(secondValue);
            }
            else if (type == "string")
            {
                int comparison = firstValue.CompareTo(secondValue);

                if (comparison > 0)
                {
                    return firstValue;
                }
                else
                {
                    return secondValue;
                }
            }
            if (firstResult > secondResult)
            {
                return firstValue;
            }
            else
            {
                return secondValue;
            }
        }
    }
}
