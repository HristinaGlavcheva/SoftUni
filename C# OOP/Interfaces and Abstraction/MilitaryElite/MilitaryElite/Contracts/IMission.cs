using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        public State State { get;}

        public void CompleteMission();
    }
}