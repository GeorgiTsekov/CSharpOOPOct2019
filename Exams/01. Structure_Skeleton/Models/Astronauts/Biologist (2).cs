namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double INITIAL_OXYGEN = 70;
        private const double DECREASE_OXYGEN = 5;

        public Biologist(string name) 
            : base(name, INITIAL_OXYGEN)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - DECREASE_OXYGEN < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= DECREASE_OXYGEN;
            }
        }
    }
}
