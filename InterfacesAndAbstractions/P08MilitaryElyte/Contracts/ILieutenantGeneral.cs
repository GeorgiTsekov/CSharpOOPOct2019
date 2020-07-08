
namespace P08MilitaryElyte.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}
