namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Bags;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private IBag items;
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new Backpack();
        }

        public ICollection<string> Items => this.items.Items;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                this.name = value;
            }
        }
    }
}
