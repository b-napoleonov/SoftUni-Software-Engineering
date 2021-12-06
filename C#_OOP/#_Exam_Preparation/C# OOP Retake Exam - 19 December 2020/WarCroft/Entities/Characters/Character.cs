using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;

        // TODO: Implement the rest of the class.

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name 
		{
			get => name;
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
            } 
		}

        public double BaseHealth { get; }

        public double Health { get; set; }

        public double BaseArmor { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            Armor -= hitPoints;
            if (Armor < 0)
            {
                hitPoints = Math.Abs(Armor);
                Armor = 0;
                Health -= hitPoints;
            }

            CheckIsDead();
        }


        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        public void CheckIsDead()
        {
            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }
    }
}