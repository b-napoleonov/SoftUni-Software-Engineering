using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == nameof(Meat))
            {
                double gainWeight = food.Quantity * 1.00;
                Weight += gainWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound() 
            => "ROAR!!!";
    }
}
