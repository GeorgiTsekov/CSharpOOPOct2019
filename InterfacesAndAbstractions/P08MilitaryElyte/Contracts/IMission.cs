
using P08MilitaryElyte.Enumerations;

namespace P08MilitaryElyte.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleateMission();
    }
}
