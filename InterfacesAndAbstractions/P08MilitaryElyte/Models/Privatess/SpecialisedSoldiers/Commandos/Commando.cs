﻿
namespace P08MilitaryElyte.Models.Privatess.SpecialisedSoldiers.Commandos
{
    using P08MilitaryElyte.Contracts;
    using P08MilitaryElyte.Models.Privatess.SpecialisedSoldiers;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }
        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine(("Missions:"));

            foreach (var mis in this.Missions)
            {
                sb.AppendLine($" {mis.ToString().TrimEnd()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
