using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando:ISpecialisedSoldier
    {
        Dictionary <string, Mission> Missions { get; set; }
        void CompleteMission(string missionCodeName);
        void AddMission(string codeName, string state);
    }
}
