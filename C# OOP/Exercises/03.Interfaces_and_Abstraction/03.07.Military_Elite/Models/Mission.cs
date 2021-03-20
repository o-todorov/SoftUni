namespace MilitaryElite
{
    public class Mission
    {
        public string CodeName { get; set; }

        public Mission(string codeName, MissionState state)
        {
            CodeName = codeName;
            State    = state;
        }

        public MissionState State { get; set; }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
