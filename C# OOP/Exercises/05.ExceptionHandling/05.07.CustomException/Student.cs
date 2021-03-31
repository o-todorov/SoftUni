using System;
using System.Linq;

namespace _05._07.CustomException
{
    class Student
    {
        private string name;

        public Student(string name, string email)
        {
            Name    = name;
            Email   = email;
        }

        public string Name { get => name; set => name = Validator(value); }

        private string Validator(string value)
        {
            if (value.Any(ch => !Char.IsLetter(ch)))
            {
                throw new InvalidPersonNameException(value);
            }

            return value;
        }

        public string Email { get; set; }
    }
}
