using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);

        //IReadOnlyDictionary<int, IPrivate> Privates { get; }
    }
}
