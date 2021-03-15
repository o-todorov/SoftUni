namespace Raiding
{
    class Warrior:BaseHero
    {
        private const int power = 100;
        public Warrior(string name) : base(name)
        {
            Power = power;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
