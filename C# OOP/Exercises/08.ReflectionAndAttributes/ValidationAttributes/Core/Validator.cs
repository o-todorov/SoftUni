using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Core
{
    public class Validator
    {
        public static bool IsValid(Person person)
        {
            Type           personType = person.GetType();
            PropertyInfo[] properties = personType.GetProperties();

            foreach (var prop in properties)
            {
                var value       = prop.GetValue(person);
                var attributes  = prop.GetCustomAttributes()
                                 .Where(a => a.GetType().BaseType == typeof(MyValidationAttribute));

                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}