using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            double gainWeight = food.Quantity * 0.35;
            Weight += gainWeight;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound() 
            => "Cluck";
    }
}
