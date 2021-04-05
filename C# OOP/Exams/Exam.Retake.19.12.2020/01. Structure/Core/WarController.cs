using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;
		public WarController()
		{
			party	= new List<Character>();
			pool	= new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string type = args[0];
			string name = args[1];

			if (type == nameof(Warrior))
			{
				party.Add(new Warrior(name));
			}
			else if (type == nameof(Priest))
			{
				party.Add(new Priest(name));
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string type = args[0];

			if (type == nameof(FirePotion))
			{
				pool.Add(new FirePotion());
			}
			else if (type == nameof(HealthPotion))
			{
				pool.Add(new HealthPotion());
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, type));
			}

			return $"{type} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string name		= args[0];
			var character	= GetCharacter(name);

			Item item = pool.LastOrDefault();

            if (item == null)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			character.Bag.AddItem(item);
			pool.Remove(item);

			return $"{character.Name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string	name			= args[0];
			string	itemName		= args[1];
			var		character		= GetCharacter(name);

			var item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			var ret = party.OrderByDescending(c => c.IsAlive)
							.ThenByDescending(c => c.Health);

			return string.Join(Environment.NewLine, ret);
		}

		public string Attack(string[] args)
		{
			var attacker = GetCharacter(args[0]);
			var receiver = GetCharacter(args[1]);

            if (attacker.GetType() != typeof(Warrior)){
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			}

			(attacker as Warrior).Attack(receiver);

			var ret = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
				ret += (Environment.NewLine + $"{ receiver.Name} is dead!");
			}

			return ret;
		}

        private Character GetCharacter(string name)
        {
			var character = party.FirstOrDefault(c => c.Name == name);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
			}

			return character;
		}

		public string Heal(string[] args)
		{
			var healer		= GetCharacter(args[0]);
			var receiver	= GetCharacter(args[1]);

			if (healer.GetType() != typeof(Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			(healer as Priest).Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
