using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                circle.Enqueue(Console.ReadLine());
            }
        }
    }
}
