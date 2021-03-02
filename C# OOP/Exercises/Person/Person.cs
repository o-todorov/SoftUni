
namespace Person
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age  = age;
        }

        public string Name { get; set; }
        public virtual int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }


}
