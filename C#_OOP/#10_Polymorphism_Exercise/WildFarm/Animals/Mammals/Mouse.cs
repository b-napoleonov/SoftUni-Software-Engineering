using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == nameof(Vegetable) || food.GetType().Name == nameof(Fruit))
            {
                double gainWeight = food.Quantity * 0.10;
                Weight += gainWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound() 
            => "Squeak";
    }
}
