namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        protected const double cubicCentimeters = 3000;
        protected const int minHorsePower = 250;
        protected const int maxHorsePower = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
