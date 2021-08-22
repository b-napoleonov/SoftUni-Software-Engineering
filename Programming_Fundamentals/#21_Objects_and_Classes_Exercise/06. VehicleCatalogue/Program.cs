using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (input != "End")
            {
                string[] vehicleType = input.Split(' ');

                string type = vehicleType[0];
                string model = vehicleType[1];
                string color = vehicleType[2];
                int horsePower = int.Parse(vehicleType[3]);

                if (type == "car")
                {
                    Car currentCar = new Car(type, model, color, horsePower);

                    cars.Add(currentCar);
                }
                else if (type == "truck")
                {
                    Truck currentTruck = new Truck(type, model, color, horsePower);

                    trucks.Add(currentTruck);
                }

                input = Console.ReadLine();
            }

            string typeOfVehicle = Console.ReadLine();

            while (typeOfVehicle != "Close the Catalogue")
            {
                if (cars.Select(x => x.Model).Contains(typeOfVehicle))
                {
                    int index = cars.FindIndex(x => x.Model == typeOfVehicle);

                    Console.WriteLine(cars[index]);
                }
                else if (trucks.Select(x => x.Model).Contains(typeOfVehicle))
                {
                    int index = trucks.FindIndex(x => x.Model == typeOfVehicle);

                    Console.WriteLine(trucks[index]);
                }

                typeOfVehicle = Console.ReadLine();
            }

            double carsHorsePower = cars.Select(x => x.HorsePower).Sum() / (double)cars.Count();
            double trucksHorsePower = trucks.Select(x => x.HorsePower).Sum() / (double)trucks.Count();

            Console.WriteLine($"Cars have average horsepower of: {carsHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHorsePower:F2}.");
        }
    }

    public class Car
    {
        public Car(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        => $"Type: Car{Environment.NewLine}" + $"Model: {Model}{Environment.NewLine}" + $"Color: {Color}{Environment.NewLine}" + $"Horsepower: {HorsePower}";

    }

    public class Truck
    {
        public Truck(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public override string ToString()
        => $"Type: Truck{Environment.NewLine}" + $"Model: {Model}{Environment.NewLine}" + $"Color: {Color}{Environment.NewLine}" + $"Horsepower: {HorsePower}";
    }
}
