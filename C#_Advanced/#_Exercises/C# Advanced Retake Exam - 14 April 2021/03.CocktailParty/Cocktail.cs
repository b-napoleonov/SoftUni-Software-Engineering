using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => ingredients.Sum(a => a.Alcohol);

        public void Add(Ingredient ingredient)
        {
            bool isIngredient = false;

            foreach (Ingredient item in ingredients)
            {
                if (item.Name == ingredient.Name)
                {
                    isIngredient = true;
                }
            }

            if (!isIngredient && ingredients.Count < Capacity && CurrentAlcoholLevel <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            return ingredients.Remove(ingredients.FirstOrDefault(i => i.Name == name));
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
