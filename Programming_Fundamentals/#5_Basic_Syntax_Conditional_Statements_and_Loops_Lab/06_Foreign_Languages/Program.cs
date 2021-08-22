using System;

namespace _06_Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country_Name = Console.ReadLine();

            switch (country_Name)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":   
                case "Argentina":   
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
