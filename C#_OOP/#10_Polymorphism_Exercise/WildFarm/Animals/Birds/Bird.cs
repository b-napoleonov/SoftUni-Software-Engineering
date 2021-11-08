namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public virtual double WingSize { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
