using System;

namespace _01._DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string input = Console.ReadLine();

            switch (command)
            {
                case "int":
                    int intResult = IntDataType(input);
                    Console.WriteLine(intResult);
                    break;
                case "real":
                    string realResult = RealDataType(input);
                    Console.WriteLine(realResult);
                    break;
                case "string":
                    string strResult = StrDataType(input);
                    Console.WriteLine(strResult);
                    break;
            }
        }

        static int IntDataType(string input)
        {
            int number = int.Parse(input);
            return number * 2;
        }
        static string RealDataType(string input)
        {
            double number = double.Parse(input);
            return $"{number * 1.5:f2}";
        }
        static string StrDataType(string input)
        {
            return $"${input}$";
        }
    }
}
