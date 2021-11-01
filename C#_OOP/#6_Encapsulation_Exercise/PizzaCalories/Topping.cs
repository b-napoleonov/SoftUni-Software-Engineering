using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;
        private const double ModifierPerGram = 2;

        private string type;
        private int weight;
        private double caloriesPerGram;

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public double CaloriesPerGram
        {
            get => caloriesPerGram;

            private set
            {
                caloriesPerGram = value;
            }
        }


        public int Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }


        public string Type
        {
            get => type;

            private set
            {
                if (string.Compare(value, "Meat", StringComparison.OrdinalIgnoreCase) == 0 || 
                    string.Compare(value, "Veggies", StringComparison.OrdinalIgnoreCase) == 0 || 
                    string.Compare(value, "Cheese", StringComparison.OrdinalIgnoreCase) == 0 || 
                    string.Compare(value, "Sauce", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

            }
        }

        public void CalcCalories()
        {
            double modifier = 0;

            switch (Type.ToLower())
            {
                case "meat":

                    modifier = MeatModifier;
                    break;

                case "veggies":

                    modifier = VeggiesModifier;
                    break;

                case "cheese":

                    modifier = CheeseModifier;
                    break;

                case "sauce":

                    modifier = SauceModifier;
                    break;
            }

            CaloriesPerGram = ModifierPerGram * Weight * modifier;
        }
    }
}
