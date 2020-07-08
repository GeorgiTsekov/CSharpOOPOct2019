
namespace P08MilitaryElyte.Models.Privatess.SpecialisedSoldiers
{
    using P08MilitaryElyte.Contracts;
    using P08MilitaryElyte.Enumerations;
    using P08MilitaryElyte.Exceptions;
    using P08MilitaryElyte.Models.Privatess;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $"Corps: {this.Corps}";
        }
    }
}
