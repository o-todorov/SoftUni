namespace WildFarm
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            weightIncrement = 0.10;
            foodAcceptable = new string[] { "Vegetable", "Fruit"};
        }

        public override string Ask()
        {
            return "Squeak";
        }
    }
}
