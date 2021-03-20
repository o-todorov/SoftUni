namespace MilitaryElite
{
    public abstract class Soldier:ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            Id        = id;
            FirstName = firstName;
            LastName  = lastName;
        }

        public virtual string Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

    }
}
