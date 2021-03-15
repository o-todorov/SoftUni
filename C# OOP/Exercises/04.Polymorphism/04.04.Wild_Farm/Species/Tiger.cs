namespace WildFarm
{
    class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            weightIncrement = 1.00;
            foodAcceptable = new string[] { "Meat" };
        }

        public override string Ask()
        {
            return "ROAR!!!";
        }
    }
}
