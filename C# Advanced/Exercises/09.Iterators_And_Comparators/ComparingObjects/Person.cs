using System;

namespace ComparingObjects
{
    class Person: IComparable
    {
        public Person(string name, int age, string town)
        {
            Name    = name;
            Age     = age;
            Town    = town;
        }

        public string  Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }


        public int CompareTo(object obj)
        {
            Person other = obj as Person;
            int result;
            return (result = Name.CompareTo(other.Name)) != 0 ? result :
                   (result = Age.CompareTo(other.Age)) != 0 ? result :
                             Town.CompareTo(other.Town);
        }
        //public override string ToString()
        //{
        //    return $"{Name} - {Age} - {Town}";
        //}
    }
}
