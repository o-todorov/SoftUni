using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer :Private, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary)
    : base(id, firstName, lastName, salary)
        {
            Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get => repairs; set => repairs = value; }
        public Corps Corps { get; set; }

        public void AddRepair(string partName, int hours)
        {
            repairs.Add(new Repair(partName, hours));
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps.ToString()}");
            sb.Append($"Repairs:{((Repairs.Count > 0) ? Environment.NewLine : "")}");
            sb.Append(string.Join(Environment.NewLine, Repairs));

            return sb.ToString();
        }
    }
}
