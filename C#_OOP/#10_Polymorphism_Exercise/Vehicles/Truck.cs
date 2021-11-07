namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double truckAirConditioner = 1.6;
        public Truck(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption, truckAirConditioner)
        {
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}
