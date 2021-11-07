using System;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double truckAirConditioner = 1.6;
        public Truck(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + truckAirConditioner;
        public override void Refuel(double amount)
        {
            if (Fuel + amount > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            base.Refuel(amount * 0.95);
        }
    }
}
