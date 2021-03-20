using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando :Private, ICommando
    {
        private Dictionary<string, Mission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName, salary)
        {
            Missions = new Dictionary<string, Mission>();
        }
        public Dictionary<string, Mission> Missions { get => missions; set => missions = value; }
        public Corps Corps { get; set; }
        public void AddMission(string codeName, string state)
        {
            try
            {
                Missions.Add(codeName, new Mission(codeName, Enums.EnumParse<MissionState>(state)));
            }
            catch (Exception)
            {
                return;
            }
        }
        public void CompleteMission(string missionCodeName)
        {
            Missions[missionCodeName].State = MissionState.Finished;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps.ToString()}");
            sb.Append($"Missions:{((Missions.Count>0)?Environment.NewLine:"")}");
            sb.Append(string.Join(Environment.NewLine, Missions.Values));

            return sb.ToString();
        }
    }
}
