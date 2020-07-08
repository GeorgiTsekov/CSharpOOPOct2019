using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.guns.Contains(model))
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.guns.Where(g => g.Name == name).FirstOrDefault();

            return gun;
        }

        public bool Remove(IGun model)
        {
            if (this.guns.Contains(model))
            {
                this.guns.Remove(model);

                return true;
            }

            return false;
        }
    }
}
