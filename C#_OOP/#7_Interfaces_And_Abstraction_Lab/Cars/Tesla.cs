namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
            : base(model, color)
        {
            Battery = batteries;
        }
        public int Battery { get; private set; }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
