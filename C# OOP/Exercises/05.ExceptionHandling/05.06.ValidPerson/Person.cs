using System;

namespace _05._06.ValidPerson
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get => firstName; set => firstName = ValidateName(value, "First Name"); }

        public string LastName { get => lastName; set => lastName = ValidateName(value, "Last Name"); }
        public int Age
        {
            get => age;

            set
            {
                if (value >= 0 && value <= 120)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                            "value",
                            "Age should be in range [0 - 120].");
                }
            }
        }

        private string ValidateName(string value, string argName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(
                    "value",
                    $"The {argName} cannot be null or empty.");
            }

            return value;
        }

    }
}
