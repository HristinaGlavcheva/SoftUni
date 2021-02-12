using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string Codename { get; }

        State State { get; }

        void CompleteMission();
    }
}

