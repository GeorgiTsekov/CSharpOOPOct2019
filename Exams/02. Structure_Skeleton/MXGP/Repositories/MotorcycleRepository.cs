namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> models;

        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }

        public IReadOnlyCollection<IMotorcycle> Models => models.AsReadOnly();

        public void Add(IMotorcycle model)
        {
            if (this.Models.Any(m => m.Model == model.Model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model.Model));
            }

            this.models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            var result = this.models.ToList();

            return result;
        }

        public bool Remove(IMotorcycle model)
        {
            bool result = false;

            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                result = true;
            }

            return result;
        }

        public IMotorcycle GetByName(string name)
        {
            if (!this.Models.Any(m => m.Model == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, name));
            }

            IMotorcycle motorcycle = this.Models.FirstOrDefault(m => m.Model == name);

            return motorcycle;
        }
    }
}
