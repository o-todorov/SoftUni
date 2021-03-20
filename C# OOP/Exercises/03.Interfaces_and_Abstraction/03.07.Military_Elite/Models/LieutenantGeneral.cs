using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral :Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
                : base(id, firstName, lastName, salary)
        {
            Privates = new List<ISoldier>();
        }

        public List<ISoldier> Privates { get => privates; set => privates = value; }

        public void AddPrivate(ISoldier @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"Privates:");
            privates.ForEach(p => sb.Append($"{ Environment.NewLine}  {p}"));

            return sb.ToString();
        }

    }
}
