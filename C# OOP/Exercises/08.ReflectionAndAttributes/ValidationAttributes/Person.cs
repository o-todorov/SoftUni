using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get => fullName; set => fullName = value; }

        [MyRange(12, 90)]
        public int Age { get => age; set => age = value; }

    }
}
