namespace MortalEngines.Entities
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double HealthPointsConst = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
: base(name, attackPoints, defensePoints, HealthPointsConst)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (this.AggressiveMode)
            {
                sb.AppendLine(" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine(" *Aggressive: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
