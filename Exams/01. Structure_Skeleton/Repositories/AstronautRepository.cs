using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = null;

            astronaut = models.Where(p => p.Name == name).FirstOrDefault();

            return astronaut;
        }

        public bool Remove(IAstronaut model)
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
