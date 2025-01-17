﻿namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double biologistOxygen = 70;

        public Biologist(string name)
            : base(name)
        {
            this.Oxygen = biologistOxygen;
        }

        public override void Breath()
        {
            this.Oxygen -= 5;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
