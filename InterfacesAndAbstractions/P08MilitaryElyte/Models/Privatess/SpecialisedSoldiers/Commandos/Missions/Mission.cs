
namespace P08MilitaryElyte.Models.Privatess.SpecialisedSoldiers.Commandos.Missions
{
    using System;
    using P08MilitaryElyte.Contracts;
    using P08MilitaryElyte.Enumerations;
    using Exceptions;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleateMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            this.State = State.Finished;
        }

        private void ParseState(string stateStr)
        {
            State state;

            bool parse = Enum.TryParse(stateStr, out state);

            if (!parse)
            {
                throw new InvalidStateException();
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
