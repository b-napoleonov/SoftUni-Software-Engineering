using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                Car current = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(current);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                cars.First(c => c.Model == command[1]).Drive(double.Parse(command[2]));
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
