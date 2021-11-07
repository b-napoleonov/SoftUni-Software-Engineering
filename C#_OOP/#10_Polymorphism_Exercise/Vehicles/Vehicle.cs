using System;

namespace Vehicles
{
    public class Vehicle
    {
        public Vehicle(double fuel, double fuelConsumption, double airConditioner)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            AirConditioner = airConditioner;
        }
        public double Fuel { get; private set; }
        public double FuelConsumption { get; private set; }
        private double AirConditioner { get; set; }

        public void Drive(double distance)
        {
            double fuelRequired = (FuelConsumption + AirConditioner) * distance;

            if (fuelRequired > Fuel)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            Fuel -= fuelRequired;
        }

        public virtual void Refuel(double amount)
        {
            Fuel += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:F2}";
        }
    }
}
