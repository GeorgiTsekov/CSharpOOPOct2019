using SpaceStation.Core.Contracts;
using System;
using System.Collections.Generic;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Planets;
using System.Linq;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Astronauts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautRepository;
        private IRepository<IPlanet> planetRepository;
        private IMission mission;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            //???
            List<IAstronaut> astronauts = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();
            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            
            var planet = this.planetRepository.FindByName(planetName);

            this.mission.Explore(planet, astronauts);

            this.exploredPlanetsCount++;

            int deadAstronauts = astronauts.Where(a => a.Oxygen == 0).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            string result = $"{this.exploredPlanetsCount} planets were explored!"
                + Environment.NewLine + "Astronauts info:"
                + Environment.NewLine;

            foreach (var astronaut in this.astronautRepository.Models)
            {
                result += $"Name: {astronaut.Name}"
                    + Environment.NewLine + $"Oxygen: {astronaut.Oxygen}"
                    + Environment.NewLine;
                if (astronaut.Bag.Items.Count > 0)
                {
                    result += $"Bag items: {string.Join(", ", astronaut.Bag.Items)}" + Environment.NewLine;
                }
                else
                {
                    result += "Bag items: none" + Environment.NewLine;
                }
            }

            return result.TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);
            bool result = this.astronautRepository.Remove(astronaut);

            if (!result)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
