namespace Raiding
{
    class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name):base(name)
        {
            Power = power;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
