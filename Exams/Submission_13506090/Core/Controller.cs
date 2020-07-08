using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> gunRepository;
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private Queue<IGun> guns;
        private INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.gunRepository = new GunRepository();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            string result = string.Empty;

            switch (type)
            {
                case "Pistol":
                    IGun pistol = new Pistol(name);
                    this.guns.Enqueue(pistol);
                    result = $"Successfully added {name} of type: {type}";
                    break;
                case "Rifle":
                    IGun rifle = new Rifle(name);
                    this.guns.Enqueue(rifle);
                    result = $"Successfully added {name} of type: {type}";
                    break;
                default:
                    result = "Invalid gun type!";
                    break;
            }

            return result;
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                IGun gun = this.guns.Dequeue();
                this.mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!this.civilPlayers.Any(p => p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                var player = this.civilPlayers.FirstOrDefault(p => p.Name == name);

                IGun gun = this.guns.Dequeue();

                player.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string Fight()
        {
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            string result = string.Empty;

            if (this.mainPlayer.LifePoints == 100 && this.civilPlayers.FirstOrDefault().LifePoints == 50)
            {
                result += "Everything is okay!";
            }
            else
            {
                int deadCivilPlayers = this.civilPlayers.Where(p => !p.IsAlive).Count();
                int aliveCivilPlayers = this.civilPlayers.Where(p => p.IsAlive).Count();

                result += "A fight happened:" + Environment.NewLine +
                    $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine +
                    $"Tommy has killed: {deadCivilPlayers} players!" + Environment.NewLine +
                    $"Left Civil Players: {aliveCivilPlayers}!";
            }

            return result.TrimEnd();
        }
    }
}
