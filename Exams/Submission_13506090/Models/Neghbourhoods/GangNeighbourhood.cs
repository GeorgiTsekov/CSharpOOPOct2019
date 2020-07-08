namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Any(g => g.CanFire) && civilPlayers.Any(p => p.IsAlive))
            {
                var bullets = mainPlayer.GunRepository.Models.FirstOrDefault().Fire();
                civilPlayers.FirstOrDefault(p => p.IsAlive).TakeLifePoints(bullets);
            }

            while (civilPlayers.Any(p => p.GunRepository.Models.Any(g => g.CanFire) && mainPlayer.IsAlive))
            {
                foreach (var player in civilPlayers)
                {
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }

                    foreach (var gun in player.GunRepository.Models)
                    {
                        if (!mainPlayer.IsAlive)
                        {
                            break;
                        }

                        if (gun.CanFire)
                        {
                            int bullets = gun.Fire();

                            mainPlayer.TakeLifePoints(bullets);
                        }
                    }
                }
            }
        }
    }
}
