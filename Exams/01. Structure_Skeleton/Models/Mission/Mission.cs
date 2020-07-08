using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<IAstronaut> explorers = astronauts.Where(a => a.Oxygen > 0).ToList();

            foreach (var astronaut in explorers)
            {
                while (astronaut.Oxygen > 0 && planet.Items.Count > 0)
                {
                    string item = planet.Items.FirstOrDefault();

                    astronaut.Bag.Items.Add(item);

                    astronaut.Breath();

                    planet.Items.Remove(item);
                }
            }
        }
    }
}
