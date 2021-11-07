using System;

namespace VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

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
                    if (vehicle == "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else if (vehicle == "Truck")
                    {
                        CanDrive(truck, amount);
                    }
                    else
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, amount);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
            Console.WriteLine($"Bus: {bus.Fuel:F2}");

        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            string result = canDrive ?
                $"{vehicleType} travelled {distance} km" :
                $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }
    }
}
