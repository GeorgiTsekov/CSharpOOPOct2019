namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            if (!this.astronauts.Any(a => a.Name == model.Name))
            {
                this.astronauts.Add(model);
            }
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = this.astronauts.FirstOrDefault(a => a.Name == name);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {name} doesn't exists!");
            }

            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            bool result = false;

            if (this.astronauts.Any(a => a.Name == model.Name))
            {
                this.astronauts.Remove(model);

                result = true;
            }

            return result;
        }
    }
}
