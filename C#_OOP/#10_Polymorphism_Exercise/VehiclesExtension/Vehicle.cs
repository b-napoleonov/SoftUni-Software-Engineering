using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuel;
        public Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; }
        public double Fuel
        {
            get => fuel;

            private set
            {
                if (value > TankCapacity)
                {
                    fuel = 0;
                }
                else
                {

                    fuel = value;
                }
            }
        }

        public virtual double FuelConsumption { get; }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            Fuel += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = Fuel - FuelConsumption * distance >= 0;

            if (!canDrive)
            {
                return false;
            }

            Fuel -= FuelConsumption * distance;
            return true;
        }
    }
}
