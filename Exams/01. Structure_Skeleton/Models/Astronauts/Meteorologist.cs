﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double meteorologistOxygen = 90;

        public Meteorologist(string name) 
            : base(name)
        {
            this.Oxygen = meteorologistOxygen;
        }
    }
}
