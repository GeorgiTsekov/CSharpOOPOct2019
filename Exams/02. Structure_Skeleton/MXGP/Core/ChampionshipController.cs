namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IRider> riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();       
            this.riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);
            var rider = this.riderRepository.GetByName(riderName);

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            string result = string.Empty;

            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                default:
                    break;
            }

            this.motorcycleRepository.Add(motorcycle);
            result += string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
            return result;
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);

            this.riderRepository.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var riders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, raceName));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
