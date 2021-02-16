using System;

using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codename, string state)
        {
            this.Codename = codename;
            this.State = this.TryParse(state);
        }

        public string Codename { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        private State TryParse(string stateStr)
        {
            bool isParsed = Enum.TryParse<State>(stateStr, false, out State state);

            if (!isParsed)
            {
                throw new InvalidMissionException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Codename} State: {this.State}";
        }
    }
}

