namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            if (!this.planets.Any(p => p.Name == model.Name))
            {
                this.planets.Add(model);
            }
        }

        public IPlanet FindByName(string name)
        {
            var planet = this.planets.FirstOrDefault(a => a.Name == name);

            if (planet != null)
            {
                return planet;
            }

            return null;
        }

        public bool Remove(IPlanet model)
        {
            bool result = false;

            if (this.planets.Any(a => a.Name == model.Name))
            {
                this.planets.Remove(model);

                result = true;
            }

            return result;
        }
    }
}
