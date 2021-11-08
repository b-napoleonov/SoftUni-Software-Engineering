namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public virtual string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
