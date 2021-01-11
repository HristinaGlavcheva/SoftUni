using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State state { get; }

        void CompleteMission();
    }
}
