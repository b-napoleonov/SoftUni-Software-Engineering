namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double carAirConditioner = 0.9;
        public Car(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + carAirConditioner;
    }
}
