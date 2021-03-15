namespace Raiding
{
    class Paladin : BaseHero
    {
        private const int power = 100;
        public Paladin(string name) : base(name)
        {
            Power = power;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
