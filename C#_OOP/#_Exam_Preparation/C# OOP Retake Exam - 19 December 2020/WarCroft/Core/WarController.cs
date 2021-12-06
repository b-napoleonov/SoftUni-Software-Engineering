using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private Stack<Item> items;

		public WarController()
		{
			characters = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType)),
            };
            characters.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = itemName switch
			{
				"HealthPotion" => new HealthPotion(),
				"FirePotion" => new FirePotion(),
				_ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName)),
			};

			items.Push(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = items.Pop();
			character.Bag.AddItem(item);
			return string.Join(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string defenderName = args[1];

			Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);
			Character defender = characters.FirstOrDefault(x => x.Name == defenderName);

			if (attacker == null || defender == null)
			{
				string name = attackerName;
				if (attacker != null)
				{
					name = defenderName;
				}

				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
			}

			if (attacker is IHealer)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			}

			(attacker as IAttacker).Attack(defender);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
				attacker.Name,
				defender.Name,
				attacker.AbilityPoints,
				defender.Name,
				defender.Health,
				defender.BaseHealth,
				defender.Armor,
				defender.BaseArmor));

			if (defender.IsAlive == false)
			{
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, defender.Name));
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingName = args[1];

			Character healer = characters.FirstOrDefault(x => x.Name == healerName);
			Character healing = characters.FirstOrDefault(x => x.Name == healingName);

			if (healer == null || healing == null)
			{
				string name = healerName;
				if (healer != null)
				{
					name = healingName;
				}
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
			}

			if (healer is IAttacker)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			(healer as IHealer).Heal(healing);

			return string.Format(SuccessMessages.HealCharacter,
				healer.Name,
				healing.Name,
				healer.AbilityPoints,
				healing.Name,
				healing.Health);
		}
	}
}
