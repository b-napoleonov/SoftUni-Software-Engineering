using System;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string vehicle = input[1];
                double amount = double.Parse(input[2]);

                if (command == "Drive")
                {
                    try
                    {

                        if (vehicle == "Car")
                        {
                            car.Drive(amount);
                        }
                        else
                        {
                            truck.Drive(amount);
                        }

                        Console.WriteLine($"{vehicle} travelled {amount} km");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
