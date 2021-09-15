namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double consumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = consumption;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; } = 0;

        public void Drive(double distance)
        {
            double consumedFuel = distance * FuelConsumptionPerKilometer;

            if (FuelAmount - consumedFuel >= 0)
            {
                FuelAmount -= consumedFuel;
                TravelledDistance += distance;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TravelledDistance}";
        }
    }
}
