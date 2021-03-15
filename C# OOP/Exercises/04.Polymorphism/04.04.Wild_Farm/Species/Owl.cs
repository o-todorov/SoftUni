namespace WildFarm
{
    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            weightIncrement = 0.25;
            foodAcceptable = new string[] { "Meat" };
        }

        public override string Ask()
        {
            return "Hoot Hoot";
        }
    }
}
