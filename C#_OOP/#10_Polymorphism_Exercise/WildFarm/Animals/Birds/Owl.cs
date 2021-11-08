using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == nameof(Meat))
            {
                double gainWeight = food.Quantity * 0.25;
                Weight += gainWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound() 
            => "Hoot Hoot";
    }
}
