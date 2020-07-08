
namespace P08MilitaryElyte.Soldier
{
    using System.Collections.Generic;
    using System.Text;
    using P08MilitaryElyte.Contracts;
    using P08MilitaryElyte.Models.Privatess;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var pr in this.Privates)
            {
                sb.AppendLine($" {pr.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
