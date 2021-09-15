using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (tokens.Length == 3 && char.IsDigit(tokens[2][0]))
                {
                    displacement = tokens[2];
                }
                else if (tokens.Length == 3)
                {
                    efficiency = tokens[2];
                }
                if (tokens.Length == 4)
                {
                    displacement = tokens[2];
                    efficiency = tokens[3];
                }

                Engine current = new Engine(model, power, displacement, efficiency);
                engines.Add(current);
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                string engineModel = tokens[1];
                string weight = "n/a";
                string color = "n/a";

                if (tokens.Length == 3 && char.IsDigit(tokens[2][0]))
                {
                    weight = tokens[2];
                }
                else if(tokens.Length == 3)
                {
                    color = tokens[2];
                }
                if (tokens.Length == 4)
                {
                    weight = tokens[2];
                    color = tokens[3];
                }

                Car current = new Car(model, engines.First(e => e.Model == engineModel), weight, color);
                cars.Add(current);
            }
            string buffer = "n/a";
            foreach (var car in cars)
            {
                Console.WriteLine($@"{car.Model}:
  {car.Engine.Model}:
    Power: {car.Engine.Power}
    Displacement: {car.Engine.Displacement}
    Efficiency: {car.Engine.Efficiency}
  Weight: {car.Weight}
  Color: {car.Color}");
            }
        }
    }
}
