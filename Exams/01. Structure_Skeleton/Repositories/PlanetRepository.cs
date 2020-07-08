using SpaceStation.Models.Planets;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories.Contracts
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models.Where(p => p.Name == name).FirstOrDefault();

            return planet;
        }

        public bool Remove(IPlanet model)
        {
            bool result = false;

            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                result = true;
            }

            return result;
        }
    }
}
