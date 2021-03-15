namespace WildFarm
{
    class Cat:Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            weightIncrement = 0.30;
            foodAcceptable = new string[] { "Vegetable", "Meat" };
        }

        public override string Ask()
        {
            return "Meow";
        }
    }
}
