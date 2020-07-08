namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
        {
            if (this.Models.Any(m => m.Name == model.Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, model.Name));
            }

            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            var result = this.models.ToList();

            return result;
        }

        public bool Remove(IRace model)
        {
            bool result = false;

            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                result = true;
            }

            return result;
        }

        public IRace GetByName(string name)
        {
            if (!this.Models.Any(m => m.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
            }

            IRace race = this.Models.FirstOrDefault(m => m.Name == name);

            return race;
        }
    }
}
