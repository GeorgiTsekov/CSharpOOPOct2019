namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                var astronaut = astronauts.FirstOrDefault(a => a.CanBreath);
                var item = planet.Items.FirstOrDefault();

                if (astronaut == null || item == null)
                {
                    break;
                }

                astronaut.Breath();

                astronaut.Bag.Items.Add(item);

                planet.Items.Remove(item);
            }
        }
    }
}
