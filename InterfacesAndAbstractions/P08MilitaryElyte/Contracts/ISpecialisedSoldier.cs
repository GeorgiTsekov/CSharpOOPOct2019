
using P08MilitaryElyte.Enumerations;

namespace P08MilitaryElyte.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
