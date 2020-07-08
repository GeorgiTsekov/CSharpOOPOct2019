
namespace P08MilitaryElyte.Models.Privatess.SpecialisedSoldiers.Engineers.Repairs
{
    using P08MilitaryElyte.Contracts;

    public class Repair : IRepair
    {
        public Repair(string name, int houres)
        {
            this.Name = name;
            this.Houres = houres;
        }

        public string Name { get; private set; }

        public int Houres { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.Houres}";
        }
    }
}
