using System;

namespace _05._07.CustomException
{
    class InvalidPersonNameException:Exception
    {
        public InvalidPersonNameException()
        {

        }
        public InvalidPersonNameException(string name)
            :base(string.Format("Invalid Student Name: {0}", name))
        {
        }
    }
}
