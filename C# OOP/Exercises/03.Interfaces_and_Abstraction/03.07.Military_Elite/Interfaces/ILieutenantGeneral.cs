using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
         List<ISoldier> Privates { get; set; }
        void AddPrivate(ISoldier @private);
    }
}
