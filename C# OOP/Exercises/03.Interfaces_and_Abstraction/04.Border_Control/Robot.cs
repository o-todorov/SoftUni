
namespace _04.Border_Control
{
    public class Robot : IUnit
    {
        public Robot(string model, string id)
        {
            Model   = model;
            Id      = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }
}
