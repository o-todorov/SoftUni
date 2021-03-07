using System.Collections.Generic;

namespace Football.Team.Generator
{
    class Player
    {
        private Dictionary<string, int> status; 

        private string name;
        public Player(string name, int[] status)
        {
            Name = name;
            Status = new Dictionary<string, int>() {
            {"Endurance",status[0] },
            {"Sprint"   ,status[1] },
            {"Dribble"  ,status[2] },
            {"Passing"  ,status[3] },
            {"Shooting" ,status[4] }};
        }
        public string Name
        {
            get => name;
            set => name = Validators.StringNotNullEmptyOrWhitespace(value, "A name should not be empty.");
        }
        public Dictionary<string, int> Status 
        {
            get => status;

            private set
            {
                foreach (var stat in value)
                {
                    Validators.ValidateIsInRange(stat.Value, 0, 100, $"{stat.Key} should be between 0 and 100.");
                }

                status = value;
            } 
        }
    }
}
