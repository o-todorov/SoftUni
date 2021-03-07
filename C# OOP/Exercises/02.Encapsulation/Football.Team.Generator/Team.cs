using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Team.Generator
{
    class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.name    = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set => name = Validators.StringNotNullEmptyOrWhitespace(value, "A name should not be empty.");
        }

        public int Rating => players.Count == 0 ? 0 : (int)Math.Round(players.Average(p => p.Status.Average(s => s.Value)));
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            var player = Validators.ValidateNotNull(players.FirstOrDefault(p => p.Name.Equals(playerName)),
                                                    $"Player {playerName} is not in {Name} team.");
            players.Remove(player);
        }
    }
}
