using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine currentEngine = new Engine(speed, power);
                Cargo currentCargo = new Cargo(cargoType, weight);
                Tire[] currentTires = new Tire[4];

                currentTires[0] = new Tire(tire1Pressure, tire1Age);
                currentTires[1] = new Tire(tire2Pressure, tire2Age);
                currentTires[2] = new Tire(tire3Pressure, tire3Age);
                currentTires[3] = new Tire(tire4Pressure, tire4Age);

                Car current = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(current);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, 
                    cars.FindAll(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))));
            }
            else if (command == "flammable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, 
                    cars.FindAll(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)));
            }
        }
    }
}
