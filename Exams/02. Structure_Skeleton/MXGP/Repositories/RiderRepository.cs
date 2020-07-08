namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> models;

        public RiderRepository()
        {
            this.models = new List<IRider>();
        }

        public IReadOnlyCollection<IRider> Models => models.AsReadOnly();

        public void Add(IRider model)
        {
            if (this.Models.Any(m => m.Name == model.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, model.Name));
            }

            this.models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            var result = this.models.ToList();

            return result;
        }

        public bool Remove(IRider model)
        {
            bool result = false;

            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                result = true;
            }

            return result;
        }

        public IRider GetByName(string name)
        {
            if (!this.Models.Any(m => m.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, name));
            }

            IRider rider = this.Models.FirstOrDefault(m => m.Name == name);

            return rider;
        }
    }
}
