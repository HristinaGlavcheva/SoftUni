using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);

        //IReadOnlyDictionary<int, IPrivate> Privates { get; }
    }
}
