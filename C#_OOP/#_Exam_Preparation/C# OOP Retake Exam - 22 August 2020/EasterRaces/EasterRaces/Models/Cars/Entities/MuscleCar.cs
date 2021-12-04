namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        protected const double cubicCentimeters = 5000;
        protected const int minHorsePower = 400;
        protected const int maxHorsePower = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
