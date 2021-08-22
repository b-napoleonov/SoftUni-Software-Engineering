using System;

namespace _06._CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine(RectangleArea(width, height));
        }

        static string RectangleArea(int width, int height)
        {
            return $"{width * height}";
        }
    }
}
