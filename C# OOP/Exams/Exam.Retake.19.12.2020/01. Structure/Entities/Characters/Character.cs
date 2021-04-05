using System;

using WarCroft.Constants;
using WarCroft.Core;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private float health;
        private float armor;
        public Character(string name, float health, float armor, float abilityPoints, Bag bag)
        {
            Name            = name;
            Health          = health;
            BaseHealth      = health;
            Armor           = armor;
            BaseArmor       = armor;
            AbilityPoints   = abilityPoints;
            Bag             = bag;
        }
        public string Name
        {
            get => name;
            private set => name = Validators.ValidateIsNotNullOrWhiteSpace(value, ExceptionMessages.CharacterNameInvalid);
        }

        public float BaseHealth { get; }
        public float Health
        {
            get => health;

            set
            {
                health = Math.Min(value, BaseHealth);
                health = Math.Max(value, 0.0f);

                if (health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }
        public float BaseArmor { get; }
        public float Armor
        {
            get => armor;

            private set
            {
                armor = Math.Max(value, 0.0f);
            }
        }
        public float AbilityPoints { get; }
        public IBag Bag { get; }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
        public void TakeDamage(float hitPoints)
        {
            EnsureAlive();

            Health  -= Math.Max(hitPoints - Armor, 0.0f);
            Armor   -= hitPoints;
        }
        public void UseItem(Item item) 
        {
            item.AffectCharacter(this);

        }
        public override string ToString()
        {
            string stat = IsAlive ? "Alive" : "Dead";

            return $"{name} - HP: {health}/{BaseHealth}, AP: {armor}/{BaseArmor}, Status: {stat}";
        }
    }
}