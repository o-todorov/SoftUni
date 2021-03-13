
namespace PersonInfo
{
    public interface IPerson:IIdentifiable,IBirthable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
