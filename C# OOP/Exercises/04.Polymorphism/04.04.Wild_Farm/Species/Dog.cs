namespace WildFarm
{
    class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion)
           : base(name, weight, livingRegion)
        {
            weightIncrement = 0.40;
            foodAcceptable = new string[] { "Meat" };
        }

        public override string Ask()
        {
            return "Woof!";
        }
    }
}
