namespace WildFarm
{
    class Hen : Bird
    {
        
        public Hen(string name, double weight, double wingSize)
           : base(name, weight, wingSize) 
        {
            weightIncrement = 0.35;
            foodAcceptable = new string[] { "Vegetable", "Fruit", "Meat", "Seeds" };
        }
        public override string Ask()
        {
            return "Cluck";
        }
    }
}
