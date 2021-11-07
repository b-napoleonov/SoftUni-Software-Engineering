namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double carAirConditioner = 0.9;
        public Car(double fuel, double fuelConsumption) 
            : base(fuel, fuelConsumption, carAirConditioner)
        {
        }
    }
}
