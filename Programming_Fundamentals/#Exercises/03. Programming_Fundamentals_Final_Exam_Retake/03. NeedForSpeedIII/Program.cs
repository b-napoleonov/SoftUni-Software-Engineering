using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._NFSIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split("|");

                string carName = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                if (!dict.ContainsKey(carName))
                {
                    dict.Add(carName, new List<int>());
                    dict[carName].Add(mileage);
                    dict[carName].Add(fuel);
                }
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] commands = input.Split(" : ");

                string command = commands[0];
                string car = commands[1];

                switch (command)
                {
                    case "Drive":

                        int distance = int.Parse(commands[2]);
                        int fuelNeeded = int.Parse(commands[3]);

                        if (dict[car][1] < fuelNeeded)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            dict[car][0] += distance;
                            dict[car][1] -= fuelNeeded;

                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        }

                        if (dict[car][0] >= 100000)
                        {
                            dict.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }

                        break;

                    case "Refuel":

                        int fuel = int.Parse(commands[2]);
                        int usedFuel = 0;

                        if (dict[car][1] + fuel <= 75)
                        {
                            dict[car][1] += fuel;
                            usedFuel = fuel;
                        }
                        else
                        {
                            usedFuel = 75 - dict[car][1];
                            dict[car][1] = 75;
                        }

                        Console.WriteLine($"{car} refueled with {usedFuel} liters");

                        break;

                    case "Revert":

                        int kilometers = int.Parse(commands[2]);

                        if (dict[car][0] - kilometers >= 10000)
                        {
                            dict[car][0] -= kilometers;

                            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        }
                        else
                        {
                            dict[car][0] = 10000;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var (key, value) in dict.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{key} -> Mileage: {value[0]} kms, Fuel in the tank: {value[1]} lt.");
            }
        }
    }
}
