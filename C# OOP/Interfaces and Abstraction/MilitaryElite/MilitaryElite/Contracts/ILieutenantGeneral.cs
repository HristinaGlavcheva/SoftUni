using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        //public IReadOnlyDictionary<int, IPrivate> Privates { get; }

        public IReadOnlyCollection<IPrivate> Privates { get; }

        public void AddPrivate(IPrivate @private);
    }
}
