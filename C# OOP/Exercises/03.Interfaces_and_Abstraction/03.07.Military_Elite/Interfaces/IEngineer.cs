using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer:ISpecialisedSoldier
    {
        List<Repair> Repairs { get; set; }
        void AddRepair(string partName, int hours);
    }
}
