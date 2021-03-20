using System.Text;

namespace MilitaryElite
{
    public class Spy:Soldier, ISpy
    {
        public int Code { get; set; }

        public Spy(string id, string firstName, string lastName, int code)
            :base(id,firstName,lastName)
        {
            Code = code;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            sb.Append($"Code Number: {Code}");

            return sb.ToString();
        }
    }
}
