﻿namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using System;
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private const double DECREASE_OXYGEN = 10;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        //TODO
        public IBag Bag => this.bag;

        public virtual void Breath()
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
