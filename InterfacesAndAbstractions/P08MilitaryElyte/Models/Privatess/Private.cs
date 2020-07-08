

namespace P08MilitaryElyte.Models.Privatess
{
    using P08MilitaryElyte.Contracts;
    using P08MilitaryElyte.Models;
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:f2}";
        }
    }
}
