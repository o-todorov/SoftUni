namespace Raiding
{
    class Rogue : BaseHero
    {
        private const int power = 80;
        public Rogue(string name) : base(name)
        {
            Power = power;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
